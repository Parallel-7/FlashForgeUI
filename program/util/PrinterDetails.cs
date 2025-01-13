using System.IO;
using Newtonsoft.Json;

namespace FlashForgeUI
{
    public class PrinterDetails
    {
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public string SerialNumber { get; set; }
        public string CheckCode { get; set; }

        private static readonly string filePath = "printer_details.json";

        public PrinterDetails(string name, string ip, string serial, string code)
        {
            Name = name;
            IPAddress = ip;
            SerialNumber = serial;
            CheckCode = code;
        }

        public PrinterDetails()
        {
            
        }

        public void Save()
        {
            var jsonData = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }

        public static PrinterDetails Load()
        {
            if (!File.Exists(filePath)) return null;
            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<PrinterDetails>(jsonData);
        }
    }
}