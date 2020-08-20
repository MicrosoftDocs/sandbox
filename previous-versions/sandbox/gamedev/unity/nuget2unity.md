---
title: NuGet2Unity
description: NuGet packager for Unity
author: BrianPeek
manager: timheuer
keywords: unity, azure, nuget
ms.topic: article
ms.date: 10/22/2018
ms.author: brpeek
---
# NuGet2Unity - Create Unity Packages from NuGet

[!include[](../../includes/header.md)]

Unity does not support importing or using NuGet packages directly.  With this utility, you can download and package any NuGet package into a compatible .unitypackage for use with the Unity game engine.  This utility has been used to create the [Azure SDK packages](https://aka.ms/NuGet2Unity) here on the Sandbox.

[![Get the source](../../media/buttons/source2.png)](https://aka.ms/NuGet2Unity)

## Requirements

* [.NET Core 2.1 SDK](https://www.microsoft.com/net/download/dotnet-core/2.1)

## Compatibility

This utility was written to support Unity 2018 and greater with its support for .NET Standard 2.0.  Therefore, this packager will only work with NuGet packages that are compatible with .NET Standard 2.0.  If you are using an older version of Unity and/or the .NET 4.x backend in Unity, this tool will not create a compatible package for you.

> [!NOTE]
> While the resulting .unitypackage may import into your Unity project just fine, there's no guarantee the binaries themselves will work properly with Unity's Mono or IL2CPP based engines.

## How to Use

Please see the [README](https://aka.ms/NuGet2Unity) at the GitHub repo to learn more.
