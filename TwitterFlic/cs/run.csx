using System.Net;
using System.Net.Http;
using LinqToTwitter;

private static TwitterContext _twitterCtx = null;
private static IDictionary<string, string> _messageMap;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log, string messageType)
{        
    
    if (_twitterCtx == null)
    {
        await SetupTwitterClient();
    }

    if (_messageMap.TryGetValue(messageType, out string message))
    {
        try
        {
            return req.CreateResponse(HttpStatusCode.OK);
        }
        catch (TwitterQueryException ex) {
            return req.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }

    return req.CreateResponse(HttpStatusCode.BadRequest, "Invalid message");   
}

private static async Task SetupTwitterClient()
{
    SingleUserAuthorizer authorizer = new SingleUserAuthorizer
    {
        CredentialStore = new SingleUserInMemoryCredentialStore
        {
            ConsumerKey = Environment.GetEnvironmentVariable("TwitterAppKey", EnvironmentVariableTarget.Process),
            ConsumerSecret = Environment.GetEnvironmentVariable("TwitterAppSecret", EnvironmentVariableTarget.Process),
            AccessToken = Environment.GetEnvironmentVariable("TwitterAccessToken", EnvironmentVariableTarget.Process),
            AccessTokenSecret = Environment.GetEnvironmentVariable("TwitterAccessTokenSecret", EnvironmentVariableTarget.Process)
        }
    };
    await authorizer.AuthorizeAsync();

    _messageMap = new Dictionary<string, string>
    {
        ["arrived"] = "Arrived at #ServerlessConf NYC. Trying out this cool #AzureFunctions demo!",
        ["joinme"] = "You should join me at the Microsoft booth at #Serverlessconf NYC!",
        ["azurefunctions"] = "Azure Functions is awesome!"
    };

    _twitterCtx = new TwitterContext(authorizer);
}


