---
title: Azure Storage SDK for Unity
description: Azure Storage SDK for Unity
author: BrianPeek
manager: timheuer
keywords: unity, azure, storage
ms.topic: article
ms.date: 11/08/2017
ms.author: brpeek
#ms.devlang: 
#ms.prod:
#ms.technology:
#ms.service:
---
# Azure Storage SDK for Unity

[!include[](../../includes/header.md)]

This is an experimental Unity SDK for Azure Storage.

> [!IMPORTANT]
> As stated above, please note that this SDK is not supported and is not provided by the Azure Storage team.  If you run into problems, please let us know using the [GitHub Issues](https://github.com/BrianPeek/azure-storage-net/issues) page for this fork.

[![Get the source](../../media/buttons/source2.png)](https://github.com/BrianPeek/azure-storage-net)
[![Try it now](../../media/buttons/try2.png)](https://github.com/BrianPeek/azure-storage-net/releases)

## Requirements

* [Unity 2017.1 (or greater)](https://unity3d.com/)
* [An Azure Storage account (Sign up for free!)](https://azure.microsoft.com/en-us/free/)

## Compatibility

This has been tested with the following Unity exporters.  Others may work, and we haven't tested every platform, so please let us know if you've had success!

* Windows standalone
* UWP (.NET)
* iOS (IL2CPP)
* Android (Mono)
* Unity editor

## How to Use It

1. Download the latest [.unitypackage](https://github.com/BrianPeek/azure-storage-net/releases) from GitHub.
1. Open Unity and select **Edit > Project Settings > Player** to open the **PlayerSettings** panel.
1. Select **Experimental (.NET 4.6 Equivalent)** from the **Scripting Runtime Version** dropdown in the **Configuration** section.

   ![player config](media/unity-player-config.png)
1. Add the .unitypackage you downloaded in the first step to Unity by using the **Assets > Import Package > Custom Package** menu option.
1. In the **Import Unity Package** box that pops up, you can select which things you'd like to import.  By default everything will be selected.  If you don't wish to explore the sample, you may uncheck the **Sample** and **StreamingAssets** directories.
1. Click the **Import** button to add the items to your project.

With the package added, you can now use the Azure Storage SDK API in your scripts as you would in any other application.  Please take a look at the included sample which demonstrates how to use each of the storage services to perform simple tasks. Also, please refer to the [Azure Storage Docs](https://docs.microsoft.com/azure/storage/) for even more information.

## Known Issues and Limitations

There are a few known issues and workarounds.

### Unity and SSL support

Due to a Unity limitation, HTTPS requests using the standard .NET networking stack (i.e. not using UnityWebRequest) will fail.  To workaround this, you can modify the the **DefaultEndpointsProtocol** entry in your connection string to use **http** instead of **https**.  Here's an example:

```
DefaultEndpointsProtocol=http;AccountName=yourazureaccount;AccountKey=abcdef12345;EndpointSuffix=core.windows.net
```

### Other Platforms

We have not had success in compiling or running games using the following platforms:

* Android (IL2CPP)
* UWP (IL2CPP)

We will continue working on these and update as we find fixes.

## Next Steps

* [Azure Storage Docs](https://docs.microsoft.com/azure/storage/)
