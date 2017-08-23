## GitHub Comment WebHook

```
using System.Net;

public static async Task Run(HttpRequestMessage req, TraceWriter log)
{
    var data = await req.Content.ReadAsAsync<object>();
    string gitHubComment = data?.comment?.body;
    log.Info("GitHub Comment WebHook: " + gitHubComment);
}

```