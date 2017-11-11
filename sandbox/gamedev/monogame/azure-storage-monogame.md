---
title: Using the Azure Storage SDK with MonoGame
description: Using the Azure Storage SDK with MonoGame
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

# Using the Azure Storage SDK with MonoGame

[!include[](../../includes/header.md)]

[![Get the source](../../media/buttons/source2.png)](https://github.com/BrianPeek/azure-storage-net/tree/gamedev/Samples/GameDev/MonoGame/AzureStorage)

## Requirements
* [MonoGame 3.6 or higher (earlier versions may work)](http://www.monogame.net/)
* [An Azure Storage account (Sign up for free!)](https://azure.microsoft.com/en-us/free/)

## Compatibility
This has been tested with the following projects.  Others may work, so please let us know if you've had success!
* Windows
* UWP
* iOS
* Android

## How to Use It
Because MonoGame uses the traditional .NET Framework and CLR on Windows, and Xamarin on other platforms, the existing Azure Storage SDK NuGet package works as-is across all platforms.

With the package added, you can now use the Azure Storage SDK API here as you would in any other application.  Please take a look at the included sample which demonstrate how to use each of the storage services to perform simple tasks. Also, please refer to the [Azure Storage Docs](https://docs.microsoft.com/azure/storage/) for even more information.

## Known Issues and Limitations
* None

## Next Steps
* [Azure Storage Docs](https://docs.microsoft.com/azure/storage/)
