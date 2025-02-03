using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace FlashForgeUI.program.util
{
    public class Config
    {

        public bool WebUi { get; set; }
        public bool DiscordSync { get; set; }
        public string WebhookUrl { get; set; }

        public bool CustomCamera { get; set; }
        public string CustomCameraUrl { get; set; }


        private const string FilePath = "config.json";

        public void Save()
        {
            var jsonData = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(FilePath, jsonData);
        }
        
        public Config Load()
        {
            if (!File.Exists(FilePath))
            {
                Debug.WriteLine("config.json not found, creating & loading default settings.");
                WebUi = false;
                DiscordSync = false;
                WebhookUrl = "";
                CustomCamera = false;
                CustomCameraUrl = "";
                Save();
                return this;
            }
            var jsonData = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<Config>(jsonData);
        }


    }
}