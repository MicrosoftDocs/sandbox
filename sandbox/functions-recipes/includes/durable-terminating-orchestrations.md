## Terminating a running orchestration instance
An orchestration instance can be terminated using the `TerminateAsync` method on [DurableOrchestrationClient](https://docs.microsoft.com/azure/azure-functions/durable-functions-bindings#orchestration-client). The instance ID of the orchestration and a reason string must be passed to `TerminateAsync`.

```csharp
[FunctionName("TerminateOchestration")]
public static async Task TerminateOchestration(
    [QueueTrigger("orchestration-termination-queue")] string instanceID,
    [OrchestrationClient] DurableOrchestrationClient orchestrationClient)
{
    string terminationReason = "Tired of waiting on this one";
    await orchestrationClient.TerminateAsync(instanceID, terminationReason);
}
```

[!include[](../includes/takeaways-heading.md)]
* `TerminateAsync` method of `DurableOrchestrationClient` can be used to terminate a running orchestration.
* Alternatively, the termination endpoint returned from `CreateCheckStatusResponse` can be used.

[!include[](../includes/read-more-heading.md)
* [HTTP APIs in Durable Functions](https://docs.microsoft.com/azure/azure-functions/durable-functions-http-api)
* [Debugging and Diagnostics of Durable Functions](https://cda.ms/rH)
* [Durable Functions repo and samples](https://github.com/Azure/azure-functions-durable-extension)
