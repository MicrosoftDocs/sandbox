## Calling activity functions with retry
When call activities in your orchestration functions, you may want to apply a retry policy to handle transient errors that may occur. In such cases, the `DurableOrchestrationContext` provides the `CallActivityWithRetryAsync` method. The difference between `CallActivityAsync` and `CallActivityWithRetryAsync` is that the latter accepts a type of `RetryOptions` that specifies the retry behavior.

```csharp
public static async Task OrderOrchestration(
[OrchestrationTrigger] DurableOrchestrationContext context,
ILogger log)
{
    RetryOptions retryPolicy = new RetryOptions(
        firstRetryInterval: TimeSpan.FromSeconds(3),
        maxNumberOfAttempts: 3);

    retryPolicy.Handle = (ex) =>
    {
        TaskFailedException failedEx = ex as TaskFailedException;
        return (failedEx.Name != "CheckAndReserveInventory") ? false : true;
    };

    try
    {
        await context.CallActivityWithRetryAsync<bool>("CheckAndReserveInventory", retryPolicy, null);
    }
    catch (FunctionFailedException ex)
    {
        log.LogError("Inventory check failed", ex);
    }
}
```

Here is an activity function that throws an exception.
```csharp
[FunctionName("CheckAndReserveInventory")]
public static async Task<bool> CheckAndReserveInventory([ActivityTrigger] DurableActivityContext context)
{
    throw new Exception("Ooops...");
}
```

[!include[](../includes/takeaways-heading.md)]
* `CallActivityWithRetryAsync` allows orchestrator functions to call activities with retry behavior.
* A `RetryOptions` instance is used to define retry behavior.
* A `RetryOptions` instance can be reused across multiple calls to `CallActivityWithRetryAsync`.
* The `Handle` property on `RetryOptions` lets callers define whether retries should proceed or not.

[!include[](../includes/read-more-heading.md)]
* [Handling errors in Durable Functions](https://docs.microsoft.com/en-us/azure/azure-functions/durable-functions-error-handling)
* [Debugging and Diagnostics of Durable Functions](https://channel9.msdn.com/Shows/On-NET/Debugging-and-Diagnostics-of-Durable-Functions?WT.mc_id=functions-recipes-docs-cephilli)
* [Durable Functions repo and samples](https://github.com/Azure/azure-functions-durable-extension)
