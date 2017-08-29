## GitHub Comment Webhook

Functions can be triggered with a GitHub webhook. This requires configuring a webhook for a GitHub repository. This example logs issue comments from a GitHub repository.

```csharp
using System.Net;

public static async Task Run(HttpRequestMessage req, TraceWriter log)
{
    dynamic data = await req.Content.ReadAsAsync<object>();
    string gitHubComment = data?.comment?.body;
    log.Info("GitHub Comment WebHook: " + gitHubComment);
}

```

[!include[](../includes/takeaways-heading.md)]

- A GitHub webhook function requires configuration on GitHub by adding a webhook to a GitHub repository, adding the function's url and GitHub secret to the webhook, and setting the content type as `application/json`.

- A GitHub webhook function can be triggered by a number of repository changes such as issues, pull requests, and branches.


[!include[](../includes/read-more-heading.md)]

- [Create a function triggered by a GitHub webhook](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-github-webhook-triggered-function)
- [Azure Functions HTTP and webhook bindings](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-http-webhook)