## Generic Webhook Function

Functions can be created for custom webhooks. The following example is a generic webhook with a request body that contains a first and last name. 

```csharp
#r "Newtonsoft.Json"

using System;
using System.Net;
using Newtonsoft.Json;

public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info($"Webhook triggered!");

    string jsonContent = await req.Content.ReadAsStringAsync();
    dynamic data = JsonConvert.DeserializeObject(jsonContent);

    return req.CreateResponse(HttpStatusCode.OK, new
    {
        greeting = $"Hello {data.firstName} {data.lastName}!"
    });
}
```

[!include[](../includes/takeaways-heading.md)]

- Generic webhook functions are a solution to customizable function triggers.
- Generic webhook function triggers can respond to any HTTP method, or be customized to respond to a select number of HTTP methods.

[!include[](../includes/read-more-heading.md)]

- [Create a function triggered by a generic webhook](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-generic-webhook-triggered-function)
- [Azure Functions HTTP and webhook bindings](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-http-webhook)