## Inspecting the status of an orchestration
The status of an orchestration instance can be queried using the `GetStatusAsync` method from `DurableOrchestrationClient`. The only required parameter is the instance ID of the orchestration to be inspected. The status query will include information like the orchestrator function name, creation time, and also running status.

Optionally, `GetStatusAsync` accepts a `showHistory` boolean parameter that will include the execution history of the orchestration. Another optional parameter, `showHistoryOutput`, can be provided to include the outputs of the activity functions in the status query.

```csharp
[FunctionName("CheckOrchestration")]
public static async Task CheckOrchestration(
    [QueueTrigger("my-orchestration-status-queue")] string instanceID,
    [OrchestrationClient] DurableOrchestrationClient orchestrationClient)
{
    DurableOrchestrationStatus status = await orchestrationClient.GetStatusAsync(instanceID, showHistory: true);

    if (status.RuntimeStatus == OrchestrationRuntimeStatus.Completed) {
        //do something with this completed orchestration
    }
}
```

[!include[](../includes/takeaways-heading.md)]
* `GetStatusAsync` method of `DurableOrchestrationClient` can be used to get status information for a given orchestration.
* Alternatively, the status endpoint returned from `CreateCheckStatusResponse` can be used.
* The execution history and results can be included in the response if `showHistory` and `showHistoryOutput` are set to true.
* `GetStatusAsync` returns an instance of `DurableOrchestrationStatus` that contains all the status information.

[!include[](../includes/read-more-heading.md)]
* [HTTP APIs in Durable Functions](https://docs.microsoft.com/azure/azure-functions/durable-functions-http-api)
* [Debugging and Diagnostics of Durable Functions](https://cda.ms/rH)
* [Durable Functions repo and samples](https://github.com/Azure/azure-functions-durable-extension)
