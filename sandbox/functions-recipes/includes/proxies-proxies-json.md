## Using proxies.json

Azure Functions Proxies can be used to modify requests to and responses from your function app. Simpler configurations can be managed from the Azure portal, which modifies a file called `proxies.json` behind the scenes. You can modify `proxies.json` directly to enable more complex scenarios.

The [App Service Editor](https://docs.microsoft.com/azure/azure-functions/functions-how-to-use-azure-function-app-settings#editor) allows you to modify all files in the function app's root directory. You can use it to edit an existing `proxies.json` file. If a    `proxies.json` does not exist, you can use it to create one and edit it.

[!include[](../includes/takeaways-heading.md)]

- Azure Functions Proxies are configured using `proxies.json`.
- You can edit `proxies.json` using App Service Editor. 

[!include[](../includes/read-more-heading.md)]

- [Azure Functions Proxies documentation](https://docs.microsoft.com/en-us/azure/azure-functions/functions-proxies)
