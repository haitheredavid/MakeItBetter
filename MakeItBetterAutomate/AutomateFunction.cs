using Objects;
using Speckle.Automate.Sdk;
using Speckle.Core.Models.Extensions;

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


        var url= automationContext.SpeckleClient.ServerUrl;

        Console.WriteLine("Current Server: " + url);

        automationContext.MarkRunSuccess("Is now better");
    }
}
