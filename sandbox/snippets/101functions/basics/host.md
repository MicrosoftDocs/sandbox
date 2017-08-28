---
title: Host.json schema basic tips
description: Tips about the schema of host.json
author: MaximRouiller
manager: scottca
keywords: 
ms.topic: article
ms.date: 08/25/2017
ms.author: marouill
#ms.devlang: 
#ms.prod:
#ms.technology:
#ms.service:
---

## Host.json basics

At the root of an application is a metadata file that describes the global configuration of the host serving the different functions.

### Configuring timeout

Timeouts allow the host to determine when the function will timeout.

On a Consumption plan, the valid values are between 1 second (`00:00:01`) and 10 minutes (`00:10:00`). On an App Service Plan, any interval can be used including null. Setting it to null will have it wait indefinitely.

```json
{
    "functionTimeout": "00:05:00"
}
```

### Configuring queues

Functions that depends on queues can have the behavior of the queues customized. 

Among the different possibilities, it's possible to set a polling interval, retry interval as well as the size of the batch of messages to process in parrallel.


```json
{
    // Interval in milliseconds
    "maxPollingInterval": 2000,
    // Time between calls/retries
    "visibilityTimeout": "00:00:30",
    //Maximum of 32
    "batchSize": 16
}
```

### Read more

For the full range of options, look-up the [complete documentation of host.json](https://github.com/Azure/azure-webjobs-sdk-script/wiki/host.json).