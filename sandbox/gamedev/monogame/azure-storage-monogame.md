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
[![Try it now](../../media/buttons/try2.png)](https://github.com/BrianPeek/AzureSamples-MonoGame)

## Requirements

* [MonoGame 3.6 or higher (earlier versions may work)](http://www.monogame.net/)
* [An Azure Storage account (Sign up for free!)](https://azure.microsoft.com/en-us/free/)

## Compatibility

This has been tested with the following projects.  Others may work, so please let us know if you've had success!

* Windows
* UWP
* iOS
* Android

## Known Issues and Limitations

* None

## How to Use It

Because MonoGame uses the traditional .NET Framework and CLR on Windows, and Xamarin on other platforms, the existing Azure Storage SDK NuGet package works as-is across all platforms.  To use the Azure Storage SDK, simply add a NuGet package reference to the **WindowsAzure.Storage** package.

1. Click the **Projects > Manage NuGet Packages** menu.

1. In the NuGet Package Manager window, enter **azure storage** in the search box.  The **WindowsAzure.Storage** package will appear.

1. Highlight this package, then click the **Install** button on the right side of the window.

1. Accept any license prompts, and the package will be installed.

![nuget](media/monogame-storage-nuget.png)

With the package added, you can now use the Azure Storage SDK API in your MonoGame game as you would in any other .NET application.  The **Get the Source** button above will link you to a cross-platform MonoGame sample showing how to use the basic features of the Azure Storage SDK.  Also, please refer to the [Azure Storage Docs](https://docs.microsoft.com/azure/storage/) for even more samples and tutorials.

## Try the Sample

To use the sample, you will need to have an Azure Storage account setup along with a valid connection string.  You can learn more about that [here](https://docs.microsoft.com/en-us/azure/storage/common/storage-create-storage-account).

To use the sample, do the following:

1. Download the [MonoGame sample project](https://github.com/BrianPeek/AzureSamples-MonoGame) from GitHub.

1. Unzip to a location on your hard drive.

1. Navigate to that location and open the **AzureStorage.sln** solution file in the **Storage** directory.

1. Open **Game1.cs** from the **AzureStorage.Shared** project in Solution Explorer.

1. Look for the **ConnectionString** member and replace with your valid connection string.  You can find your connection strings in the Azure Portal as shown.

   ![Azure Storage Keys in Azure Porta](../media/storage-keys.png)

1. Build and run!  Press 1, 2, 3, or 4 on your keyboard to test the associated storage API.

## Next Steps

* [Azure Storage Docs](https://docs.microsoft.com/azure/storage/)
