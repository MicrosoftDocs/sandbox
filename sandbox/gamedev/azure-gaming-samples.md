---
title: Azure Gaming Samples
description: Sample projects for Azure Gaming scenarios
author: BrianPeek
manager: timheuer
keywords: azure, unity, gaming
ms.topic: article
ms.date: 6/15/2018
ms.author: brpeek
#ms.devlang: 
#ms.prod:
#ms.technology:
#ms.service:
---
# Azure Gaming Samples

There are many samples that demonstrate a variety of gaming scenarios using Azure.  We have collected some of these samples below.

## Scavenger

[![Get the source](../media/buttons/source2.png)](https://aka.ms/scavenger)

Scavenger is a virutal scavenger hunt game written in Unity.  Each day players are presented with a list of items to take a photo of.  If the Computer Vision API determines the photo contains the required object, a point is awarded. The game demonstrates usage of various Azure services:

* [Cognitive Services](https://aka.ms/cogdocs-scavenger)
* [Azure Functions](https://aka.ms/afdocs-scavenger)
* [Cosmos DB](https://aka.ms/cosdocs-scavenger)
* [PlayFab](https://playfab.com/)

For more information, check out the linked GitHub repo, and watch the [session recording](https://www.youtube.com/watch?v=xyZyjXluIV4) from Build.

## Multiplayer Scaling with Azure Container Instances

[![Get the source](../media/buttons/source2.png)](https://aka.ms/acimultiplayersample)

This project allows you to manage Docker containers running on [Azure Container Instances](https://azure.microsoft.com/en-us/services/container-instances/).
Suppose that you want to manage a series of running Docker containers. These containers may be stateful, so classic scaling methods (via Load Balancers etc.) would not work. A classic example is multiplayer game servers, where its server has its own connections to game clients, its own state etc. Another example would be batch-style projects, where each instance would have to deal with a separate set of data. For these kind of purposes, you would need a set of Docker containers being created on demand and deleted when their job is done and they are no longer needed in order to save costs.

For more information, check out the linked GitHub repo, and watch the [session recording](https://www.youtube.com/watch?v=DVwqi0JHNbI) from Build.

## Leaderboards with Azure Functions, Node, and Cosmos DB

[![Get the source](../media/buttons/source2.png)](https://aka.ms/azleaderboardsample)

This project is a starter kit that allows you to set up a RESTful API service that stores game leaderboards (scores) and exposes them via HTTP(s) methods/operations. A game developer can use this API service in their game and post new scores, get the top scores, find out the latest ones and more. Additionally, a Unity sample client is included in the project. 

The technology/architecture stack includes an [Express](https://expressjs.com/) [Node.js](https://nodejs.org/) app hosted on an [Azure Function](https://azure.microsoft.com/en-us/services/functions/) that talks to a [Cosmos DB](https://azure.microsoft.com/en-us/services/cosmos-db/) database via its [MongoDB API]((https://docs.microsoft.com/en-us/azure/cosmos-db/mongodb-introduction)). [Azure Application Insights](https://azure.microsoft.com/en-us/services/application-insights/) service is used to provide information and metrics regarding application performance and behavior. A Unity game engine client is also provided, with a relevant Unity C# SDK to access the leaderboards API.

You can check the source code and the relevant documentation on [GitHub](https://github.com/dgkanatsios/AzureFunctionsNodeLeaderboards-Cosmos) and read the relevant blog post [here](https://dgkanatsios.com/2018/01/12/using-azure-functions-and-cosmos-db-to-create-a-game-leaderboard/).

## Analytics with Event Hubs, Azure Functions, Cosmos DB, and Datalake

[![Get the source](../media/buttons/source2.png)](https://aka.ms/azanalyticssample)

A simple architecture to consume and process messages coming from video game clients (or servers) using the following Azure services:

* [Event Hubs](https://docs.microsoft.com/azure/event-hubs/)
* [Functions](https://docs.microsoft.com/azure/azure-functions/)
* [Cosmos DB](https://aka.ms/cosdocs-scavenger)
* [Data Lake Store](https://docs.microsoft.com/azure/data-lake-store/)
* [Data Lake Analytics](https://docs.microsoft.com/azure/data-lake-analytics/)
