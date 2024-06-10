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
                    ApiKey = userApiKey

                });

                var imageCreateRequest = new ImageEditCreateRequest();

                var image = await openAiService.CreateImage("some prompt");

                Console.WriteLine("is image successful?", image.Successful == true);

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}