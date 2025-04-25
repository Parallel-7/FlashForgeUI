using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using FiveMApi.api.misc;
using ReaLTaiizor.Controls;

namespace FlashForgeUI.ui.main.util
{
    public class Utils
    {

        // kinda hacky to avoid showDialog but same purpose minus sound
        public static async Task WaitForForm(Form form)
        {
            var tcs = new TaskCompletionSource<bool>();
            form.FormClosed += (sender, e) => 
            {
                tcs.SetResult(true);
            };
            form.Show();
            await tcs.Task;
        }
        
        public static string FormatTemps(string text, Temperature current, Temperature set)
        {
            return $"{text}{FormatTemps(current, set)}";
        }
        
        public static string FormatTemps(Temperature current, Temperature set)
        {
            return $"{current.AsStr()}/{set.AsStr()}";
        }

        public static void SetLabelText(Control label, string text)
        {
            //Console.WriteLine($"Setting control ({label.Name} text to {text}");
            // todo handle other label type or all at once?
            if (label is NightLabel nlabel)
            {
                nlabel.BeginInvoke(new Action(() =>
                {
                    nlabel.Text = text;
                }));
            }
        }

        public static void SetButtonText(Control button, string text)
        {
            if (button is HopeButton hButton)
            {
                hButton.BeginInvoke(new Action(() =>
                {
                    hButton.Text = text;
                    hButton.Refresh(); // button text will not update (until next mouseover or something else) without this
                }));
            }
        }
        
    }
}