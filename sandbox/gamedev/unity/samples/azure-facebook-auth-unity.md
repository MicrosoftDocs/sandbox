---
title: "Facebook authentication with Unity and Azure"
author: dantogno
ms.author: v-davian
ms.date: 01/24/2018
ms.topic: article
ms.assetid:
---
# Facebook authentication with Unity and Azure

![Facebook authentication with Unity and Azure heading image](media/fbauth_fb-auth-heading.png)

## Overview

This documentation demonstrates how to incorporate Facebook authentication into a Unity project that stores high score and game telemetry data in Azure Easy Tables.

The approach uses the [Facebook Unity SDK](https://developers.facebook.com/docs/unity/) to allow users to log in to Facebook. It then uses [UnityWebRequest](https://docs.unity3d.com/Manual/UnityWebRequest.html) to send HTTP requests to an [Azure function app](https://azure.microsoft.com/en-us/services/functions/) that handles authentication and data insertion and retrieval.

### Compatibility

This approach should work for any Unity platform supported by the Facebook SDK.
* iOS
* Android
* WebGL

> [!NOTE]
> PC builds can be supported by using the [Facebook Gameroom](https://unity3d.com/partners/facebook/gameroom) build feature of Unity.

### Prerequisites

* Unity 2017 ([free personal version](https://store.unity.com/products/unity-personal) is fine)
* Azure subscription (the [free trial](https://azure.microsoft.com/en-us/free/) or included credits from [Visual Studio Dev Essentials](https://www.visualstudio.com/dev-essentials/) are fine)
* [Visual Studio 2017](https://www.visualstudio.com/) (free Community edition is fine) with Game Development with Unity workload
* Facebook account

## Create an Azure Mobile App and configure Easy Tables

An [Azure Mobile App](https://azure.microsoft.com/en-us/services/app-service/mobile) is a type of Azure App Service. This example uses the Easy Tables feature of Azure Mobile Apps to store data simply.

> [!NOTE]
> Below is a broad outline of the steps required to set up Easy Tables, with links to detailed instructions. It is only necessary to follow the ["Configure Easy Tables in Azure"](https://docs.microsoft.com/en-us/sandbox/gamedev/unity/samples/azure-mobile-apps-unity-racer#configure-easy-tables-in-azure) and ["Create Easy Tables"](https://docs.microsoft.com/en-us/sandbox/gamedev/unity/samples/azure-mobile-apps-unity-racer#create-easy-tables) sections of the linked documentation. **Stop and return here upon reaching the section labeled "Prepare the development environment."** The rest of the article outlines an alternative approach to connecting to Azure that is not compatible with this example.

1. Log into the [Azure portal](https://portal.azure.com) and [create a new Mobile App](https://docs.microsoft.com/en-us/sandbox/gamedev/unity/samples/azure-mobile-apps-unity-racer#create-a-new-azure-mobile-app).

2. [Configure a data connection and initialize Easy Tables](https://docs.microsoft.com/en-us/sandbox/gamedev/unity/samples/azure-mobile-apps-unity-racer#add-a-new-data-connection) for the new Mobile App.

3. [Add three Easy Tables](https://docs.microsoft.com/en-us/sandbox/gamedev/unity/samples/azure-mobile-apps-unity-racer#create-easy-tables) with default schema:

  * **TestPlayerData** for use in a simplified test scene.

  * **HighScoreInfo** for storing high scores.

  * **CrashInfo** for storing telemetry data about where the player crashes in a racing game.

> [!NOTE]
> These specific table names are used in the example code, so be careful about changing them.

## Create an Azure Function App

This example uses an Azure Function App for data insertion and retrieval. Our Unity app will send HTTP requests to an Azure HTTP trigger function.
1. In the [Azure portal](https://portal.azure.com) click **Create a resource**, type "function app" in the search bar and then click **Function App** and select **Create**.

  ![new function app](media/fbauth_new-function-app.png)

2. In the next blade, enter a name for your function app, confirm the rest of the settings (default values will work) and click **Create**. Wait a moment for the new resource to be created. A notification in the Azure portal will announce when the new Function App is ready.

  ![create function app](media/fbauth_create-function-app.png)


### Create an Insert function

The Unity client will call the Insert function to insert data into our Easy Tables.

#### Create the new function

1. Once the new Function App has been created, select it in the portal.

2. Hover over the **Functions** tab and click the **+ button**.

3. Scroll down on the right side panel and click **Custom function** under the "Get started on your own" heading.

  ![create function](media/fbauth_create-function1.png)

4. Select **HTTP trigger**.

5. Choose **C#** from the **Language:** dropdown.

6. Name the function **Insert**.

7. Select **Anonymous** from the **Authorization level** dropdown.

8. Click the **Create** button.

  ![new function](media/fbauth_new-function.png)

#### Add the Azure Mobile Client and Newtonsoft.Json NuGet packages to the Insert function
This example uses the Azure Mobile Client SDK to simplify authentication and data operations.

1. Once the function has been created, select **View files** from the right side panel. You may need to extend the window or scroll right to find it.

2. Click **+ Add**.

3. Enter **project.json** as the new file's name and press Enter on the keyboard to create the file.

  ![add project file](media/fbauth_add-project-file.png)

4. Once the new project.json file is created, select it in the **View files** list.

5. Paste the following lines into the empty project.json file:
  ```
  {
  "frameworks": {
    "net46":{
      "dependencies": {
        "Microsoft.Azure.Mobile.Client": "4.0.2"
      }
    }
   }
}
```
6. Click **Save**. If you observe the log, it should detail that the Microsoft.Azure.Mobile.Client and Newtonsoft.Json packages have been installed and compilation has succeeded.

  ![packages added](media/fbauth_packages-added.png)

#### Add the Insert function body

The Insert function receives Json parameters in an HTTP POST request sent from the Unity client.

The parameters include:

  * The name of the table to be modified.

  * The access token for Facebook authentication (the Facebook Unity SDK gets this key after the user logs in).

  * The data object to add to the table.

This insert function deserializes the Json parameters, and then logs in and inserts the data into the appropriate table using the Azure Mobile Apps SDK.

1. Click on **run.csx** in the **View files** list to modify the function body.

2. Clear all of the initial code in the function and replace it with the following, then click **Save**:

```csharp
using System.Net;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");
    MobileServiceClient client = new MobileServiceClient("https://REPLACE-WITH-YOUR-MOBILEAPP-URL");
    dynamic data = await req.Content.ReadAsStringAsync();

    // Server expects a json arrary with the format:
    // [{"access_token":"value"},{"tableName":"value"},{instanceJson}]
    JArray arrayJson = JArray.Parse(data);
    dynamic authToken = arrayJson[0];
    var tableName = arrayJson[1].Value<string>("tableName");
    dynamic objectToInsert = arrayJson[2];

    // Try to log in. Return Unauthorized response upon failure.
    MobileServiceUser user = null;
    while (user == null)
    {
        try
        {
            // Change MobileServiceAuthenticationProvider.Facebook
            // to MobileServiceAuthenticationProvider.Google if using Google auth.
            user = await client.LoginAsync(MobileServiceAuthenticationProvider.Facebook, authToken);                
        }
        catch (InvalidOperationException exception)
        {
            log.Info("Log in failure!");
            return req.CreateErrorResponse(HttpStatusCode.Unauthorized, exception);
        }
    }
    // Try to Insert. Return BadRequest response upon failure.
    try
    {
        JToken insertedObject = await client.GetTable(tableName).InsertAsync(objectToInsert);
        return  req.CreateResponse(HttpStatusCode.OK, insertedObject);
    }
    catch (Exception exception)
    {
        return req.CreateErrorResponse(HttpStatusCode.BadRequest, exception);
    }
}
```
 > [!IMPORTANT]
 > Be sure to replace the string that reads "REPLACE-WITH-YOUR-MOBILEAPP-URL" with the URL to your Azure Mobile App. To find this URL:

  > * Click **App Services** from the main left menu of the Azure portal.

  > * Click the name of your Mobile App from the list.

  > * Ensure the **Overview** tab is selected

  > * Copy the URL from beneath the **URL** heading.

  ![copy URL](media/fbauth_app-url.png)

> [!NOTE]
> If you wish to customize this code, using [Visual Studio to test and debug Azure functions](https://blogs.msdn.microsoft.com/webdev/2017/05/10/azure-function-tools-for-visual-studio-2017/) is highly recommended.

### Create a GetAllEntries function

The Unity client will call the GetAllEntries function to get a list of all the entries in a specified table.

#### Create the new function

1. Click **Function Apps** in the Azure portal and select your function app.

2. Hover the **Functions** tab and click the **+ button**.

3. Scroll down on the right side panel and click **Custom function** under the "Get started on your own" heading.

4. Select **HTTP trigger**.

5. Choose **C#** from the **Language:** dropdown.

6. Name the function **GetAllEntries**.

7. Select **Anonymous** from the **Authorization level** dropdown.

8. Click the **Create** button.

#### Add the Azure Mobile Client and Newtonsoft.Json packages to the GetAllEntries function

1. Once the function has been created, select **View files** from the right side panel. You may need to extend the window or scroll right to find it.

2. Click **+ Add**.

3. Enter **project.json** as the new file's name and press Enter on the keyboard to create the file.

4. Once the new project.json file is created, select it in the **View files** list.

5. Paste the following lines into the empty project.json file:
  ```
  {
  "frameworks": {
    "net46":{
      "dependencies": {
        "Microsoft.Azure.Mobile.Client": "4.0.2"
      }
    }
   }
}
```
6. Click **Save**. If you observe the log, it should detail that the Microsoft.Azure.Mobile.Client and Newtonsoft.Json packages have been installed and compilation has succeeded.

#### Add the GetAllEntries function body

The GetAllEntries function receives Json parameters in an HTTP POST request sent from the Unity client.

The parameters include:

  * The access token for Facebook authentication (the Facebook Unity SDK gets this key after the user logs in).

  * The name of the table from which to get all entries.

This GetAllEntries function deserializes the Json parameters, and then logs in and adds a list of the specified table entries into an HTTP response that is sent back to the Unity client.

1. Click on **run.csx** in the **View files** list to modify the function body.

2. Clear all of the initial code in the function and replace it with the following, then click **Save**:

```csharp
using System.Net;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");
    MobileServiceClient client = new MobileServiceClient("https://REPLACE-WITH-YOUR-MOBILEAPP-URL");
    dynamic data = await req.Content.ReadAsStringAsync();

    // Server expects a json arrary with the format:
    // [{"access_token":"value"},{"tableName":"value"}]
    JArray arrayJson = JArray.Parse(data);
    dynamic authToken = arrayJson[0];
    var tableName = arrayJson[1].Value<string>("tableName");

    // Try to log in. Return Unauthorized response upon failure.
    MobileServiceUser user = null;
    while (user == null)
    {
        try
        {
            // Change MobileServiceAuthenticationProvider.Facebook
            // to MobileServiceAuthenticationProvider.Google if using Google auth.
            user = await client.LoginAsync(MobileServiceAuthenticationProvider.Facebook, authToken);
        }
        catch (InvalidOperationException exception)
        {
            log.Info("Log in failure!");
            return req.CreateErrorResponse(HttpStatusCode.Unauthorized, exception);
        }
    }

    // Try to get all entries as a list. Return BadRequest response upon failure.
    try
    {
        var table = client.GetTable(tableName);
        var list = await table.ReadAsync(string.Empty);
        return req.CreateResponse(HttpStatusCode.OK, list);
    }
    catch (Exception exception)
    {
        return req.CreateErrorResponse(HttpStatusCode.BadRequest, exception);
    }
}
```
> [!IMPORTANT]
> Be sure to replace the string that reads "REPLACE-WITH-YOUR-MOBILEAPP-URL" with the URL to your Azure Mobile App.

## Facebook setup

### Create a new Facebook app

To use Facebook authentication, you must create a new Facebook app.

1. Go to [developers.facebook.com/apps](https://developers.facebook.com/apps) and log in. If you haven't already, you'll need to upgrade your account to a developer account.

2. Click **Add a New App**.

3. Enter a **Display Name** and **Contact Email** for the new app.

  ![new facebook app](media/fbauth_new-fb-app.png)

4. Complete the captcha.

5. Take note of the **App ID** and **App Secret** associated with your new app. You may need to click the **Show** button and log in to view your app secret. These values will be used later in the example.

  ![app id and shared secret](media/fbauth_fb-id-secret.png)

> [!IMPORTANT]
> The app secret is an important security credential. Do not share this secret with anyone or distribute it within a client application.

### Add the Facebook Login product

After creating a new app you will be brought to the Add Product page.

1. Hover the mouse over **Facebook Login** from the list of products and then click the **Set Up** button that appears. Facebook will display a page about running a quickstart for various platforms. This is not necessary for this example. Simply clicking the **Set Up** button is sufficient.

  ![new app id](media/fbauth_fb-add-product.png)

2. The Facebook account which was used to register the application is an administrator of the app. At this point, only administrators can sign into this application. To authenticate other Facebook accounts, click **App Review** on the left side menu and enable **Make public** to enable general public access using Facebook authentication.

## Enable Facebook authentication on Azure

### Configure Azure Mobile App authentication settings

1. In the [Azure portal](https://portal.azure.com), navigate to the Mobile App created earlier in the example.

2. Click **Authentication / Authorization** in the left side menu.

3. Click the **On** button under the label "App Service Authentication."

4. Click **Facebook** from the list of authentication providers.

5. Paste in the **App ID** and **App Secret** from the Facebook app you created earlier in the example, then click **OK**.

6. Click **Save** at the top of the **Authentication / Authorization** settings blade. Azure will present a notification once the settings have successfully saved.

  ![mobile app Facebook settings](media/fbauth_mobile-app-facebook-settings.png)

### Set permissions for Easy Tables

1. Click **Easy Tables** in the left side settings menu for your Azure Mobile App.

2. For each of your tables, **click the table name** to open the table.

3. Click **Change permissions** then change each of the drop downs to **Authenticated access only**, then click **Save**.

  ![select easy tables](media/fbauth_select-easy-table.png)

  ![change easy table permissions](media/fbauth_set-easy-tables-permissions.png)

## Configure the Facebook SDK in a new Unity project

1. Launch the Unity editor and create a new 3D project.

2. Download the [Facebook SDK for Unity](https://developers.facebook.com/docs/unity) and extract the resulting .zip file.

> [!NOTE]
> There is a bug in the Facebook Unity SDK v7.11.0 that prevents initialization on WebGL. This example was tested with the [previous version](https://developers.facebook.com/docs/unity/change-log) (v7.10.1).

3. Open the extracted directory and navigate to the **FacebookSDK** folder.

4. With your Unity project open, double click the **facebook-unity-sdk.unitypackage** file to bring up the Import Unity Package dialog.

5. Leave everything checked and click **Import**.

  ![import facebook sdk](media/fbauth_import-fbsdk-unitypackage.png)

6. After importing, click **Facebook > Edit Settings** in the Unity menu.

  ![open facebook settings](media/fbauth_open-fbsdk-settings.png)

7. In the Facebook settings that open in the Unity Inspector, paste in your Facebook **App Id**.

## Facebook SDK for Unity WebGL setup

### Configure Unity build settings

1. Choose **File > Build Settings...** from the Unity menu.

2. Select the **WebGL** platform and click **Switch Platform**.

  > [!NOTE]
  > If you notice a compiler error regarding an assembly with the same name already being imported, try saving your project, closing Unity, and reopening.

### Configure web platform for your Facebook app

1. Go to [developers.facebook.com/apps](https://developers.facebook.com/apps/) and select your app.

2. At the dashboard, select **Settings** and choose **Basic**.

  ![basic settings](media/fbauth_basic-settings.png)

3. Click **Add Platform**.

  ![add facebook platform](media/fbauth_fb-add-platform.png)

4. Select **Website**.

  ![add website platform](media/fbauth_website.png)

5. Enter the **Site URL** where your WebGL build is hosted and click **Save**.

  ![website platform settings](media/fbauth_website-platform-settings.png)

### Configure CORS for Azure Function App

1. In the [Azure portal](https://portal.azure.com), navigate to the Function App created earlier in the example.

2. Click the **Platform features** tab and then select **CORS**.

  ![select CORS](media/fbauth_platformfeatures-cors.png)

3. Click the empty box at the bottom of the **Allowed Origins** list and type in the URL where your WebGL build is hosted.

4. Click **Save**.

  ![cors settings](media/fbauth_cors.png)

## Facebook SDK for Unity Android setup

> [!IMPORTANT]
> Before continuing, ensure your Unity Android development environment is properly configured. Consult the [Getting started with Android development](https://docs.unity3d.com/Manual/android-GettingStarted.html) documentation for help.

1. In the Unity menu, click **Facebook > Edit Settings** to open the FacebookSettings in the Inspector.  

2. Expand the **Android Build Facebook Settings** section. If you are missing prerequisites, a number of warnings may appear here next to yellow exclamation point images. The next steps in this section explain how to fix them. If these warnings don't appear for you, you can safely skip the related steps.

  ![expand Android Facebook settings](media/fbauth_android-fb-settings.png)

### Fix the missing debug keystore file warning

![Missing keystore](media/fbauth_android-debug-keystore-missing-cropped.png)

1. Install [Android Studio](https://developer.android.com/studio/index.html).

2. Create a new project with the default options. The project will not be used and can safely be deleted once created. The process of creating the new project corrects the missing android debug keystore warning.

### Fix the OpenSSL not found warning

![OpenSSL missing](media/fbauth_openssl-not-found-cropped.png)

1. Download and install the [Win64 Open SSL installer](https://slproweb.com/products/Win32OpenSSL.html) (do not download the "light" version).

  ![download OpenSSL installer](media/fbauth_download-openssl.png)

2. Add OpenSSL to your path environment variable. In the Windows search, type **environment**, then click **Edit the system environment variables** entry.

  ![Search environment vars](media/fbauth_search-environment-vars.png)

3. Click **Environment Variables...**.

  ![Open environment vars](media/fbauth_open-environment-vars.png)

4. In the lower **System variables** section, select the **Path** variable and then click **Edit...**.

  ![Open path var](media/fbauth_edit-path-var.png)

5. Click **New** and type in the path of the **OpenSSL-Win64\bin\** directory. Then click **OK**.

  ![edit path var](media/fbauth_add-path-vars.png)

### Fix the Keytool not found warning

![Keytool not found](media/fbauth_keytool-not-found.png)

1. Download and install the [Java JDK](http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html). Unity requires JDK 8 (1.8), 64-bit version.

2. Add the JDK to your path environment variable. In the Windows search, type **environment**, then click **Edit the system environment variables** entry.

3. Click **Environment Variables...**.

4. In the lower **System variables** section, select the **Path** variable and then click **Edit...**.

5. Click **New** and type in the path of the **jdk\bin\** directory. Then click **OK**.

  ![edit path var](media/fbauth_add-path-vars.png)

### Configure the Unity Android build and player settings

1. In the Unity menu, click **File > Build Settings...**.

2. Select **Android** in the list of platforms and then click **Switch Platform**.

3. Once the platform has been switched to Android, click **Player Settings.**

4. Find the **Identification** section in the Inspector and enter a valid **Package Name**. This should be in the format of `com.CompanyName.ProductName`.

  ![change package name](media/fbauth_change-package-name.png)

### Add the Android platform information to your Facebook app

1. In the Unity menu, select **Facebook > Edit Settings**.

2. Expand the **Android Build Facebook Settings**. Note the location of the **Package Name**, **Class Name**, and **Debug Android Key Hash** values as they must be copied and pasted in a later step.

3. Go to [developers.facebook.com/apps](https://developers.facebook.com/apps) and select your app.

4. Click **Settings**. Near the bottom of the **Basic** settings page, click the **Add Platform** button.

  ![add facebook platform](media/fbauth_fb-add-platform.png)

5. Select **Android**.

6. Copy and paste the **Package Name**, **Class Name**, and **Debug Android Key Hash** from your Unity project's **Android Build Facebook Settings** into the corresponding fields of your Facebook app's Android platform settings.

7. Click **Save Changes**.

  ![Android platform settings](media/fbauth_fb-android-settings.png)

## Try the test scene
> [!NOTE]
> The Facebook Unity SDK does not support logging in in the Unity editor. To test in the editor, paste a [debug access token](https://developers.facebook.com/tools/accesstoken/) into the `LogInUser()` function in `FacebookLogin.cs`.

1. Download and import the [Azure Easy Tables Client with Facebook auth Unity package](https://github.com/dantogno/Azure-Unity-FB-Auth/raw/master/Unity%20Packages/Azure%20Easy%20tables%20client%20with%20FB%20auth.unitypackage) into your Unity project.

2. In the [Azure portal](https://portal.azure.com), navigate to the Function App you created for this example and copy the URL.

  ![Copy function app URL](media/fbauth_copy-functionapp-url.png)

3. Open the file **EasyTableClient.cs** and change `private const string url = "REPLACE_WITH_YOUR_FUNCTIONAPP_URL"` to match the URL of the function app you created for this example, with `/api/` appended at the end.
> [!IMPORTANT]
> Be sure to append `/api/` to the end of your Function App URL!

4. In the Unity menu, choose **File > Build Settings...** and add the `Assets/Azure Easy tables client with FB Auth/Test Scene/test scene.unity` file to the index 0 position of the **Scenes in Build** list.

5. Ensure a platform supported by the Facebook Unity SDK is selected (Android, iOS, WebGL).

6. For iOS or Android, choose **Build and Run**. Choose an appropriate path to save the build. For WebGL click **Build** and upload the build to a hosting location on the web.

7. Once the game is running, press the **LOGIN** button.

  ![test login](media/fbauth_test-login.png)

8. This should present a Facebook login screen. Complete the Facebook login process.

  ![facebook login](media/fbauth_fb-login.png)

9. Press **INSERT**. This will add test data to the TestPlayerData table on your Azure Mobile App. Observe the **Output** window to see if the insert operation completed.

10. Press the **GET ALL ENTRIES** button. The **Output** window should print the count of entries in the TestPlayerData table. Verify that the count goes up after each new insert. Additionally, you can navigate to the TestPlayerData table in the Easy Tables section of your Mobile App on the [Azure portal](https://portal.azure.com) and manually inspect the entries.

> [!NOTE]
> The App Service will time out after a period of inactivity. It may take a moment to spin back up when it is hit again, so if the first test fails, please try again to ensure the service is in its running state.

## Try the sample racing game

1. Download and import the [Azure Easy Tables with FB auth sample game assets Unity package](https://github.com/dantogno/Azure-Unity-FB-Auth/raw/master/Unity%20Packages/Azure%20Easy%20tables%20with%20FB%20auth%20sample%20game%20assets.unitypackage) into your Unity project.

2. In the Unity menu, choose **File > Build Settings...** and add the scenes inside `Assets/Azure Easy tables with FB auth sample game assets/Scenes` to the **Scenes in Build** section.

3. Ensure that `MenuScene` is in the top, **index 0** position in the list of **Scenes in Build**.

  ![add sample scenes](media/fbauth_add-sample-scenes.png)

4. Ensure that a supported / configured platform is selected and choose **Build and Run**.

5. Once the build is running on your device, press the **Log in** button.

6. This should present a Facebook login screen. Complete the Facebook login process.

7.  Press the **Race!** button. Before viewing the leaderboard or heatmap, it's best to create some sample data by completing the race at least once.

8. Complete a lap around the course and cross the checkered finish line.

9. Once a lap has completed, the High Score dialog should come up since there will be no other scores to compete with. Type in a name and press **Submit**. The high score, along with data about where the player crashed into the wall during the race are sent to Azure.

10. Now use the menu to view either the **Crash Heatmap** or **Leaderboard**. Each will display data loaded from Azure.
