---
title: Azure Functions Recipes - Durable Functions
description: Description
author: cecilphillip
manager: scottca
keywords:
ms.topic: article
ms.date: 04/17/2018
ms.author: cephilli
ms.devlang: csharp
ms.service: functions
---

# Durable Functions

[!include[](../includes/header.md)]

| | |
|---|---|
|<h2>Setting up Orchestrations</h2> | |
[Starting Orchestrations](durable-setup.md#starting-orchestrations) | Start a stateful workflow
[Authoring Orchestrator Functions](durable-setup.md#authoring-orchestrator-functions) | Authoring durable orchestrator functions
[Authoring Activity Functions](durable-setup.md#authoring-activity-functions) | Authoring activity functions
|<h2>Managing Orchestrations</h2> | |
[Identifying Instances](durable-manage-orchestrations.md#identifying-instances) | Identifying unique orchestration invocations
[Exposing HTTP Management APIs](durable-manage-orchestrations.md#exposing-http-management-apis) | Manage orchestrations via HTTP
[Inspecting the status of an orchestration](durable-manage-orchestrations.md#inspecting-the-status-of-an-orchestration) | Check the status of an orchestration
[Sending event notifications](durable-manage-orchestrations.md#sending-event-notifications) | Send notifications to running orchestrations
[Terminating a running orchestration instance](durable-manage-orchestrations.md#terminating-a-running-orchestration-instance) | Terminate an orchestration instance
|<h2>Error Handling and Diagnostics</h2> | |
[Logging in orchestrator functions](durable-diagnostics.md#logging-in-orchestrator-functions) | Prevent duplicate logs in orchestrator functions
[Handling activity function exceptions](durable-diagnostics.md#handling-activity-function-exceptions) | Unhandled exceptions in activity functions
[Calling activity function with retry](durable-diagnostics.md#Calling-activity-function-with-retry) | Add retry behavior to activity function calls
