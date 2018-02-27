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
* A [GitHub]() account


## Links
* [Release Notes Repo](https://github.com/paladique/release-notes-generator)

## What's It Do?
The generator is a [Function App]() containing two Functions:

- A GitHub WebHook triggered when a new release is created, that sends a message to a queue.
- A Queue Trigger that uses the message sent from the webhook to create a markdown file with Issues and Pull Requests from the last two weeks.

* Note this currently works with only public repositories.

## Steps
1. Create a Storage Account. Copy connection string. 
2. Create blob container named `releases`
3. Create a queue named `release-queue`
4. Create a Function App.
5. Configure Function app, go to application settings and add connection string, name it `storageConenction`
6. Create a C# GitHub Webhook function. Replace initial code with the following:

```csharp
using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, ICollector<string> releaseQueueItem, TraceWriter log)
{
    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

    // Extract github comment from request body
    string releaseBody = data?.release?.body;
    string releaseName = data?.release?.name;

    var releaseDetails = String.Format("{0},{1}", releaseName, releaseBody);

    releaseQueueItem.Add(releaseDetails);
 
    return req.CreateResponse(HttpStatusCode.OK, "Works!");
}
```

7. Navigate to GitHub and select the repo to use with webhook.
8. Go to repo settings, then webhooks, and click "add a webhook" button.
9. From the portal, copy the function url and paste into the payload url field, and the function key into the secret field in the GitHub webhook page.
10. Select "let me select individual events", check the Releases box, and uncheck Push.
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
