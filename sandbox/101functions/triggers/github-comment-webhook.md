## GitHub Comment Webhook

```
using System.Net;

public static async Task Run(HttpRequestMessage req, TraceWriter log)
{
    dynamic data = await req.Content.ReadAsAsync<object>();
    string gitHubComment = data?.comment?.body;
    log.Info("GitHub Comment WebHook: " + gitHubComment);
}

```

## Read More
[Create a function triggered by a GitHub webhook](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-github-webhook-triggered-function)
[Azure Functions HTTP and webhook bindings](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-http-webhook)