---
title: Azure Functions Recipes - Triggers and bindings
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
|---|---|
|<h2>Cosmos DB</h2> | |
[Retrieve a single document by ID](cosmos-db.md#retrieve-a-single-document-by-id) | Retrieve a single document with an input binding
[Save multiple documents to a collection](cosmos-db.md#save-multiple-documents-to-a-collection) | Saving multiple documents
[Trigger a function based on changes in Cosmos DB](cosmos-db.md#trigger-a-function-based-on-changes-in-cosmos-db) | Use the change feed to trigger a function
[Retrieve a list of documents](cosmos-db.md#retrieve-a-list-of-documents) | Retrieve a list of documents with an input binding
[Using DocumentClient](cosmos-db.md#using-documentclient) | Run complex queries with `DocumentClient`
[Customize a DocumentClient and reuse it between executions](cosmos-db.md#customize-a-documentclient-and-reuse-it-between-executions) | Create a customized and shared `DocumentClient` instance
|<h2>HTTP and webhooks</h2> | |
[Accessing query string values in HTTP Triggers](http-and-webhooks.md#accessing-query-string-values-in-http-triggers) | Read query string parameters
[Accessing the request body in HTTP Triggers](http-and-webhooks.md#accessing-the-request-body--in-http-triggers) | Read the contents of the request body
[Restricting HTTP verbs in HTTP Triggers](http-and-webhooks.md#restricting-http-verbs-in-http-triggers) | Restrict the HTTP verbs that trigger a function
[Securing HTTP Triggers with security keys](http-and-webhooks.md#securing-http-triggers-with-security-keys) | Use keys to lock down an HTTP trigger function
[GitHub comment webhook](http-and-webhooks.md#github-comment-webhook) | Respond to GitHub webhooks
|<h2>Manual trigger</h2> | |
[Manual C# function](manual.md#manual-c-function) | Create a function that is triggered manually
|<h2>Queue storage</h2> | |
[Triggering via Azure Storage Queue](queue-storage.md#triggering-via-azure-storage-queue) | Trigger a function when a queue message arrives
[Azure Storage Queue Trigger using a POCO](queue-storage.md#azure-storage-queue-trigger-using-a-poco) | Bind queue messages to a custom object
[Retrieving queue metadata from an Azure Storage Queue Trigger](queue-storage.md#retrieving-queue-metadata-from-an-azure-storage-queue-trigger) | Access metadata of a queue message
[Poison queue messages with Azure Storage Queue Triggers](queue-storage.md#poison-queue-messages-with-azure-storage-queue-triggers) | Handle poison messages
[Azure Storage Queue output binding](queue-storage.md#azure-storage-queue-output-binding) | Use basic queue output bindings
[Using ICollector with Azure Storage Queue bindings](queue-storage.md#using-icollector-with-azure-storage-queue-bindings) | Use `ICollector` and `IAsyncCollector` with queue output bindings
|<h2>Service Bus</h2> | |
[Triggering functions from Azure Service Bus queues and topics](service-bus.md#triggering-functions-from-azure-service-bus-queues-and-topics) | Trigger a function with messages from Service Bus queues and topics
[Using ICollector with Service Bus queue bindings](service-bus.md#using-icollector-with-service-bus-queue-bindings) | Send multiple messages to Service Bus queues with `ICollector` or `IAsyncCollector`
[Retrieving queue metadata from an Azure Service Bus queue/topic trigger](service-bus.md#retrieving-queue-metadata-from-an-azure-service-bus-queuetopic-trigger) | Get metadata of queue messages from the Service Bus trigger
[Azure Service Bus output binding](service-bus.md#azure-service-bus-output-binding) | Send messages to Service Bus queues and topics
|<h2>Table storage</h2> | |
[Table storage input binding](table-storage.md#table-storage-input-binding) | Use the Table storage input binding
|<h2>Timer</h2> | |
[Timer trigger function](timer.md#timer-trigger-function) | Trigger a function on a schedule