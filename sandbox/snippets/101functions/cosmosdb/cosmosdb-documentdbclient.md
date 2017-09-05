## Using DocumentClient

If you have complex queries that are not supported by `id` and `sqlQuery` of the Cosmos DB input binding, you can use the `DocumentClient` directly.

```csharp
#r "Microsoft.Azure.Documents.Client"
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

public static async Task<HttpResponseMessage> Run(
    HttpRequestMessage req, DocumentClient client, int minAge, TraceWriter log)
{
    Uri collectionUri = UriFactory.CreateDocumentCollectionUri("mydb", "mycollection");

    IDocumentQuery<Person> query = client.CreateDocumentQuery<Person>(collectionUri)
        .Where(p => p.Age >= minAge)
        .AsDocumentQuery();

    while (query.HasMoreResults)  
    {
        foreach (Person result in await query.ExecuteNextAsync())
        {
            log.Info(result.Age.ToString());
        }
    }
}
```

[!include[](../includes/takeaways-heading.md)]

- Use the `DocumentClient` directly to interact with Cosmos DB if `id` and `sqlQuery` in the binding are not enough for your needs.
- For best performance, do not create your own instance of `DocumentClient`. Use the one provided by the Functions runtime as an input parameter. 

[!include[](../includes/read-more-heading.md)]

- [`DocumentClient` documentation](https://msdn.microsoft.com/library/azure/microsoft.azure.documents.client.documentclient.aspx)