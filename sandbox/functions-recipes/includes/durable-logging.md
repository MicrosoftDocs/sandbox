## Logging in orchestrator functions
An orchestrator function creates checkpoints as each of its composite activity functions complete. After each call to `CallActivityAsync` on the `DurableOrchestrationContext` instance completes, the orchestrator function will automatically replay to rebuild their in-memory state.

To prevent logging statements from duplicating, use the `IsReplaying` property on the `DurableOrchestrationContext`.

```csharp
[FunctionName("PlaceOrder")]
public static async Task<InvoiceData> OrderOrchestration(
    [OrchestrationTrigger] DurableOrchestrationContext context,
    TraceWriter log)
{
    OrderRequestData orderData = context.GetInput<OrderRequestData>();

    if (!context.IsReplaying) log.Info("About Checking inventory");
    await context.CallActivityAsync<bool>("CheckAndReserveInventory", orderData);

    if (!context.IsReplaying) log.Info("Processing payment");
    InvoiceData invoice = await context.CallActivityAsync<InvoiceData>("ProcessPayment", orderData);

    return invoice;
}
```

[!include[](../includes/takeaways-heading.md)]
* `GetStatusAsync` method of `DurableOrchestrationClient` can be used to get status information for a given orchestration.
* Alternatively, the status endpoint returned from `CreateCheckStatusResponse` can be used.
* The execution history and results can be included in the response if `showHistory` and `showHistoryOutput` are set to true.
* `GetStatusAsync` returns an instance of `DurableOrchestrationStatus` that contains all the status information.

[!include[](../includes/read-more-heading.md)
* [HTTP APIs in Durable Functions](https://docs.microsoft.com/azure/azure-functions/durable-functions-http-api)
* [Debugging and Diagnostics of Durable Functions](https://cda.ms/rH)
* [Durable Functions repo and samples](https://github.com/Azure/azure-functions-durable-extension)
