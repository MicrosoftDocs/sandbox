---
title: Using Azure SDKs with MonoGame
description: Using Azure SDKs with MonoGame
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
# Using Azure SDKs with MonoGame

[!include[](../../includes/header.md)]

[![Get the source](../../media/buttons/source2.png)](https://github.com/BrianPeek/AzureSamples-MonoGame)

## Requirements

* [MonoGame 3.6 or higher (earlier versions may work)](http://www.monogame.net/)
* [An Azure account (Sign up for free!)](https://aka.ms/azfreegamedev)

## Compatibility

This has been tested with the following projects.  Others may work, so please let us know if you've had success!

* Windows
* UWP
* iOS
* Android

## Known Issues and Limitations

* None

## How to Use It

Because MonoGame uses the traditional .NET Framework and CLR on Windows, and Xamarin on other platforms, the existing .NET Azure SDK NuGet package works as-is across all platforms.  For example, to use the Azure Storage SDK, simply add a NuGet package reference to the **WindowsAzure.Storage** package as described below.

1. Click the **Projects > Manage NuGet Packages** menu.

1. In the NuGet Package Manager window, enter **azure storage** in the search box.  The **WindowsAzure.Storage** package will appear.

1. Highlight this package, then click the **Install** button on the right side of the window.

1. Accept any license prompts, and the package will be installed.

![nuget](media/monogame-storage-nuget.png)

With the package added, you can now use the Azure Storage SDK API (or the SDK you've chosen to install) in your MonoGame game as you would in any other .NET application.  The **Get the Source** button above will link you to a variety of cross-platform MonoGame samples showing how to use the basic features of certain Azure SDKs.

## Try the Samples

To use the sample, you will need to have an Azure account setup along with the service you wish to use.

1. Download the [MonoGame samples](https://github.com/BrianPeek/AzureSamples-MonoGame) from GitHub.

1. Unzip to a location on your hard drive.

1. Navigate to that location and open the solution for the service you're interested in using, for example the **AzureStorage.sln** solution file in the **Storage** directory.

1. Open **Game1.cs** from the **Shared** project in Solution Explorer.

1. Fill in any required connection strings or keys at the top of the file.  You can find your connection strings and keys in the Azure Portal.

1. Build and run!  Press 1, 2, 3, or 4 on your keyboard to test the associated sAPI.

<!--
## Next Steps

* [Azure Storage Docs](https://aka.ms/azstoragedocsgamedev)
-->