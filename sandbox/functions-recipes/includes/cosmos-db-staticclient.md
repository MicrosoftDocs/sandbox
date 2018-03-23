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


private static string endpointUrl = ConfigurationManager.AppSettings["CosmosDBAccountEndpoint"];
private static string authorizationKey = ConfigurationManager.AppSettings["CosmosDBAccountKey"];
private static DocumentClient client = new DocumentClient(new Uri(endpointUrl), authorizationKey);


[FunctionName("CosmosDbSample")]
public static async Task<HttpResponseMessage> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequestMessage req,
    TraceWriter log)
{
    string id = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "id", true) == 0)
        .Value;

    if (string.IsNullOrEmpty(id))
    {
        return req.CreateResponse(HttpStatusCode.BadRequest);
    }

    Uri documentUri = UriFactory.CreateDocumentUri("datacamp", "test", id);
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

- [Cosmos DB Performance tips for .NET](https://docs.microsoft.com/azure/cosmos-db/performance-tips)
- [ConnectionPolicy definition](https://docs.microsoft.com/dotnet/api/microsoft.azure.documents.client.connectionpolicy?view=azure-dotnet)