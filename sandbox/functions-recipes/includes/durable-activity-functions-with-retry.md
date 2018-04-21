## Calling activity functions with retry
When call activities in your orchestration functions, you may want to apply a retry policy to handle transient errors that may occur. In such cases, the `DurableOrchestrationContext` provides the `CallActivityWithRetryAsync` method. The difference between `CallActivityAsync` and `CallActivityWithRetryAsync` is that the latter accepts a type of `RetryOptions` that specifies the retry behavior.

```csharp
[FunctionName("PlaceOrder")]
public static async Task OrderOrchestration(
    [OrchestrationTrigger] DurableOrchestrationContext context,
    TraceWriter log)
{
    RetryOptions retryPolicy = new RetryOptions(
        firstRetryInterval: TimeSpan.FromSeconds(3),
        maxNumberOfAttempts: 3);

    retryPolicy.Handle = (ex) =>
    {
        return (ex is InvalidOperationException) ? false : true;
    };

    try
    {
        bool reserved = await context.CallActivityWithRetryAsync<bool>("CheckAndReserveInventory", retryPolicy, null);
    }
    catch (FunctionFailedException ex)
    {
        log.Error("Inventory check failed", ex);
    }
}
```

[!include[](../includes/takeaways-heading.md)]
* `CallActivityWithRetryAsync` allows orchestrator functions to call activities with retry behavior.
* A `RetryOptions` instance is used to define retry behavior.
* The `Handle` property on `RetryOptions` lets callers define whether retries should proceed or not.

[!include[](../includes/read-more-heading.md)
* [Handling errors in Durable Functions](https://docs.microsoft.com/en-us/azure/azure-functions/durable-functions-error-handling)
* [Debugging and Diagnostics of Durable Functions](https://cda.ms/rH)
* [Durable Functions repo and samples](https://github.com/Azure/azure-functions-durable-extension)
