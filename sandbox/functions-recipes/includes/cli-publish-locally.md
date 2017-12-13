## Publishing a function locally

Azure Functions Core Tools provides a local development environment to publish Azure functions. Installation and use of Azure Functions Command-Line Tools requires [Node.js](https://docs.npmjs.com/getting-started/installing-node). This example shows how to create and publish a function. This requires an existing function app in Azure.

After Node.js is installed, install the command-line tools with the following command:

```
npm install -g azure-functions-core-tools@latest
```

After installation, use the following commands to create a directory that contains a new function project, adds a new generic HTTP function trigger, and runs it locally within that project. The trigger is run manually with "Azure" in the content body:

```
mkdir myFunctions
cd myFunctions
func init myFunctionProject
func new --language c# --template HttpTrigger --name myHttpTrigger
func run myHttpTrigger --content '{\"name\": \"Azure\"}'
```

The output should print the text "Hello Azure". To publish this function, signing in to Azure is required and can be done through the command line by using the command `func azure login`. This shows a sign-in prompt for Azure. Enter your credentials and press the "Sign In" button. Upon successful sign-in, the command line displays a list of all subscriptions linked to the account. 

The function must be published to a function app that currently exists in Azure. Once you've identified the app you'd like to publish to, enter the following publish command:

```
func azure functionapp publish myAzureFunctionApp
```
The published function is visible in the Azure portal and ready for use. Use the command `func azure functionapp list` to list function apps associated with the current subscription of the authenticated Azure account.

[!include[](../includes/takeaways-heading.md)]

- Azure Functions Core Tools provide a local development environment for developing, testing, and publishing functions from the command line.
- Use of the command-line tool requires installation of [Node.js](https://docs.npmjs.com/getting-started/installing-node)
- Publishing functions from the command line requires sign in to an Azure account, and an existing function app in Azure.

[!include[](../includes/read-more-heading.md)]

- [Code and test Azure functions locally](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local)
- [Azure Functions Core Tools GitHub Repository](https://github.com/azure/azure-functions-cli)