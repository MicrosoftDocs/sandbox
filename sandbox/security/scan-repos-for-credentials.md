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

The objective of this article is to show you how you can deploy a credential scanner tool to the cloud and have it scan your repositories to make sure that no private information is found in your repos. We'll also discuss how we can make the scanner more proactive and check incoming PRs.

## Toolchain

For the purpose of this tutorial, we will use [TruffleHog][0], an open source command-line tool that can scan public repositories for content that resembles private keys or passwords. We'll start by running it locally, to get an idea of how it works, and later will prepare it for the cloud.

To make sure that you can run TruffleHog, install [Python 3][1] - instructions might vary from machine to machine, so we will abstract this part out. You will also need [Docker][2] readily available.

## Getting Started

As I mentioned earlier, let's start by trying to run the tool locally to see the kind of output we are getting, and how we can ingest it. To get started, make sure to install TruffleHog via `pip`:

```python
pip install trufflehog
```

![Installation of TruffleHog via pip][i0]

>[!TIP]
>To avoid any permission issues, we recommend you test the tooling in a Python virtual environment. You can read more about those in [The Hitchhiker's Guide to Python][3].

[0]: https://github.com/dxa4481/truffleHog
[1]: https://www.python.org/downloads/
[2]: https://docs.docker.com/install/
[3]: http://docs.python-guide.org/en/latest/dev/virtualenvs/

[i0]: media/trufflehog/install.gif