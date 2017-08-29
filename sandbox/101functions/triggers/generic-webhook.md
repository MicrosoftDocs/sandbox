## Webhook Function

The following example is a generic webhook. You

```
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