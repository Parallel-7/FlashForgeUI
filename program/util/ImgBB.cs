using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using FiveMApi.api;
using Newtonsoft.Json.Linq;

namespace FlashForgeUI.program.util
{
    public class ImgBB
    {

        public static async Task<string> Upload(Bitmap image, string imageName)
        {
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(5);
            var formData = new MultipartFormDataContent();

            try
            {
                // Convert Bitmap to byte array
                byte[] imageBytes;
                using (var memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png); // Save the Bitmap to the memory stream as PNG
                    imageBytes = memoryStream.ToArray(); // Convert the memory stream to a byte array
                }

                // Add the image byte array as a stream content to the form data
                using (var memoryStream = new MemoryStream(imageBytes))
                {
                    formData.Add(new StreamContent(memoryStream), "source", imageName);
                    formData.Add(new StringContent(""), "upload-expiration");
                    formData.Add(new StringContent("file"), "type");
                    formData.Add(new StringContent("upload"), "action");

                    // Send the POST request
                    var response = await client.PostAsync("https://imgbb.com/json", formData);
                    var result = await response.Content.ReadAsStringAsync();

                    // Parse the JSON response to extract the image URL
                    var json = JObject.Parse(result);
                    return json["image"]?["url"]?.ToString();
                }
            }
            catch (Exception ex)
            {
                // TODO: Add better error handling
                Debug.WriteLine("ImgBB.Upload failed: " + ex.Message + "\n" + ex.StackTrace);
                return null;
            }
        }

        
    }
}