---
title: Scanning Your Repos for Credentials - In the Cloud
description: Azure Event Hubs SDK for Unity
author: dend
keywords: security, credentials, repo, github, azure
ms.topic: article
ms.date: 4/6/2018
ms.author: dendeli
#ms.devlang: 
#ms.prod:
#ms.technology:
#ms.service:
---

# Scanning Your Repos for Credentials - In the Cloud

You have an organization in GitHub. You have employees that check in code from all over the world, with tens and hundreds of commits happening daily. You are excited about all the code - after all, open source is meant to make your life easier. However, what happens if someone accidentally checks in your storage account keys into source control as well? How soon will you find out about that before it's too late?

The objective of this article is to show you how you can deploy a credential scanner tool to the cloud and have it scan your repositories to make sure that no private information is exposed.

## Toolchain

For the purpose of this tutorial, we will use [TruffleHog][0], an open source command-line tool that can scan public repositories for content that resembles private keys or passwords. We'll start by running it locally, to get an idea of how it works, and later will prepare it for the cloud.

To make sure that you can run TruffleHog, install [Python 3][1] - instructions might vary from machine to machine, so we will abstract this part out. You will also need [Docker][2] readily available.

## Getting Started

As I mentioned earlier, let's start by trying to run the tool locally to see the kind of output we are getting, and how we can ingest it. The big benefit of TruffleHog is that it traverses the entire commit history - even though after you checked in a private key you might've checked in code to remove it, the actual key will still reside somewhere deep in the history - you want to be aware of that.

To get started, make sure to install TruffleHog via `pip`:

```python
pip install trufflehog
```

![Installation of TruffleHog via pip][i0]

>[!TIP]
>To avoid any permission issues, we recommend you test the tooling in a Python virtual environment. You can read more about those in [The Hitchhiker's Guide to Python][3].

Next, I am going to run the tool on a test sample repository. I will route the output of the tool into a JSON file, with the help of `--json` and `>> output.json`:

```python
trufflehog --regex https://github.com/{USER_ID}/{REPO_ID}.git --json >> output.json
```

![Running TruffleHog locally][i1]

Once the tool runs and we look at the output JSON file, we will notice that there are some strings found in the file that should trigger some action on the repo contributor's part:

![TruffleHog findings][i2]

>[!IMPORTANT]
>The TruffleHog tool currently does not output valid JSON due to the fact that it does not properly merge array entries. So for each set of findings, you will have a valid element group, but if there is more than one finding, there will be missing separators (commas) between them.

Some repos are extremely large and have a very extensive commit history. For those cases, we might want to set the depth limit, that determines how many commits down the tree the tool will scan for credentials:

```python
trufflehog --regex https://github.com/{USER_ID}/{REPO_ID}.git --json --max-depth 7 >> output.json
```

## Building Out the Infrastructure

We now have an idea of how the tool runs. However, there is an unfortunate limitation - we need to run it on a per-repo basis. If you have an organization which you need to scan on a more-or-less constant basis, this won't work out-of-the-box. So let's make sure that we design a solution on top of this tool that scales a bit better.

In terms of cloud infrastructure, there are several components that we can leverage:

* [Azure KeyVault][4] - to get access information for the script (to be able to query private orgs in GitHub)
* [Azure Event Hubs][5] - to track events when they are triggered/information is collected from TruffleHog.
* [Azure Container Instances][7] - used to run the Docker-ized version of the credential scanner.
* [Azure Functions][8] - used to control when the scanner runs.
* [Azure Cosmos DB][6] - to collect the discovered data.

There is a couple of things that we can do here to make sure that the workflow is fully automated and you, as the customer, have nothing to worry about after the first set up. So we end up with an architecture like:

![Architecture Breakdown][i3]

The tool at the core of everything here will be the **passive scanner**. It will, at fixed time intervals, run and scan the repos and log the events.

Before we get to creating the scanner, it's worth mentioning that the scanner itself will need credentials - we do not know the scope of the organization in which it will run, and it might be locked down and have private repos. For those cases, we can conveniently generate [GitHub Personal Access Tokens][9] (PATs). However, we probably don't want to embed them directly into the script since those can change, and we want to give enough room for revocation scenarios. So instead, we'll use KeyVault.

Let's start by creating a new vault through the Azure Portal:

![Create new Key Vault in Azure Portal][i4]

Now, you can create a new **secret** that will represent the PAT:

![Create a new secret][i5]

Let's start with the script. Create a new folder and name it `passivescanner`, and create a new file - `requirements.txt`. This will be the file that stores the list of [dependent Python packages][11] that we will need. Let's start by adding the [`azure-keyvault`][10] package to the file:

```text
azure-keyvault>=10.0.0a1
```

[0]: https://github.com/dxa4481/truffleHog
[1]: https://www.python.org/downloads/
[2]: https://docs.docker.com/install/
[3]: http://docs.python-guide.org/en/latest/dev/virtualenvs/
[4]: https://docs.microsoft.com/azure/key-vault/
[5]: https://docs.microsoft.com/azure/event-hubs/
[6]: https://docs.microsoft.com/azure/cosmos-db/
[7]: https://docs.microsoft.com/azure/container-instances/
[8]: https://docs.microsoft.com/azure/azure-functions
[9]: https://help.github.com/articles/creating-a-personal-access-token-for-the-command-line/
[10]: https://pypi.python.org/pypi/azure-keyvault/1.0.0a1
[11]: https://pip.readthedocs.io/en/1.1/requirements.html

[i0]: media/trufflehog/install.gif
[i1]: media/trufflehog/test-tool.gif
[i2]: media/trufflehog/findings.png
[i3]: media/trufflehog/arch.png
[i4]: media/trufflehog/create-vault.gif
[i5]: media/trufflehog/create-secret.gif