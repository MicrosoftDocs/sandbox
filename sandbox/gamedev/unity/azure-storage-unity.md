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

> [!IMPORTANT]
> This is an experimental Unity SDK for Azure Storage.  As such, please note that this SDK is not supported and is not provided by the Azure Storage team.  If you run into problems, please let us know using the [GitHub Issues](https://github.com/BrianPeek/azure-storage-net/issues) page for this fork.

[![Get the source](../../media/buttons/source2.png)](https://github.com/BrianPeek/azure-storage-net/tree/gamedev)
[![Try it now](../../media/buttons/try2.png)](https://github.com/BrianPeek/azure-storage-net/releases)

## Requirements

* [Unity 2017.1 (or greater)](https://unity3d.com/)
  * Unity 2017.1 includes a new scripting runtime that supports .NET 4.6.  This feature allows us to use the existing Azure SDKs with some tweaks.  Please see [this blog post from Unity](https://blogs.unity3d.com/2017/07/11/introducing-unity-2017/) for more information.
* [An Azure Storage account (Sign up for free!)](https://aka.ms/azfreegamedev)

## Compatibility

This has been tested with the following Unity exporters.  Others may work, and we haven't tested every platform, so please let us know if you've had success!

* Windows standalone
* UWP (.NET)
* iOS (IL2CPP)
* Android (Mono)
* Unity editor

## Known Issues and Limitations

There are a few known issues and workarounds.

### Unity and SSL support

Due to a Unity limitation, HTTPS requests using the standard .NET networking stack (i.e. not using UnityWebRequest) will fail.  To workaround this, you will need to modify the **DefaultEndpointsProtocol** entry in your connection string to use **http** instead of **https**.  **This means your data will not be encrypted to and from the server.**  Here's an example:

```text
DefaultEndpointsProtocol=http;AccountName=yourazureaccount;AccountKey=abcdef12345;EndpointSuffix=core.windows.net
```

### iOS Builds

There is a [known issue](https://issuetracker.unity3d.com/issues/ios-il2cpp-il2cpp-error-for-method-system-dot-void-system-dot-data-dot-constraintcollection-clear-crashes-whiled-building-for-ios) with Unity 2017.2 (and perhaps other versions) where iOS exports may fail with an error of:

```text
IL2CPP error for method 'System.Void System.Data.ConstraintCollection::Clear()'
```

This error isn't unique to this SDK.  We have not seen this error with the latest builds of 2017.1 or 2017.3, so you may wish to up/downgrade if you run into it until there is a proper patch from Unity.

### UWP Builds

To build for UWP, ensure that the the DLLs in the root Plugins directory are excluded from the build, while the DLLs in the WSA directory are included in the build.  To do this:

1. In the **Project** window, select all DLLs that are in the **Plugins** directory.

   ![Select all DLLs](media/unity-select-dlls.png)
   
1. In the Inspector window at the right, make sure only **WSAPlayer** is selected and **Any Platform** is not selected.

   ![Include only WSAPlayer](media/unity-wsaplayer-include.png)

With these selections, you should be able to export your UWP build without issue.  To go back to building for another platform, reverse the process -- make sure both **Any Platform** and **WSAPlayer** are selected and then export.

![Exclude only WSAPlayer](media/unity-wsaplayer-exclude.png)

### Other Platforms

We have not had success in compiling or running games using the following platforms:

* Android (IL2CPP)
* UWP (IL2CPP)
* WebGL

We will continue working on these and update as we find fixes.

## Import the SDK

1. Download the latest [.unitypackage](https://github.com/BrianPeek/azure-storage-net/releases) from GitHub.

1. Open Unity and select **Edit > Project Settings > Player** to open the **PlayerSettings** panel.

1. Select **Experimental (.NET 4.6 Equivalent)** from the **Scripting Runtime Version** dropdown in the **Configuration** section.

   ![Scripting Configuration dialog](media/unity-player-config.png)

1. Add the .unitypackage you downloaded in the first step to Unity by using the **Assets > Import Package > Custom Package** menu option.

1. In the **Import Unity Package** box that pops up, you can select which things you'd like to import.  By default everything will be selected.  If you don't care to use the sample, you can uncheck that box.

1. Click the **Import** button to add the items to your project.

With the package added, you can now use the Azure Storage SDK API in your scripts as you would in any other application.  Please take a look at the [sample](https://github.com/BrianPeek/AzureSamples-Unity) (also included in the .unitypackage) which demonstrates how to use each of the storage services to perform simple tasks. Also, please refer to the [Azure Storage Docs](https://aka.ms/azstoragedocsgamedev) for even more samples and tutorials on using the API.

## Try the Sample

To use the sample, you will need to have an Azure Storage account setup along with a valid connection string.  You can learn more about that [here](https://docs.microsoft.com/en-us/azure/storage/common/storage-create-storage-account).

To use the sample, do the following:

1. Download the [Unity sample project](https://github.com/BrianPeek/AzureSamples-Unity) from GitHub (or import it from the .unitypackage and continue to step 4).

1. Unzip to a location on your hard drive.

1. Open Unity 2017.1 (or greater) and point it to the **Storage** directory inside the unzipped package.

1. In the **Project** window, double-click the **AzureSample** scene inside the **Sample** directory to open the main scene for the sample.

1. In this scene, select the **StorageObject** item in the **Hierarchy** window.

1. With **StorageObject** selected, you'll notice that there are blank **Connection String** entries in the **Inspector** window.  Fill in the these entries with your valid connection string as shown on the Azure portal, but remember to change the endpoint to use **http** as described above.  You can change the names of the other items if you wish, but the defaults should work as-is. You can find your connection strings in the Azure Portal as shown.

   ![Azure Storage Keys in Azure Porta](../media/storage-keys.png)

1. Run the project from within the editor by clicking the **Play** button.  Alternatively, you can export to the platform of your choosing and run there.

1. At this point, you can click the button for any of the four storage types and watch the output window.  If things are setup and working, you will see the sample test a standard workflow.

The code for the sample is broken out into four separate scripts, one for each storage type.  Take a look at each to learn more about how it works.

## Next Steps

* [Azure Storage Docs](https://aka.ms/azstoragedocsgamedev)
