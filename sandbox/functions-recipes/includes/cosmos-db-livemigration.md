## Trigger a Function based on changes in Cosmos DB

You can trigger a Function based on changes in your Cosmos DB collections. In this sample we are sending the changes to a second collection using the `IAsyncCollection` explained in [this other recipe](./cosmos-db-outputcollector.md). You could process or work with the documents before sending it to the second collection.

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

[FunctionName("CosmosDbSample")]
public static async Task Run(
    [CosmosDBTrigger("ToDoList","Items", ConnectionStringSetting = "CosmosDB")] IReadOnlyList<Document> documents,
    TraceWriter log,
    [DocumentDB("ToDoList", "Migration", ConnectionStringSetting = "CosmosDB", CreateIfNotExists = true)] IAsyncCollector<Document> documentsToStore)
{
    foreach (var doc in documents)
    {
        log.Info($"Processing document with Id {doc.Id}");
        // work with the document, process or create a new one
        await documentsToStore.AddAsync(doc);
    }
}
```

[!include[](../includes/takeaways-heading.md)]

- The Trigger leverages the **Change Feed** feature in Cosmos DB and will trigger the Function on any insert or update (no deletes supported at the moment).
- In order to use the Trigger, you need to have a second collection to store the checkpoint **leases** generated during the iteration of the Change Feed. You can customize the **leases** collection name and account on the `CosmosDBTrigger` attribute.

[!include[](../includes/read-more-heading.md)]

- [Serverless database compute using Azure Functions](https://docs.microsoft.com/azure/cosmos-db/serverless-computing-database)
- [Working with the Change Feed support](https://docs.microsoft.com/azure/cosmos-db/change-feed)
- [Cosmos DB Trigger in Azure Functions](https://docs.microsoft.com/azure/azure-functions/functions-bindings-cosmosdb#trigger)