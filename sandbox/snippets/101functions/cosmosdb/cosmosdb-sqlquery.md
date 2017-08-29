## Retrieve a list of documents

The Cosmos DB binding can automatically retrieve a list of documents from Cosmos DB and bind it to a parameter. The `sqlQuery` property of the binding is used to specify a query to use to retrieve the documents. This example demonstrates how to select the 5 most recent documents from the collection as determined by the `_ts` timestamp property.

```csharp
[FunctionName("CosmosDBSample")]
public static HttpResponseMessage Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestMessage req,
    [DocumentDB("test", "test", ConnectionStringSetting = "CosmosDB", sqlQuery = "SELECT top 2 * FROM c order by c._ts desc")] IEnumerable<object> documents)
{
    return req.CreateResponse(HttpStatusCode.OK, documents);
}
```

[!include[](../includes/takeaways-heading.md)]

- To use the Cosmos DB input binding's `sqlQuery` property, you must bind it to an `IEnumerable<T>` or a type that implements `IEnumerable<T>`.

[!include[](../includes/read-more-heading.md)]

- [Cosmos DB (DocumentDB) binding documentation](https://docs.microsoft.com/azure/azure-functions/functions-bindings-documentdb)