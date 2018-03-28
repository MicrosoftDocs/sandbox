## Save multiple documents to a collection

The `IAsyncCollector` lets you save multiple documents within one execution of your Function.

```csharp
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

public class MyClass
{
    public string id { get; set; }
    public string name { get; set; }
}

[FunctionName("CosmosDbSample")]
public static async Task<HttpResponseMessage> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]MyClass[] classes,
    TraceWriter log,
    [DocumentDB("ToDoList", "Items", ConnectionStringSetting = "CosmosDB")] IAsyncCollector<MyClass> documentsToStore)
{
    log.Info($"Detected {classes.Length} incoming documents");
    foreach (MyClass aClass in classes)
    {
        await documentsToStore.AddAsync(aClass);
    }

    return new HttpResponseMessage(HttpStatusCode.Created);
}
```

[!include[](../includes/takeaways-heading.md)]

- The `IAsyncCollector` can be used with a class or also with `dynamic` (as in `IAsyncCollection<dynamic>`).
- When `AddAsync` is called, the document is saved, so if you want to implement any error-handling logic, that is the correct spot for a try/catch.

[!include[](../includes/read-more-heading.md)]

- [Cosmos DB (DocumentDB) Output binding documentation](https://docs.microsoft.com/azure/azure-functions/functions-bindings-cosmosdb#output---attributes)