---
title: Your Project Name
description: Your Project Description
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
    var collectionUri = UriFactory.CreateDocumentCollectionUri("mydb", "mycollection");

    var query = client.CreateDocumentQuery<Person>(collectionUri)
        .Where(p => p.Age >= minAge)
        .AsDocumentQuery();

    while (query.HasMoreResults)  
    {
        foreach (var result in await query.ExecuteNextAsync())
        {
            log.Info(result.Age.ToString());
        }
    }
}
```

For more information about this topic, see [the documentation](https://msdn.microsoft.com/library/azure/microsoft.azure.documents.client.documentclient.aspx).
