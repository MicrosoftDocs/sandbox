## Testing functions with Azure Functions Command Line Tools

Azure Functions Core Tools provides a local development environment to create and test azure functions. This example shows how to create and locally run a generic HTTP function trigger. Installation and use of Azure Functions Command Line Tools requires [Node.js](https://docs.npmjs.com/getting-started/installing-node).

After Node.js is installed, install the command line tools with the following command:

```
npm install -g azure-functions-core-tools@latest
```

After installation, use the following commands to create a directory that contains a new function project, and a new generic HTTP function trigger within that project:

```
mkdir myFunctions
cd myFunctions
func init myFunctionProject
func new --language c# --template HttpTrigger --name myHttpTrigger
```

Function `myHttpTrigger` is now ready to be tested. Enter the following command to run the trigger manually with "Azure" in the content body:

```
func run myHttpTrigger --content '{\"name\": \"Azure\"}'
``` 

The output should print the text "Hello Azure". To publish this function from the command line, refer to the documentation listed at the bottom of the example.

[!include[](../includes/takeaways-heading.md)]

- Azure Functions Core Tools provide a local development environment for developing, testing, and publishing functions from the command line.
- Use of the command line tool requires installation of [Node.js](https://docs.npmjs.com/getting-started/installing-node)

[!include[](../includes/read-more-heading.md)]

- [Code and test Azure functions locally](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local)
- [Azure Functions Core Tools GitHub Repository](https://github.com/azure/azure-functions-cli)
