---
title: Triggers and bindings
description: Description
author: CecilPhillip
manager: scottca
keywords:
ms.topic: article
ms.date: 12/11/2017
ms.author: cephilli
ms.devlang: csharp
ms.service: functions
---

# Triggers and bindings

[!include[](../includes/header.md)]


| | |
---|---
|<h2>Triggers and bindings</h2> | |
|**Blob storage** | |
[Blob trigger function](recipes/blob-storage.md#blob-trigger-function) | Trigger a function when a blob is created
| | |
|**Cosmos DB** | |
[Using DocumentClient](recipes/cosmos-db.md#using-documentclient) | Run complex queries with `DocumentClient`
[Retrieve a single document by ID](recipes/cosmos-db.md#retrieve-a-single-document-by-id) | Retrieve a single document with an input binding
[Retrieve a list of documents](recipes/cosmos-db.md#retrieve-a-list-of-documents) | Retrieve a list of documents with an input binding
| | |
|**HTTP and webhooks** | |
[Accessing query string values in Http Triggers](recipes/http.md#accessing-query-string-values-in-http-triggers) | Read query string parameters
[Accessing the request body in HTTP Triggers](recipes/http.md#accessing-the-request-body--in-http-triggers) | Read the contents of the request body
[Restricting HTTP verbs in HTTP Triggers](recipes/http.md#restricting-http-verbs-in-http-triggers) | Restrict the HTTP verbs that trigger a function
[Securing HTTP Triggers with security keys](recipes/http.md#securing-http-triggers-with-security-keys) | Use keys to lock down an HTTP trigger function
[Generic webhook function](recipes/http.md#generic-webhook-function) | Respond to generic webhooks
[GitHub comment webhook](recipes/http.md#github-comment-webhook) | Respond to GitHub webhooks
| | |
|**Manual trigger** | |
[Manual C# function](recipes/manual.md#manual-c-function) | Create a function that is triggered manually
| | |
|**Queue storage** | |
[Triggering via Azure Storage Queue](recipes/queue-storage.md#triggering-via-azure-storage-queue) | Trigger a function when a queue message arrives
[Azure Storage Queue Trigger using a POCO](recipes/queue-storage.md#azure-storage-queue-trigger-using-a-poco) | Bind queue messages to a custom object
[Retrieving queue metadata from an Azure Storage Queue Trigger](recipes/queue-storage.md#retrieving-queue-metadata-from-an-azure-storage-queue-trigger) | Access metadata of a queue message
[Poison queue messages with Azure Storage Queue Triggers](recipes/queue-storage.md#poison-queue-messages-with-azure-storage-queue-triggers) | Handle poison messages
[Azure Storage Queue output binding](recipes/queue-storage.md#azure-storage-queue-output-binding) | Use basic queue output bindings
[Using ICollector with Azure Storage Queue bindings](recipes/queue-storage.md#using-icollector-with-azure-storage-queue-bindings) | Use `ICollector` and `IAsyncCollector` with queue output bindings
| | |
|**Service Bus** | |
[Triggering functions from Azure Service Bus queues and topics](recipes/service-bus.md#triggering-functions-from-azure-service-bus-queues-and-topics) | Trigger a function with messages from Service Bus queues and topics
[Using ICollector with Service Bus queue bindings](recipes/service-bus.md#using-icollector-with-service-bus-queue-bindings) | Send multiple messages to Service Bus queues with `ICollector` or `IAsyncCollector`
[Retrieving queue metadata from an Azure Service Bus queue/topic trigger](recipes/service-bus.md#retrieving-queue-metadata-from-an-azure-service-bus-queuetopic-trigger) | Get metadata of queue messages from the Service Bus trigger
[Azure Service Bus output binding](recipes/service-bus.md#azure-service-bus-output-binding) | Send messages to Service Bus queues and topics
| | |
|**Table storage** | |
[Table storage input binding](recipes/table-storage.md#table-storage-input-binding) | Use the Table storage input binding
| | |
|**Timer** | |
[Timer trigger function](recipes/timer.md#timer-trigger-function) | Trigger a function on a schedule