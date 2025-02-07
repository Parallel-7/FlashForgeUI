using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FiveMApi.api;
using FlashForgeUI.ui.main.util;
using MainMenu = FlashForgeUI.ui.main.MainMenu;

namespace FlashForgeUI
{
    public partial class GCodeListWindow : Form
    {
        
        private readonly FiveMClient _client;
        private bool _fullList;

        public string SelectedFileName { get; private set; }

        public bool AutoLevel { get; private set; }
        
        
        public GCodeListWindow(MainMenu mainMenu, FiveMClient client, bool fullList = false)
        {
            InitializeComponent();
            _client = client;
            _fullList = fullList;
            // Set up the ListView
            gcodeFiles.View = View.LargeIcon;
            gcodeFiles.MultiSelect = false;
            gcodeFiles.Click += ListViewGcodeFiles_Click;
            PopulateList();
            
            Shown += (s, e) =>
            {
                if (mainMenu.Config.AlwaysOnTop)
                {
                    var _uiHelper = new UiHelper(mainMenu);
                    _uiHelper.SetOnTop(Handle);
                }
            };
            
            // the "default" NightControlBox just closes the application when exit is clicked..??
            FormClosing += (s, e) => 
            {
                if (e.CloseReason == CloseReason.ApplicationExitCall)
                {
                    e.Cancel = true;
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            };
        }
        
        private async void PopulateList()
        {
            nightForm1.Text = !_fullList ? "Loading recent jobs..." : "Loading local files...";
            gcodeFiles.Items.Clear();

            List<string> files;

            if (_fullList)
                files = await _client.Files.GetLocalFileList(); // uses legacy API - slow
            else
                files = await _client.Files.GetRecentFileList(); // uses new API - quick

            if (files != null && files.Count > 0)
            {
                var imageList = new ImageList
                {
                    ImageSize = new Size(128, 128),
                    ColorDepth = ColorDepth.Depth32Bit
                };

                gcodeFiles.LargeImageList = imageList;

                // Add all ListViewItems upfront to maintain order
                foreach (var item in files.Select(t => new ListViewItem(t)))
                {
                    gcodeFiles.Items.Add(item);
                }

                var threads = 2;
                if (_fullList) threads += Convert.ToInt32(files.Count / 10); // increase threads based on file list size
                //Console.WriteLine($"Using {threads} threads for GCodeList ");
                if (threads > 10) threads = 10; // cap at 10
                //if (_fullList) threads = 4;
                var semaphore = new SemaphoreSlim(threads);

                var filesProcessed = 0;

                var tasks = (from index in files.Select((t, i) => i)
                    let file = files[index]
                    select Task.Run(async () =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            var thumbnailData = await _client.Files.GetGCodeThumbnail(file);
                            if (thumbnailData != null)
                            {
                                var thumbnailImage = ConvertToBitmap(thumbnailData);

                                // Update UI on the main thread
                                try
                                {
                                    BeginInvoke(new Action(() =>
                                    {
                                        imageList.Images.Add(file, thumbnailImage);

                                        // Assign the image to the corresponding ListViewItem
                                        gcodeFiles.Items[index].ImageKey = file;

                                        filesProcessed++;
                                        nightForm1.Text = !_fullList
                                            ? $"Loading recent jobs... ({filesProcessed}/{files.Count})"
                                            : $"Loading local files... ({filesProcessed}/{files.Count})";
                                    }));
                                }
                                catch (Exception ignored)
                                {
                                    // not an ideal solution..
                                } 
                            }
                            else
                            {
                                Console.WriteLine($"Thumbnail for file {file} is null.");
                            }
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    })).ToList();

                await Task.WhenAll(tasks);

                nightForm1.Text = !_fullList ? "Select recent job" : "Select job";
            }
            else
            {
                nightForm1.Text = !_fullList ? "No recent jobs" : "No local files";
                Console.WriteLine("No files retrieved or list is null.");
            }
        }


        private void ListViewGcodeFiles_Click(object sender, EventArgs e)
        {
            if (gcodeFiles.SelectedItems.Count <= 0) return;
            SelectedFileName = gcodeFiles.SelectedItems[0].Text;
            selectedFile.Text = $"Selected File: {SelectedFileName}";
        }

        private static Bitmap ConvertToBitmap(byte[] imageData)
        {
            using (var ms = new MemoryStream(imageData))
            {
                return new Bitmap(ms);
            }
        }


        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (gcodeFiles.SelectedItems.Count <= 0 || string.IsNullOrEmpty(SelectedFileName))
            {
                MessageBox.Show("Invalid (or no) selection!");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void autoLevelBox_CheckedChanged(object sender, EventArgs e)
        {
            AutoLevel = autoLevel.Checked;
        }
        
    }
}