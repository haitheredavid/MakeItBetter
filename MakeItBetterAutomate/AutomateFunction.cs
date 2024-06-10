using Objects;
using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using OpenAI;
using Speckle.Automate.Sdk;
using Speckle.Core.Models.Extensions;
using OpenAI.Interfaces;
using Serilog;
using OpenAI.ObjectModels.ResponseModels;
using static System.Net.Mime.MediaTypeNames;

public static class AutomateFunction
{
    public static async Task Run(
      AutomationContext automationContext,  
      FunctionInputs functionInputs
    )
    {
        // I dont think this is needed since we just do images
        //// not sure if this is needed 
        //Console.WriteLine("Starting execution");
        //_ = typeof(ObjectsKit).Assembly; // INFO: Force objects kit to initialize

        Console.WriteLine("Receiving version");
        var commitObject = await automationContext.ReceiveVersion();

        try
        {
            // not sure what the fuck this is 
            var completionResult = new CompletionCreateResponse();

            //// all of the api shit for dalle
            //var openAiService = new OpenAIService(new OpenAiOptions()
            //{
            //    ApiKey = functionInputs.ExternalServiceKey

            //});

            //var imageCreateRequest = new ImageEditCreateRequest();

            Console.WriteLine("MIB= getting image from dalle");

            //var imageResult = await openAiService.CreateImage(functionInputs.Vibe.ToString());


            //if (imageResult.Successful)
            //{
            //    var img = string.Join("\n", imageResult.Results.Select(r => r.Url));
            //    Console.WriteLine($"MIB={img}");
            //    Console.WriteLine("MIB=Trying to attach image now");

            //    await automationContext.StoreFileResult(img);

            //    Console.WriteLine("MIB=Checking if automation did the thing");


            //}
            //else //handle errors
            //{
            //    if (imageResult.Error == null)
            //    {
            //        throw new Exception("Unknown Error");
            //    }
            //    Console.WriteLine($"{imageResult.Error.Code}: {completionResult.Error.Message}");
            //}

        }
        catch (Exception)
        {

            throw;
        }

        var url= automationContext.SpeckleClient.ServerUrl;

        Console.WriteLine("MIB=Sever is: " + url);

        automationContext.MarkRunSuccess("\nMIB=Is now better\n");
        
        //automationContext.StoreFileResult(url);
    }
}
