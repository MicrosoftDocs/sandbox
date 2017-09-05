## Manual C# Function

The following example is a function that must be triggered manually. The Azure portal is one way to trigger a function manually.

```csharp
using System;

public static void Run(string input, TraceWriter log)
{
    log.Info($"This is a manually triggered C# function with input: {input}");
}
```

[!include[](../includes/takeaways-heading.md)]

- The portal contains an optional request body section for entering input manually.
- A function can be manually triggered. The portal or Azure command line tools are ways to do this.

[!include[](../includes/read-more-heading.md)]

- [Create your first function in the Azure portal](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-first-azure-function)
- [Get started with Azure CLI](https://docs.microsoft.com/en-us/cli/azure/get-started-with-azure-cli)