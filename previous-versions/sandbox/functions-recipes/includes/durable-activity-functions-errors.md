## Handling activity function exceptions
Unhandled exceptions thrown in activity functions will be rethrown in the calling orchestrator function as a `FunctionFailedException`. The `InnerException` property of the `FunctionFailedException` will contain the original exception from the activity.

```csharp
[FunctionName("PlaceOrder")]
public static async Task OrderOrchestration(
    [OrchestrationTrigger] DurableOrchestrationContext context,
    TraceWriter log)
{
    try
    {
        await context.CallActivityAsync<bool>("CheckAndReserveInventory", null);
    }
    catch (FunctionFailedException ex)
    {
        log.Error("Inventory check failed", ex);
    }
}


[FunctionName("CheckAndReserveInventory")]
public static bool CheckAndReserveInventory([ActivityTrigger] DurableActivityContext context)
{
    throw new ArgumentException("Oops...");
}
```

[!include[](../includes/takeaways-heading.md)]
* `FunctionFailedException` is thrown in the orchestrator if an activity function throws an unhandled exception
* `FunctionFailedException`'s `InnerException` property will contain the source exception from the activity function.

[!include[](../includes/read-more-heading.md)]
* [Handling errors in Durable Functions](https://docs.microsoft.com/azure/azure-functions/durable-functions-error-handling)
* [Debugging and Diagnostics of Durable Functions](https://channel9.msdn.com/Shows/On-NET/Debugging-and-Diagnostics-of-Durable-Functions?WT.mc_id=functions-recipes-docs-cephilli)
* [Durable Functions repo and samples](https://github.com/Azure/azure-functions-durable-extension)
