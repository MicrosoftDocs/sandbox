---
title: Cool stuff with Azure for game developers
description: Cool stuff with Azure for game developers
author: dgkanatsios
keywords: unity, azure, cosmosdb, functions, appinsights
ms.topic: article
ms.date: 26/01/2018
ms.author: digkanat
#ms.devlang: 
#ms.prod:
#ms.technology:
#ms.service:
---
# Other resources - cool stuff for game development with Azure 

[!include[](../includes/header.md)]

Here you can find various stuff related to Azure for game development including (but not limited to) blog posts, articles, starter kits, source code snippets and more. This page will be regularly updated with more cool stuff we encounter, so feel free to bookmark it and come again later!

## AzureFunctionsNodeLeaderboards-Cosmos

[![Get the source](../media/buttons/source2.png)](https://github.com/dgkanatsios/AzureFunctionsNodeLeaderboards-Cosmos)

This project is a starter kit that allows you to set up a RESTful API service that stores game leaderboards (scores) and exposes them via HTTP(s) methods/operations. A game developer can use this API service in their game and post new scores, get the top scores, find out the latest ones and more. A Unity client is also provided. 

The technology/architecture stack includes an [Express](https://expressjs.com/) [Node.js](https://nodejs.org/) app hosted on an [Azure Function](https://azure.microsoft.com/en-us/services/functions/) that talks to a [Cosmos DB](https://azure.microsoft.com/en-us/services/cosmos-db/) database via its [MongoDB API]((https://docs.microsoft.com/en-us/azure/cosmos-db/mongodb-introduction)). [Azure Application Insights](https://azure.microsoft.com/en-us/services/application-insights/) service is used to provide information and metrics regarding application performance and behavior. A Unity game engine client is also provided, with a relevant Unity C# SDK to access the leaderboards API.

You can check the source code and the relevant documentation on [GitHub](https://github.com/dgkanatsios/AzureFunctionsNodeLeaderboards-Cosmos) and read the relevant blog post [here](https://dgkanatsios.com/2018/01/12/using-azure-functions-and-cosmos-db-to-create-a-game-leaderboard/).