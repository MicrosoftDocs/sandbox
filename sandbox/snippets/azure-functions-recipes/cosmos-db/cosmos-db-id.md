## Retrieve a single document by ID

The Cosmos DB binding can automatically retrieve a document from Cosmos DB and bind it to a parameter. This example uses an `object`. The Cosmos DB binding uses a binding expression (`{id}`) to look up a document from Cosmos DB using the `id` value from the HttpTrigger route.

```csharp
[FunctionName("CosmosDBSample")]
public static HttpResponseMessage Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "foo/{id}")] HttpRequestMessage req,
    [DocumentDB("test", "test", ConnectionStringSetting = "CosmosDB", Id = "{id}")] object document)
{
    if (document == null)
    {
        return req.CreateResponse(HttpStatusCode.NotFound);
    }
    else
    {
        return req.CreateResponse(HttpStatusCode.OK, document);
    }
}
```

[!include[](../includes/takeaways-heading.md)]

- The example uses an `object` parameter, but the binding can work with other types, including: `dynamic`, `string`, `Microsoft.Azure.Documents.Document`, or a strongly-typed object that you create.
- Binding expressions are a powerful feature of Azure Functions that lets you use values and metadata from a trigger binding in other bindings.

[!include[](../includes/read-more-heading.md)]

- [Binding expressions in documentation](https://docs.microsoft.com/azure/azure-functions/functions-triggers-bindings#binding-expressions-and-patterns)
- [Cosmos DB (DocumentDB) binding documentation](https://docs.microsoft.com/azure/azure-functions/functions-bindings-documentdb)