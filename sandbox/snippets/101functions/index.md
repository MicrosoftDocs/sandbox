---
title: 101 Azure Functions
description: 101 Azure Functions
author: githubusername
manager: scottca
keywords: 
ms.topic: article
ms.date: 01/01/2017
ms.author: alias
#ms.devlang: 
#ms.prod:
#ms.technology:
#ms.service:
---

[!include[](../../includes/header.md)]

# Here are 101 Functions!

## Functions Basics

### Host.json basics
* [Configuring timeout](hostjson/#configuring-timeout)
* [Configuring queues](hostjson/#configuring-queues)

### Authentication

### Environment
* [Accessing environment variables](environment-variables/#accessing-environment-variables)

### HTTP routing
* [Controlling the route prefix with host.json](routes/#controlling-the-route-prefix-with-hostjson)
* [Define the function route with function properties](routes/#define-the-function-route-with-function-properties)
* [Define the function route in function.json](routes/#define-the-function-route-in-functionjson)
* [Define the function route in the Azure Portal](routes/#define-the-function-route-in-the-azure-portal)
* [Adding parameters to function routes](routes/#adding-parameters-to-function-routes)
* [Making route parameters optional](routes/#making-route-parameters-optional)

### Proxies

### Logging and monitoring
* [Logging with ILogger](logging/#logging-with-ilogger)
* [Basic logging with TraceWriter](logging/#basic-logging-with-tracewriter)
* [Logging with a third party logger](logging/#logging-with-a-third-party-logger)

### Testing

### Exception handling

### OpenAPI 2.0 (Swagger)


## Triggers and bindings

### Blob storage
* [Blob trigger function](blob-storage/#blob-trigger-function)

### Cosmos DB
* [Using DocumentClient](cosmosdb/#using-documentclient)
* [Retrieve a single document by ID](cosmosdb/#retrieve-a-single-document-by-id)
* [Retrieve a list of documents](cosmosdb/#retrieve-a-list-of-documents)

### Event Hubs

### External file

### External table

### HTTP and webhooks
* [Accessing query string values in Http Triggers](http/#accessing-query-string-values-in-http-triggers)
* [Accessing the request body in HTTP Triggers](http/#accessing-the-request-body--in-http-triggers)
* [Restricting HTTP verbs in in HTTP Triggers](http/#restricting-http-verbs-in-in-http-triggers)
* [Securing HTTP Triggers with security keys](http/#securing-http-triggers-with-security-keys)
* [Generic webhook function](http/#generic-webhook-function)
* [GitHub comment webhook](http/#github-comment-webhook)

### Manual trigger
* [Manual C# function](manual/#manual-c-function)

### Mobile Apps

### Notification Hubs

### Queue storage
* [Triggering via Azure Storage Queue](queue-storage/#triggering-via-azure-storage-queue)
* [Azure Storage Queue Trigger using a POCO](queue-storage/#azure-storage-queue-trigger-using-a-poco)
* [Retrieving queue metadata from an Azure Storage Queue Trigger](queue-storage/#retrieving-queue-metadata-from-an-azure-storage-queue-trigger)
* [Poison queue messages with Azure Storage Queue Triggers](queue-storage/#poison-queue-messages-with-azure-storage-queue-triggers)
* [Azure Storage Queue output binding](queue-storage/#azure-storage-queue-output-binding)
* [Using ICollector with Azure Storage Queue bindings](queue-storage/#using-icollector-with-azure-storage-queue-bindings)

### SendGrid

### Service Bus

### Table storage
* [Table storage trigger function](table-storage/#table-storage-trigger-function)

### Timer
* [Timer trigger function](timer/#timer-trigger-function)

### Twilio


## Coding Environment

### Visual Studio

### VS Code

### Functions CLI

### Portal


## Continuous Integration/Deployment

### GitHub

### VSTS

