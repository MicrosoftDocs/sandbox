---
title: NotBacon
description: Detect the presence of bacon in a photo
author: AnthonyChu
manager: scottca
keywords: 
ms.topic: article
ms.date: 08/17/2017
ms.author: antchu
ms.devlang: csharp
#ms.prod:
#ms.technology:
#ms.service:
---

[!include[](includes/header.md)]

# NotBacon

NotBacon is a web application that detects the presence of bacon in a photograph. This project is written in C# and JavaScript, and uses Custom Vision Service.

Custom Vision Service is part of Microsoft Azure's Cognitive Services. You can use it to create customized image classifiers in a few minutes. 

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/?repository=https://github.com/anthonychu/not-bacon)

## Requirements
* An [Azure](https://azure.microsoft.com/en-us/free/) account

## Links
* [GitHubBot Repo](https://github.com/anthonychu/not-bacon)

## Overview

The application consists of two components:
* A Custom Vision Service project - allows you to build a custom image classifier to detect bacon in a photo.
* An Azure Web App - displays a web interface for users to submit photos.

## Custom Vision Service

### Create a Custom Vision Service account

1. Navigate to [customvision.ai](https://customvision.ai/).
1. Click **Sign in** and log in with your Microsoft Account.

### Create and train a Custom Vision project

1. Click on **New Project**.
    * Provide a name for the project.
    * Select **Food** as the domain to optimize the model to work with plates of food.

    ![New Project](media/notbacon/create-custom-vision-project.png)

1. Obtain a variety of photos. To properly train your model, you need at least 30 photos that contain bacon, and 30 that do not. Download and separate the photos into two folders: `bacon` and `not-bacon`.
    > Tip: A good place to find photos is by doing an internet image search for `breakfast`. 

1. Click on **Add Images** and select all the photos you previously downloaded in the `bacon` folder.
    * Create a tag named `bacon`, click **+** to add it.
    * Click **Upload** to upload the photos and tag them as `bacon`.

    ![Add bacon images](media/notbacon/add-bacon-images.png)
    
1. Click on **Add Images** again to add images from the `not-bacon` folder. Tag them as `not-bacon`.
    
    ![Add not bacon images](media/notbacon/add-not-bacon-images.png)

1. Click **Train** to train the image classifier. When training is complete, your model is ready to use.
    
    ![Train model](media/notbacon/click-train.png)

1. Click **Quick Test** to test your classifier. Find a photo that was *not* in your training set. **Browse local files** to upload it or enter its URL. Check that the model correctly predicted the tags for the photo.
    
    ![Test model](media/notbacon/test-model.png)

## NotBacon web application

### Obtain Custom Vision Service API information

In order to configure the web application, you need some information about the Custom Vision Service API project you created.

1. Select the **Performance** tab in your project.
1. If you have trained your model more than once, select the latest iteration and click **Make Default**. The default REST API endpoint of your project is set to use this iteration of the model.
    
    ![Make default](media/notbacon/set-default.png)

1. Click on **Prediction URL**. Under the "If you have an image URL" section, copy the API endpoint URL and the prediction key value for use in the next step.
    
    ![Get API information](media/notbacon/grab-keys.png)

### Deploy to a Web App

1. Click the [Deploy to Azure link](https://azuredeploy.net/?repository=https://github.com/anthonychu/not-bacon) here or the button at the top of this page.
1. If prompted, sign in to your Azure account.
1. Enter the information for your Azure subscription, such as the resource group name, site name, etc.
1. Fill in the **Custom Vision API Key** and **Custom Vision API URL** with the values that you previously copied.

    screenshot here

1. Click **Next** and then **Deploy**.

### Test the web application

1. If the application is successfully deployed, the Deploy to Azure tool displays a URL. Open the application by clicking on the link.
1. Find a photo on the internet, paste its URL in the URL text box, and click **Submit**.
1. The application should display whether or not bacon was detected in the photo.

## Next Steps

Here are links to the docs for the items discussed. Enjoy!

* [Bot Framework Docs](https://docs.microsoft.com/bot-framework)
* [LUIS.ai Docs](https://docs.microsoft.com/en-us/azure/cognitive-services/LUIS/Home)
* [OctoKit.NET](https://octokit.github.io/)
