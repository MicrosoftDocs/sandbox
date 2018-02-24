---
title: Azure Functions Recipes - Functions Basics
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

# Basics

[!include[](../includes/header.md)]

| | |
---|---
|<h2>Host.json configuration</h2> | |
[Configuring timeout](hostjson.md#configuring-timeout) | Change the function execution timeout
[Configuring queues](hostjson.md#configuring-queues) | Customize queue trigger properties such as batch size and polling interval
| | |
|<h2>Environment</h2> | |
[Accessing environment variables](environment-variables.md#accessing-environment-variables) | Store and use custom settings
| | |
|<h2>HTTP routing</h2>| |
[Controlling the route prefix with host.json](routes.md#controlling-the-route-prefix-with-hostjson) | Change the route prefix
[Define the function route with function properties](routes.md#define-the-function-route-with-function-properties) | Customize the route of a single Http trigger function in code
[Define the function route in the Azure portal](routes.md#define-the-function-route-in-the-azure-portal) | Customize the route of a single Http trigger function in the Azure portal
[Adding parameters to function routes](routes.md#adding-parameters-to-function-routes) | Define and access parameters in a route
[Making route parameters optional](routes.md#making-route-parameters-optional) | Use optional route parameters
| | |
|<h2>Functions Proxies</h2> | |
[Using proxies.json](proxies.md#using-proxiesjson) | Create and edit proxies.json
[Creating an HTTP Redirect](proxies.md#creating-an-http-redirect) | Use custom HTTP response codes to redirect requests
[Creating a mock API](proxies.md#creating-a-mock-api) | Create a mock API without a backend
[Returning conditional responses based on backend response codes](proxies.md#returning-conditional-responses-based-on-backend-response-codes) | Return different responses based on back-end response codes
[Referencing application settings](proxies.md#referencing-application-settings) | Use environment variables in Proxies
| |
|<h2>Logging and monitoring</h2> | |
[Logging with ILogger](logging.md#logging-with-ilogger) | Use `ILogger` instead of `TraceWriter` for logging
[Basic logging with TraceWriter](logging.md#basic-logging-with-tracewriter) | Basic `TraceWriter` usage
[Logging with a third-party logger](logging.md#logging-with-a-third-party-logger) | Use third-party loggers