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

[![Get the source](../../media/buttons/source2.png)](https://github.com/BrianPeek/azure-storage-net)
[![Try it now](../../media/buttons/try2.png)](https://github.com/BrianPeek/azure-storage-net/releases)

## Requirements
* [Unity 2017.1 (or greater)](https://unity3d.com/)
* [Azure Storage account](https://azure.com/)

## Compatibility
This has been tested with the following Unity exporters.  Others may work, so please let us know if you've had success!
* Windows standalone
* UWP
* iOS (IL2CPP)
* Android (Mono)
* Unity editor

## How to Use It
1. Download the latest [.unitypackage](https://github.com/BrianPeek/azure-storage-net/releases) from GitHub.
2. Add the package to Unity by using the Assets > Import Package > Custom Package... menu option.
3. Refer to the sample included in the .unitypackage for examples on how to use the Azure Storage API in your scripts.  Also, please refer to the [Azure Storage Docs](https://docs.microsoft.com/azure/storage/) for even more information.

## Known Issues

> [!WARNING]
> Due to a Unity limitation, SSL requests using the standard .NET networking stack will fail.  This is a problem Unity is working on, but for now it means one must essentially "disable" verification of SSL certificates to proceed.  I can't stress enough that this is a bad idea for a production application, which is why we are tagging this release as experimental.

To work around this issue, add the following line of code to your project, prior to initializing or using the Storage SDK:

```csharp
ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
```

## Next Steps
* [Azure Storage Docs](https://docs.microsoft.com/azure/storage/)
