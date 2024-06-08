using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using OpenAI.Managers;
using OpenAI;
using OpenAI.Interfaces;
using OpenAI.ObjectModels.RequestModels;

namespace dalle_api
{
    class Program
    {
        static async Task Main(string[] args)
        {

            // get rid of

            try
            {
                var openAiService = new OpenAIService(new OpenAiOptions()
                {
                    ApiKey = apiKey
                });

                var image = await openAiService.CreateImage("some prompt");
                Console.WriteLine("is image successful?", image.Successful == true);

            }
            catch (Exception)
            {

                throw;
            }




            /*var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var requestData = new
            {
                model= "dall-e-3",
                prompt = "A futuristic cityscape with flying cars",
                size = "1024x1024",
                n = 1
            };

            var jsonContent = new StringContent(JObject.FromObject(requestData).ToString(), Encoding.UTF8, "application/json");


            try
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl, jsonContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response received from DALL-E v3 API:");
                Console.WriteLine(responseBody);

                // Parse the JSON response
                var jsonResponse = JObject.Parse(responseBody);
                var base64Image = jsonResponse["data"]?[0]?["image"]?.ToString();

                if (base64Image != null)
                {
                    byte[] imageBytes = Convert.FromBase64String(base64Image);

                    string outputPath = "output_image.png";
                    await File.WriteAllBytesAsync(outputPath, imageBytes);

                    Console.WriteLine($"Image saved to {outputPath}");
                }
                else
                {
                    Console.WriteLine("Image data not found in the response.");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }*/
        }

    }
}