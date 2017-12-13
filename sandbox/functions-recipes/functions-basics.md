---
title: Basics
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
|<h2>Functions basics</h2> | |
|**Host.json configuration** | |
[Configuring timeout](recipes/hostjson.md#configuring-timeout) | Change the function execution timeout
[Configuring queues](recipes/hostjson.md#configuring-queues) | Customize queue trigger properties such as batch size and polling interval
| | |
|**Environment** | |
[Accessing environment variables](recipes/environment-variables.md#accessing-environment-variables) | Store and use custom settings
| | |
|**HTTP routing** | |
[Controlling the route prefix with host.json](recipes/routes.md#controlling-the-route-prefix-with-hostjson) | Change the route prefix
[Define the function route with function properties](recipes/routes.md#define-the-function-route-with-function-properties) | Customize the route of a single Http trigger function in code
[Define the function route in function.json](recipes/routes.md#define-the-function-route-in-functionjson) | Customize the route of a single Http trigger function in function.json
[Define the function route in the Azure portal](recipes/routes.md#define-the-function-route-in-the-azure-portal) | Customize the route of a single Http trigger function in the Azure portal
[Adding parameters to function routes](recipes/routes.md#adding-parameters-to-function-routes) | Define and access parameters in a route
[Making route parameters optional](recipes/routes.md#making-route-parameters-optional) | Use optional route parameters
| | |
|**Functions Proxies** | |
[Using proxies.json](recipes/proxies.md#using-proxiesjson) | Create and edit proxies.json
[Creating an HTTP Redirect](recipes/proxies.md#creating-an-http-redirect) | Use custom HTTP response codes to redirect requests
[Creating a mock API](recipes/proxies.md#creating-a-mock-api) | Create a mock API without a backend
[Returning conditional responses based on backend response codes](recipes/proxies.md#returning-conditional-responses-based-on-backend-response-codes) | Return different responses based on back-end response codes
[Referencing application settings](recipes/proxies.md#referencing-application-settings) | Use environment variables in Proxies
| |
|**Logging and monitoring** | |
[Logging with ILogger](recipes/logging.md#logging-with-ilogger) | Use `ILogger` instead of `TraceWriter` for logging
[Basic logging with TraceWriter](recipes/logging.md#basic-logging-with-tracewriter) | Basic `TraceWriter` usage
[Logging with a third-party logger](recipes/logging.md#logging-with-a-third-party-logger) | Use third-party loggers