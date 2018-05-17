---
title: Computer Vision API SDK for Unity
description: Computer Vision API SDK for Unity
author: BrianPeek
manager: timheuer
keywords: unity, cognitive services, vision, vision api
ms.topic: article
ms.date: 05/03/2018
ms.author: brpeek
---

::: moniker range=">= unity-2017.1"
Unity 2017.1
::: moniker-end

::: moniker range=">= unity-2018.1"
Unity 2018.1
::: moniker-end

# Computer Vision API SDK for Unity

[!include[](../../includes/header.md)]

> [!IMPORTANT]
> This is an experimental Unity SDK for the Computer Vision API.  As such, please note that this SDK is not supported and is not provided by the Computer Vision API team.  If you run into problems, please let us know using the [GitHub Issues](https://github.com/BrianPeek/azure-storage-net/issues) page for this fork.

[![Get the source](../../media/buttons/source2.png)](https://github.com/BrianPeek/azure-storage-net/tree/gamedev)
[![Try it now](../../media/buttons/try2.png)](https://aka.ms/azstorage-unitysdk)

## Requirements

* [Unity 2018.1 (or greater)](https://unity3d.com/)
* [A Computer Vision API account (Sign up for free!)](https://aka.ms/azfreegamedev)

## Compatibility

This has been tested with the following Unity exporters.  Others may work -- we haven't tested every platform, so please let us know if you've had success!

* Windows standalone
* UWP (IL2CPP requires 2018.2.0b3 or higher)
* iOS
* Android (Mono)
* Unity editor

## Known Issues and Limitations

There are a few known issues and workarounds.

### SSL support

Unity 2018.2 supports proper SSL usage, however there is still a threading bug which this SDK unfortunately exposes.  To workaround this, you will need to use standard **http** endpoints when calling the Computer Vision API.  Here's an example:

```text
http://eastus.api.cognitive.microsoft.com/vision/v1.0
```

### Other Platforms

We have not had success in compiling or running games using the following platforms:

* Android (IL2CPP)
* UWP (.NET)
* WebGL

We will continue working on these and update as we find fixes.

## Import the SDK

To import the SDK into your own project, make sure you have downloaded the latest [.unitypackage](https://aka.ms/azstorage-unitysdk) from GitHub.  Then, do the following:

[!include[](include/unity-import.md)]

Please refer to the [Computer Vision API Docs](https://aka.ms/azstoragedocsgamedev) for even more samples and tutorials on using the API.

## Try the Sample

To use the sample, you will need to have an Computer Vision API account setup along with a valid connection string.  You can learn more about that [here](https://docs.microsoft.com/en-us/azure/storage/common/storage-create-storage-account).

To use the sample, do the following:

1. Download the [Unity SDKs repo](https://github.com/BrianPeek/AzureSDKs-Unity) from GitHub (or import it from the .unitypackage and continue to step 4).

1. Unzip to a location on your hard drive.

1. Open Unity 2017.1 (or greater) and point it to the **Storage** directory inside the unzipped package.

1. In the **Project** window, double-click the **AzureSample** scene inside the **AzureSamples\Storage** directory to open the main scene for the sample.

1. In this scene, select the **StorageObject** item in the **Hierarchy** window.

1. With **StorageObject** selected, you'll notice that there are blank **Connection String** entries in the **Inspector** window.  Fill in the these entries with your valid connection string as shown on the Azure portal, but remember to change the endpoint to use **http** as described above.  You can change the names of the other items if you wish, but the defaults should work as-is. You can find your connection strings in the Azure Portal as shown.

   ![Computer Vision API Keys in Azure Porta](../media/storage-keys.png)

1. Run the project from within the editor by clicking the **Play** button.  Alternatively, you can export to the platform of your choosing and run there.

1. At this point, you can click the button for any of the four storage types and watch the output window.  If things are setup and working, you will see the sample test a standard workflow.

The code for the sample is broken out into four separate scripts, one for each storage type.  Take a look at each to learn more about how it works.

## Next Steps

* [Computer Vision API Docs](https://aka.ms/azstoragedocsgamedev)
