using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using FlashForgeUI.ui.main.util;
using SlicerMeta;
using SlicerMeta.parser.gcode;
using SlicerMeta.parser.threemf;
using MainMenu = FlashForgeUI.ui.main.MainMenu;

namespace FlashForgeUI
{
    public partial class GCodeFilePicker : Form
    {
        
        public string SelectedFilePath { get; private set; }
        public bool StartNow { get; private set; }
        public bool AutoLevel { get; private set; }
        
        public GCodeFilePicker(MainMenu mainMenu)
        {
            InitializeComponent();
            Shown += (s, e) =>
            {
                if (mainMenu.Config.AlwaysOnTop) mainMenu.UiHelper.SetOnTop(Handle);
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
        
        private void browseButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                ParseSelectedFile(openFileDialog1.FileName);
            }
        }

        private void startNowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Show or hide the Auto Level checkbox based on Start Now checkbox state
            autoLevelCheckBox.Visible = startNowCheckBox.Checked;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SelectedFilePath = textBox1.Text;
            StartNow = startNowCheckBox.Checked;
            AutoLevel = autoLevelCheckBox.Checked;

            if (string.IsNullOrEmpty(SelectedFilePath) || !File.Exists(SelectedFilePath))
            {
                MessageBox.Show("Please select a valid G-code or 3MF file.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ParseSelectedFile(string filePath)
        {
            // Clear previous data
            if (pictureBoxThumbnail.Image != null)
            {
                pictureBoxThumbnail.Image.Dispose();
                pictureBoxThumbnail.Image = null;
            }
            printerModelLabel.Text = "Printer Model:";
            filamentTypeLabel.Text = "Filament Type:";
            filamentUsedLabel.Text = "Filament Used:";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Selected file does not exist.", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string extension = Path.GetExtension(filePath).ToLower();

            try
            {
                if (extension == ".gcode")
                {
                    //OrcaFFGCodeParser parser = new OrcaFFGCodeParser(filePath);
                    //parser.Parse();
                    var parser = new GCodeParser();
                    
                    //var parser = new DynamicGCodeParser(filePath);
                    parser.Parse(filePath);

                    // Update form controls with extracted data
                    UpdateFormWithGCodeData(parser);
                }
                else if (extension == ".3mf")
                {
                    var parser = new ThreeMfParser();
                    parser.Parse(filePath);

                    // Update form controls with extracted data
                    UpdateFormWithThreeMfData(parser);
                }
                else
                {
                    MessageBox.Show("Unsupported file type. Please select a .gcode or .3mf file.", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while parsing the file:\n{ex.Message}", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.StackTrace);
                // Optionally reset form controls
                if (pictureBoxThumbnail.Image != null)
                {
                    pictureBoxThumbnail.Image.Dispose();
                    pictureBoxThumbnail.Image = null;
                }
                printerModelLabel.Text = "Printer Model:";
                filamentTypeLabel.Text = "Filament Type:";
                filamentUsedLabel.Text = "Filament Used:";
            }
        }

        private void UpdateFormWithGCodeData(GCodeParser parser)
        {
            // Update labels with extracted data
            if (!string.IsNullOrEmpty(parser.FileInfo.PrinterModel))
            {
                printerModelLabel.Text = $"Printer Model: {parser.FileInfo.PrinterModel}";
                if (!parser.FileInfo.PrinterModel.Contains("Flashforge") && !parser.FileInfo.PrinterModel.Contains("5M"))
                {
                    MessageBox.Show(
                        "This file was sliced for a different printer, unless you know 100% what you're doing, do NOT send this to your printer.",
                        "Mismatched machine type");
                }
            }

            if (!string.IsNullOrEmpty(parser.FileInfo.FilamentType))
            {
                filamentTypeLabel.Text = $"Filament Type: {parser.FileInfo.FilamentType}";
            }

            if (parser.SlicerInfo != null)
            { // populate slicer metadata
                slicerLabel.Text = $"Sliced by: {parser.SlicerInfo.SlicerName}";
                slicerVersionLabel.Text = $"Version: {parser.SlicerInfo.SlicerVersion}";
                sliceDateLabel.Text = $"Date: {parser.SlicerInfo.SliceDate}";
                sliceTimeLabel.Text = $"Time: {parser.SlicerInfo.SliceTime}";
                etaLabel.Text = parser.SlicerInfo.Slicer == SlicerType.OrcaFF ? $"Estimated Print Time: {parser.SlicerInfo.PrintEta}" : "Estimated Print Time: Not available";
            }
            
            //Console.WriteLine(parser.SlicerType);
            
            filamentUsedLabel.Text = parser.SlicerInfo.Slicer == SlicerType.OrcaFF
                ? $"Filament Used: {parser.FileInfo.FilamentUsedG} g"
                : "Filament Used: Not available";

            if (parser.FileInfo.Thumbnail != null) pictureBoxThumbnail.Image = parser.FileInfo.Thumbnail;
            else
            {
                switch (parser.SlicerInfo.Slicer)
                {
                    default: // fallback
                    case SlicerType.Unknown: // not able to parse (will warn about unknown software below so do nothing here)
                    case SlicerType.FlashPrint: // not generated with a thumbnail, expected
                        break;
                    case SlicerType.OrcaFF: // these should always contain a thumbnail, warn the user
                        MessageBox.Show("This file doesn't contain an embedded preview.", "No thumbnail!");
                        break;
                }
            }
            
            // It is possible to slice files for the 5M/Pro with additional slicers, but this targets only what is directly "supported"
            // FlashPrint is their own proprietary slicer, same with Orca-FlashForge (except it's a "fork")
            // The configs are either built in or directly supplied from FlashForge so this is designed around that "work out of the box"
            if (parser.SlicerInfo.Slicer == SlicerType.Unknown)
            {
                MessageBox.Show(
                    "This file was generated by unrecognized software, or hasn't been updated to support the version you're using." +
                    "Take care to make sure this is compatible with your printer", "Unrecognized slicing software");
            }
        }

        private void UpdateFormWithThreeMfData(ThreeMfParser parser)
        {
            // Update labels with extracted data
            if (!string.IsNullOrEmpty(parser.PrinterModelId))
            {
                printerModelLabel.Text = $"Printer Model: {parser.PrinterModelId}";
            }

            if (parser.Filaments != null && parser.Filaments.Count > 0)
            {
                filamentTypeLabel.Text = $"Filament Type: {parser.Filaments[0].Type}";
                filamentUsedLabel.Text = $"Filament Used: {parser.Filaments[0].UsedG} g";
            }

            // Display the plate image
            if (parser.PlateImage != null)
            {
                pictureBoxThumbnail.Image = parser.PlateImage;
            }
            
            if (parser.SlicerInfo != null)
            { // populate slicer metadata
                slicerLabel.Text = $"Sliced by: {parser.SlicerInfo.SlicerName}";
                slicerVersionLabel.Text = $"Version: {parser.SlicerInfo.SlicerVersion}";
                sliceDateLabel.Text = $"Date: {parser.SlicerInfo.SliceDate}";
                sliceTimeLabel.Text = $"Time: {parser.SlicerInfo.SliceTime}";
                etaLabel.Text = parser.SlicerInfo.Slicer == SlicerType.OrcaFF ? $"Estimated Print Time: {parser.SlicerInfo.PrintEta}" : "Estimated Print Time: Not available";
            }
            else
            {
                Console.WriteLine("Slicer Info is null?");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (pictureBoxThumbnail.Image != null)
            {
                pictureBoxThumbnail.Image.Dispose();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}