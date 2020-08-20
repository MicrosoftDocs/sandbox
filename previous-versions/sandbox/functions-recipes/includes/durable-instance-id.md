## Identifying Instances
When  is started by using the `StartNewAsync` method on the [DurableOrchestrationClient](https://docs.microsoft.com/azure/azure-functions/durable-functions-bindings#orchestration-client), the unique instance ID for that orchestration is returned. If an instance ID isn't provided to the `StartNewAsync` call, a random ID will be generated.

The instance ID can be stored so that future management operations can be invoked on the respective orchestration.

```csharp
[FunctionName("RunOrchestration")]
public static async Task RunOrchestration(
    [QueueTrigger("my-orchestration-queue")] string instanceID,
    [OrchestrationClient] DurableOrchestrationClient orchestrationClient,
    TraceWriter log)
{
    string instanceId = await orchestrationClient.StartNewAsync("PlaceOrder", input);
    log.Info($"Started orchestration with ID = '{instanceId}'.");
}
```

[!include[](../includes/takeaways-heading.md)]
* `StartNewAsync` method of `DurableOrchestrationClient` is used to start a stateful workflow.
* `StartNewAsync` returns a unique instance ID for the orchestration invocation.
* The instance ID can be used to query the status of the orchestration and run other management operations.

[!include[](../includes/read-more-heading.md)]
* [Instance Management](https://docs.microsoft.com/azure/azure-functions/durable-functions-instance-management)
* [Bindings for Durable Functions](https://docs.microsoft.com/azure/azure-functions/durable-functions-bindings#orchestration-client)
* [Durable Functions repo and samples](https://github.com/Azure/azure-functions-durable-extension)
