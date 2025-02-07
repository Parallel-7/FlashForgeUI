using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlashForgeUI.ui.main;

namespace FlashForgeUI
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //AllocConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); 
            Application.Run(new ui.main.MainMenu());
            
        }
        
        //TODO
        // Uploading local job *works* but returns false? Tried with a 3mf file, dont know about gcode
        // The relevant code is in FiveMApi.api.control.controls.JobControl
    }
}