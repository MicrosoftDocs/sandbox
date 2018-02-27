---
title: GitHub Release Notes
description: Generate release notes from GitHub
author: paladique
manager: scottca
keywords: 
ms.topic: article
ms.date: 02/26/2018
ms.author: jasmineg
ms.devlang: csharp
ms.service: functions
---

# GitHub Release Notes Generator

[!include[](../includes/header.md)]

The [The GitHub Release Notes Generator](https://github.com/paladique/release-notes-generator) is tool for generating a release notes document in conjunction with GitHub's release feature.


[![Deploy to Azure](https://azuredeploy.net/deploybutton.png)]()


## Requirements
* An [Azure](https://azure.microsoft.com/en-us/free/) account
* A [GitHub](https://github.com/join) account


## Links
* [Release Notes Repo](https://github.com/paladique/release-notes-generator)

## What's It Do?
The generator is a [Function App]() containing two Functions:

- A [GitHub WebHook]() triggered when a new release is created, that sends a message to a queue.
- A [Queue Trigger]() that uses the message sent from the webhook to create a markdown file with the repository's Issues and Pull Requests from the last two weeks, using the [Octokit.NET]() library.

* Note this currently works with only public repositories.

## Steps
1. Navigate to the Azure Portal and create a storage account. See the [Create a storage account quickstart](https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=portal#create-a-general-purpose-storage-account) to get started. 
2. Navigate to the new storage account, navigate to the **Blob Service** section, select **Browse Blobs**, then click the **Add Container** button at the top to create a blob container named `releases`. See section on how to [create a container](https://docs.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-portal#create-a-container) for more information.
3. In the same storage account menu, navigate to the **Queue Service** section, select **Browse Queues**, then click the **Add Queue** button at the top to create a queue named `release-queue`.
4. In the same storage account menu, navigate to **Access keys** and copy the connection string from either key 1 or 2.
4. Create a function app. See section on how to [create a function app](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-first-azure-function#create-a-function-app) to get started.
5. Navigate to the new function, from the overview, click and open **Application settings**, scroll to and click **+ Add new setting**  and add connection string. Name it `StorageConnection`.
6. Create a C# GitHub Webhook function. See section on how to [Create a GitHub webhook triggered function](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-github-webhook-triggered-function#create-a-github-webhook-triggered-function) to get started. 

7. Replace initial code with the following:

```csharp
using System.Net;

public static async Task Run(HttpRequestMessage req, ICollector<string> releaseQueueItem, TraceWriter log)
{
    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

    // Extract github comment from request body
    string releaseBody = data?.release?.body;
    string releaseName = data?.release?.name;

    var releaseDetails = String.Format("{0},{1}", releaseName, releaseBody);

    releaseQueueItem.Add(releaseDetails);
}
```
7. In your new function, click **</> Get function URL**, then copy and save the values. Do the same thing for** </> Get GitHub secret**. You will use these values to configure the webhook in GitHub
7. Navigate to GitHub and select the repo to use with webhook. See section on how to [Configure the webhook
](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-github-webhook-triggered-function#configure-the-webhook) on GitHub.
8. Go to repo settings, then webhooks, and click "add a webhook" button.
9. Follow the table to configure your settings:

| Setting | Suggested value | Description |
|---|---|---|
| **Payload URL** | Copied value | Use the value returned by  **</> Get function URL**. |
| **Content type** | application/json | The function expects a JSON payload. |
| **Secret**   | Copied value | Use the value returned by  **</> Get GitHub secret**. |
| Event triggers | Let me select individual events | We only want to trigger on release events.  |
| | Releases |  |

11. Click "add webhook".
12. Navigate to your GitHub user settings, then to "Developer applications" Click "New OAuth App" and create an app with a homepage url and callback url of your choice.
13. In the portal, Create a Queue trigger function. Replace initial code with the following:

```csharp
#r "Microsoft.WindowsAzure.Storage"
using System;
using Microsoft.WindowsAzure.Storage.Blob;
using Octokit;

public static async Task Run(string myQueueItem, CloudBlockBlob blobContainer, TraceWriter log)
{
    var releaseDetails = myQueueItem.Split(',');
    var releaseName = releaseDetails[0];
    var releaseBody = releaseDetails[1];

    string txtIssues = await GetReleaseDetails(IssueTypeQualifier.Issue);
    string txtPulls = await GetReleaseDetails(IssueTypeQualifier.PullRequest);

    var myBlobContainer = blobContainer.Container;
    var releaseText =  String.Format("# {0} \n {1} \n\n" + "# Issues Closed:" + txtIssues + "\n\n# Changes Merged:" + txtPulls, releaseName,releaseBody);
    var blob = myBlobContainer.GetAppendBlobReference(releaseName + ".md" );

    await blob.UploadTextAsync(releaseText);
}

public static async Task<string> GetReleaseDetails(IssueTypeQualifier type)
{
    var github = new GitHubClient(new ProductHeaderValue(Environment.GetEnvironmentVariable("ReleaseNotes")));
    var twoWeeks = DateTime.Now.Subtract(TimeSpan.FromDays(14));
    var request = new SearchIssuesRequest();

    request.Repos.Add(Environment.GetEnvironmentVariable("Repo"));
    request.Type = type;
    request.Created = new DateRange(twoWeeks, SearchQualifierOperator.GreaterThan);

    var issues = await github.Search.SearchIssues(request);

    string searchResults = string.Empty;
    foreach(Issue x in issues.Items)
    {
      searchResults += String.Format("\n - [{0}]({1})", x.Title, x.HtmlUrl);
    }

    return searchResults;
}
```

14. Configure webhook function by navigating to "Integrate." add a new queue storage output. Set the queue name to same name as the one created in step 3.
15. Navigate to queue trigger, add the following to function.json:

```
    {
      "name": "blobContainer",
      "type": "blob",
      "direction": "inout",
      "path": "container-name/*",
      "connection": "blobConnectionName"
    }
```

16. In the same function, upload a project.json with the following:

```
{
  "frameworks": {
    "net46":{
      "dependencies": {
        "Octokit": "0.29.0"
      }
    }
   }
}
```

17. Navigate back to the Function app Application settings. Add a setting named "Repo", with the value as the repo name: (organization/repository).
18. Add another setting named ReleaseNotes, with the value as the name of the application created in step 12.

## Next Steps
TBD
