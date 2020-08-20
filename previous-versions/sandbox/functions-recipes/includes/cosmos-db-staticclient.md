## Customize a DocumentClient and reuse it between executions

You can create your own `DocumentClient` and customize it for your needs, while maintaining a single shared instance for all the Function's executions. The single instance is ensured by the use of the `static` keyword when declaring the `DocumentClient`.

```csharp
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

private static DocumentClient client = GetCustomClient();
private static DocumentClient GetCustomClient()
{
    DocumentClient customClient = new DocumentClient(
        new Uri(ConfigurationManager.AppSettings["CosmosDBAccountEndpoint"]), 
        ConfigurationManager.AppSettings["CosmosDBAccountKey"],
        new ConnectionPolicy
        {
            ConnectionMode = ConnectionMode.Direct,
            ConnectionProtocol = Protocol.Tcp,
            // Customize retry options for Throttled requests
            RetryOptions = new RetryOptions()
            {
                MaxRetryAttemptsOnThrottledRequests = 10,
                MaxRetryWaitTimeInSeconds = 30
            }
        });

    // Customize PreferredLocations
    customClient.ConnectionPolicy.PreferredLocations.Add(LocationNames.CentralUS);
    customClient.ConnectionPolicy.PreferredLocations.Add(LocationNames.NorthEurope);

    return customClient;
}

[FunctionName("CosmosDbSample")]
public static async Task<HttpResponseMessage> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "foo/{id}")] HttpRequestMessage req,
    string id,
    TraceWriter log)
{
    Uri documentUri = UriFactory.CreateDocumentUri("ToDoList", "Items", id);
    Document doc = await client.ReadDocumentAsync(documentUri);

    if (doc == null)
    {
        return req.CreateResponse(HttpStatusCode.NotFound);
    }

    return req.CreateResponse(HttpStatusCode.OK, doc);
}
```

[!include[](../includes/takeaways-heading.md)]

- The `static` keyword acts as a Singleton, maintaining the same instance for all the executions within a Function's instance.
- You can customize your `DocumentClient` with your own `ConnectionPolicy` requirements.

[!include[](../includes/read-more-heading.md)]

- [Managing connections in Azure Functions](https://github.com/Azure/azure-functions-host/wiki/Managing-Connections)
- [Cosmos DB Performance tips for .NET](https://docs.microsoft.com/azure/cosmos-db/performance-tips)
- [ConnectionPolicy definition](https://docs.microsoft.com/dotnet/api/microsoft.azure.documents.client.connectionpolicy?view=azure-dotnet)