using Objects;
using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using OpenAI;
using Speckle.Automate.Sdk;
using Speckle.Core.Models.Extensions;
using OpenAI.Interfaces;

public static class AutomateFunction
{
    public static async Task Run(
      AutomationContext automationContext,  
      FunctionInputs functionInputs
    )
    {
        // not sure if this is needed 
        Console.WriteLine("Starting execution");
        _ = typeof(ObjectsKit).Assembly; // INFO: Force objects kit to initialize

        Console.WriteLine("Receiving version");
        var commitObject = await automationContext.ReceiveVersion();

        try
        {
            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = functionInputs.ExternalServiceKey

            });

            var imageCreateRequest = new ImageEditCreateRequest();

            var image = await openAiService.CreateImage(functionInputs.Vibe.ToString());

            Console.WriteLine("is image successful?", image.Successful == true);

        }
        catch (Exception)
        {

            throw;
        }

        var url= automationContext.SpeckleClient.ServerUrl;

        Console.WriteLine("Current Server: " + url);

        automationContext.MarkRunSuccess("\nIs now better\n");
        
        //automationContext.StoreFileResult(url);
    }
}
