## Manual C# Function

The following example is a function that must be triggered manually. The Azure portal is one way to trigger a function manually.

```
using System;

public static void Run(string input, TraceWriter log)
{
    log.Info($"This is a manually triggered C# function with input: {input}");
}
```

You can place `string` input in the response body.

## Read More
[Create your first function in the Azure portal](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-first-azure-function)