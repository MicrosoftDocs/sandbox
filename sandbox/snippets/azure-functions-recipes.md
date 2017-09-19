---
title: Azure Functions Recipes
description: Azure Functions Recipes
author: anthonychu
manager: scottca
keywords: 
ms.topic: article
ms.date: 01/01/2017
ms.author: antchu
#ms.devlang: 
#ms.prod:
#ms.technology:
#ms.service:
---

[!include[](../includes/header.md)]

# Functions Recipes

## Functions Basics

### Host.json basics
* [Configuring timeout](azure-functions-recipes/hostjson.md#configuring-timeout)
* [Configuring queues](azure-functions-recipes/hostjson.md#configuring-queues)

### Environment
* [Accessing environment variables](azure-functions-recipes/environment-variables.md#accessing-environment-variables)

### HTTP routing
* [Controlling the route prefix with host.json](azure-functions-recipes/routes.md#controlling-the-route-prefix-with-hostjson)
* [Define the function route with function properties](azure-functions-recipes/routes.md#define-the-function-route-with-function-properties)
* [Define the function route in function.json](azure-functions-recipes/routes.md#define-the-function-route-in-functionjson)
* [Define the function route in the Azure Portal](azure-functions-recipes/routes.md#define-the-function-route-in-the-azure-portal)
* [Adding parameters to function routes](azure-functions-recipes/routes.md#adding-parameters-to-function-routes)
* [Making route parameters optional](azure-functions-recipes/routes.md#making-route-parameters-optional)

### Proxies
* [Using proxies.json](azure-functions-recipes/proxies.md#using-proxiesjson)
* [Creating an HTTP Redirect](azure-functions-recipes/proxies.md#creating-an-http-redirect)
* [Creating a mock API](azure-functions-recipes/proxies.md#creating-a-mock-api)
* [Returning conditional responses based on backend response codes](azure-functions-recipes/proxies.md#returning-conditional-responses-based-on-backend-response-codes)
* [Referencing application settings](azure-functions-recipes/proxies.md#referencing-application-settings)

### Logging and monitoring
* [Logging with ILogger](azure-functions-recipes/logging.md#logging-with-ilogger)
* [Basic logging with TraceWriter](azure-functions-recipes/logging.md#basic-logging-with-tracewriter)
* [Logging with a third party logger](azure-functions-recipes/logging.md#logging-with-a-third-party-logger)


## Triggers and bindings

### Blob storage
* [Blob trigger function](azure-functions-recipes/blob-storage.md#blob-trigger-function)

### Cosmos DB
* [Using DocumentClient](azure-functions-recipes/cosmos-db.md#using-documentclient)
* [Retrieve a single document by ID](azure-functions-recipes/cosmos-db.md#retrieve-a-single-document-by-id)
* [Retrieve a list of documents](azure-functions-recipes/cosmos-db.md#retrieve-a-list-of-documents)

### HTTP and webhooks
* [Accessing query string values in Http Triggers](azure-functions-recipes/http.md#accessing-query-string-values-in-http-triggers)
* [Accessing the request body in HTTP Triggers](azure-functions-recipes/http.md#accessing-the-request-body--in-http-triggers)
* [Restricting HTTP verbs in HTTP Triggers](azure-functions-recipes/http.md#restricting-http-verbs-in-http-triggers)
* [Securing HTTP Triggers with security keys](azure-functions-recipes/http.md#securing-http-triggers-with-security-keys)
* [Generic webhook function](azure-functions-recipes/http.md#generic-webhook-function)
* [GitHub comment webhook](azure-functions-recipes/http.md#github-comment-webhook)

### Manual trigger
* [Manual C# function](azure-functions-recipes/manual.md#manual-c-function)

### Queue storage
* [Triggering via Azure Storage Queue](azure-functions-recipes/queue-storage.md#triggering-via-azure-storage-queue)
* [Azure Storage Queue Trigger using a POCO](azure-functions-recipes/queue-storage.md#azure-storage-queue-trigger-using-a-poco)
* [Retrieving queue metadata from an Azure Storage Queue Trigger](azure-functions-recipes/queue-storage.md#retrieving-queue-metadata-from-an-azure-storage-queue-trigger)
* [Poison queue messages with Azure Storage Queue Triggers](azure-functions-recipes/queue-storage.md#poison-queue-messages-with-azure-storage-queue-triggers)
* [Azure Storage Queue output binding](azure-functions-recipes/queue-storage.md#azure-storage-queue-output-binding)
* [Using ICollector with Azure Storage Queue bindings](azure-functions-recipes/queue-storage.md#using-icollector-with-azure-storage-queue-bindings)

### Table storage
* [Table storage trigger function](azure-functions-recipes/table-storage.md#table-storage-trigger-function)

### Timer
* [Timer trigger function](azure-functions-recipes/timer.md#timer-trigger-function)


## Coding Environment

### Portal
* [Working with Functions in the Azure Portal](azure-functions-recipes/portal.md#working-with-functions-in-the-azure-portal)
* [Allowing HTTP verbs in the Azure Portal](azure-functions-recipes/portal.md#allowing-http-verbs-in-the-azure-portal)
* [Getting your function and host keys in the Azure Portal](azure-functions-recipes/portal.md#getting-your-function-and-host-keys-in-the-azure-portal)
* [Controlling how much your function can run in one day](azure-functions-recipes/portal.md#controlling-how-much-your-function-can-run-in-one-day)

### Visual Studio
* [Installing Visual Studio Functions Tools](azure-functions-recipes/visual-studio.md#installing-visual-studio-functions-tools)

### Visual Studio Code
* [Installing Visual Studio Code Functions Tools](azure-functions-recipes/vscode.md#installing-visual-studio-code-functions-tools)

### CLI
* [Testing functions with Azure Functions Command Line Tools](azure-functions-recipes/cli.md#testing-functions-with-azure-functions-command-line-tools)
* [Publishing a function locally](azure-functions-recipes/cli.md#publishing-a-function-locally)
