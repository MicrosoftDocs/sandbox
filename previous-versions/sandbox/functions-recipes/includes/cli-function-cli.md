## Testing functions with Azure Functions Core Tools

Azure Functions Core Tools provides a local development environment to create and test azure functions. This example shows how to create and locally run a generic HTTP function trigger. Installation and use of Azure Functions Command Line Tools requires [Node.js](https://nodejs.org/).

After Node.js is installed, install the command line tools with the following command:

```
npm install -g azure-functions-core-tools@latest
```

After installation, use the following commands to create a directory that contains a new function project, and a new generic HTTP triggered function within that project:

```
mkdir myFunctions
cd myFunctions
func init
func new --language c# --template HttpTrigger --name myHttpTrigger
```

Function `myHttpTrigger` is now ready to be tested. Enter the following command to start the Function Host:

```
func host start
``` 

Once the host has started, open a browser and navigate to `http://localhost:7071/api/myHttpTrigger?name=Azure`.

[!include[](../includes/takeaways-heading.md)]

- Azure Functions Core Tools provide a local development environment for developing, testing, and publishing functions from the command line.
- Use of the command line tool requires installation of [Node.js](https://nodejs.org/)

[!include[](../includes/read-more-heading.md)]

- [Code and test Azure functions locally](https://docs.microsoft.com/azure/azure-functions/functions-run-local)
- [Azure Functions Core Tools GitHub Repository](https://github.com/Azure/azure-functions-core-tools)
