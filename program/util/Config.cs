using System.ComponentModel;
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
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool AlwaysOnTop { get; set; }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool AlertWhenComplete { get; set; }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool AlertWhenCooled { get; set; }
        
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(true)]
        public bool AudioAlerts { get; set; }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(true)]
        public bool VisualAlerts { get; set; }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(false)]
        public bool DebugMode { get; set; }
        
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
                AlwaysOnTop = false;
                AlertWhenComplete = false;
                AlertWhenCooled = false;
                AudioAlerts = false;
                VisualAlerts = true;
                DebugMode = false;
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