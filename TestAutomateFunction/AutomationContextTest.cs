using System.Drawing;
using System.Drawing.Imaging;
using System.Net;

namespace TestAutomateFunction;

using Speckle.Automate.Sdk;
using Speckle.Automate.Sdk.Test;
using Speckle.Core.Api;
using Speckle.Core.Credentials;
using Speckle.Core.Logging;

[TestFixture]
public sealed class AutomationContextTest : IDisposable
{
    private Client client;
    private Account account;
    private System.IO.Stream stream;

    [OneTimeSetUp]
    public void Setup()
    {
        account = new Account
        {
            serverInfo = new ServerInfo { url = "https://latest.speckle.systems/" }
        };

        client = new Client(account);

        wc = new WebClient();
        wc.Headers.Set(HttpRequestHeader.Authorization, $"Bearer {account.token}");
    }

    private WebClient wc;

    [Test]
    public async Task TestFunctionRun()
    {
        const string modelId = "94eddeb7cc";
        const string projectId = "035653d2b8";
        const string versionId = "94eddeb7cc";
        const string objectId = "4f52fbcce01f1ddefa9834f1dae154ac";


        var model = await client.ModelGet(projectId, modelId);
        var obj = await client.ObjectGet(projectId, objectId);

        Console.WriteLine(model.ToString());
        Console.WriteLine(obj.ToString());
         
        var projectUrl = $"https://latest.speckle.systems/preview/{projectId}";
        var modelUrl = $"https://latest.speckle.systems/preview/{projectId}/branches/{modelId}";
        var commitUrl = $"https://latest.speckle.systems/preview/{projectId}/commits/{versionId}";
        var objectUrl = $"https://latest.speckle.systems/preview/{projectId}/objects/{objectId}";

        var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "project-test.png");
        var format = ImageFormat.Png;
        stream = wc.OpenRead(projectUrl);
        var bitmap = new Bitmap(stream);

        if (bitmap != null)
        {
            Dispose();
            bitmap.Save(filename, format);
        }

        await stream.FlushAsync();


        return;
        var inputs = new FunctionInputs
        {
            Vibe = "Some chill city vibes",
        };

        var automationRunData = await TestAutomateUtils.CreateTestRun(client);
        var automationContext = await AutomationRunner.RunFunction(
            AutomateFunction.Run,
            automationRunData,
            account.token,
            inputs
        );

        Assert.That(automationContext.RunStatus, Is.EqualTo("SUCCEEDED"));
    }

    public void Dispose()
    {
        client.Dispose();
        wc.Dispose();
        stream.Close();
        
    }
}