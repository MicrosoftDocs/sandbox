---
title: Azure Functions Cosmos DB Tips
description: 101 Azure Functions
author: githubusername
manager: alias
keywords: 
ms.topic: article
ms.date: 01/01/2017
ms.author: alias
#ms.devlang: 
#ms.prod:
#ms.technology:
#ms.service:
---

[!include[](~/includes/header.md)]
# Cosmos DB (DocumentDB) Binding Samples

## Using DocumentClient

If you have complex queries that are not supported by `id` and `sqlQuery` of the Cosmos DB input binding, you can use the `DocumentClient` directly.

> [!TIP]
> For best performance, do not create your own instance of `DocumentClient`. Use the one provided by the Functions runtime as an input parameter.

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

For more information about this topic, see [the documentation](https://msdn.microsoft.com/library/azure/microsoft.azure.documents.client.documentclient.aspx) for `DocumentClient`.

## Retrieve a single document by ID

The Cosmos DB binding can automatically retrieve a document from Cosmos DB and bind it to an object. Note the example uses `object`, but it can bind to other types, including: `dynamic`, `string`, `Microsoft.Azure.Documents.Document`, or a strongly-typed object that you create.

```csharp
[FunctionName("CosmosDBSample")]
public static HttpResponseMessage Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "foo/{id}")] HttpRequestMessage req,
    [DocumentDB("test", "test", ConnectionStringSetting = "CosmosDB", Id = "{id}")] Document document)
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

- 

[!include[](../includes/read-more-heading.md)]

- Read more stuff here!
- and here!
