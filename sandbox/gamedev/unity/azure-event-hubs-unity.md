---
title: Azure Event Hubs SDK for Unity
description: Azure Event Hubs SDK for Unity
author: BrianPeek
manager: timheuer
keywords: unity, azure, eventhubs
ms.topic: article
ms.date: 10/20/2018
ms.author: brpeek
---
# Azure Event Hubs SDK for Unity

[!include[](../../includes/header.md)]

## Azure Event Hubs for Gaming

Azure Event Hubs is a real-time custom event ingestion service that can collect and store millions of events per second. Events can then be analyzed in real-time using [Azure Stream Analytics](https://azure.microsoft.com/en-us/services/stream-analytics/) or stored to [Azure Storage](https://azure.microsoft.com/en-us/services/storage/) or [Azure Data Lake Store](https://azure.microsoft.com/en-us/services/data-lake-store/) for processing at a later time. Analysis of this data could reveal various insights about player's performance/behavior during the game as well as be utilized in creation of other types of metrics (e.g. daily/weekly/monthly active users, churn, user sessions, transactions etc.).

> [!IMPORTANT]
> This is an experimental Unity SDK for Azure Event Hubs.  As such, please note that this SDK is not supported and is not provided by the Azure Event Hubs team.  If you run into problems, please let us know using the [GitHub Issues](https://aka.ms/azsdks-unity-issues) page for the SDK.

[![Get the source](../../media/buttons/source2.png)](https://aka.ms/azsdks-unity)
[![Try it now](../../media/buttons/try2.png)](https://aka.ms/azeventhubs-unitysdk)

## Requirements

* [Unity 2018.1 (or greater)](https://unity3d.com/)
  * Unity 2018.2 (or greater) is required for proper SSL support.
  * If you are using Unity 2017, please check out our [Unity 2017 SDK](./azure-event-hubs-unity-2017.md).
* [An Azure Event Hubs account (Sign up for free!)](https://aka.ms/azfreegamedev)

## Compatibility

This has been tested with the following Unity exporters.  Others wil likely work, however we haven't tested every possible platform and combination.  Please let us know if you've had success!

* Windows/Mac Standalone
* iOS
* Android
* UWP (IL2CPP)
* Unity Editor

## Import the SDK

To import the SDK into your own project, make sure you have downloaded the latest [.unitypackage](https://aka.ms/azeventhubs-unitysdk) from GitHub.  Then, do the following:

[!include[](include/unity-import.md)]

Please refer to the [Azure Event Hubs Docs](https://docs.microsoft.com/en-us/azure/event-hubs/) for even more samples and tutorials on using the API.

## Unity 2018.1 and SSL support

Due to a Unity 2018.1 limitation (fixed in 2018.2), HTTPS requests using the standard .NET networking stack (i.e. not using UnityWebRequest) will fail due to Mono's empty certificate store. To workaround this, you will need to setup a **ServicePointManager.ServerCertificateValidationCallback** property that returns `true` as shown below.  **This means that data transfer will happen in an insecure manner.**  We highly recommend upgrading your project to Unity 2018.2 if possible.

```csharp
System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, error) => { return true; };
```

## Try the Sample

To use the sample, you will need to have an Azure Event Hubs account with a valid Event Hubs connection string. You'll also need to create an event hub on this account. You can check the Event Hubs documentation [here](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-create) to understand how to complete this task.

To use the sample, do the following:

1. Download the [Unity SDKs repo](https://aka.ms/azsdks-unity) from GitHub (or import it from the .unitypackage and continue to step 4).

1. Unzip to a location on your hard drive.

1. Open Unity 2018.1 (or greater) and point it to the **EventHubs** directory inside the unzipped package.

1. In the **Project** window, double-click the **EventHub** scene inside the **Assets\AzureSamples\EventHubs** directory to open the main scene for the sample.

1. In this scene, select the **EventHubsObject** item in the **Hierarchy** window.

1. With **EventHubsObject** selected, you'll notice that there are two blank entries in the **Inspector** window, called **Eh Connection String** and **Eh Entity Path**. Fill in these entries with your own Event Hubs connection string and Event Hub name, respectively. You can find them both in the Azure Portal as shown below.

   ![Event Hubs connection string in Azure Portal](../media/event-hubs-connectionstring.png)

   ![Creating an Event Hub in Azure Portal](../media/event-hubs-name.png)

1. Run the project from within the Unity Editor by clicking the **Play** button.  Alternatively, you can export to the platform of your choosing and run there.

1. To test that the events you are sending are correctly arriving to your Event Hubs account, you can use [Event Hubs capture](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-capture-enable-through-portal) and monitor your Storage/Data Lake Store account. Alternatively, you can create a simple .NET console app with a class that implements the **IEventProcessor** interface, like the one described [here](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-dotnet-standard-getstarted-receive-eph).

## Next Steps

* [Azure Event Hubs Docs](https://docs.microsoft.com/en-us/azure/event-hubs/)
* [Event Hubs as input to Azure Stream Analytics](https://docs.microsoft.com/en-us/azure/stream-analytics/stream-analytics-define-inputs)
* [Capture Event Hubs data to Azure Storage or Azure Data Lake Store](https://docs.microsoft.com/en-us/azure/event-hubs/event-hubs-capture-enable-through-portal)
* [Azure Data Lake Store documentation](https://docs.microsoft.com/en-us/azure/data-lake-store/)
