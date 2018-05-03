## Starting Orchestrations
Orchestrations with Durable Functions are started by using the `StartNewAsync` method on the [DurableOrchestrationClient](https://docs.microsoft.com/azure/azure-functions/durable-functions-bindings#orchestration-client). An instance of `DurableOrchestrationClient` can be retrieved by using the `OrchestrationClientAttribute` binding. The binding can be paired with exiting function triggers.

```csharp
[FunctionName("RunOrchestration")]
public static async Task<HttpResponseMessage> RunOrchestration(
    [HttpTrigger(AuthorizationLevel.Anonymous, "POST")]HttpRequestMessage req,
    [OrchestrationClient] DurableOrchestrationClient orchestrationClient)
{
    OrderRequestData data = await req.Content.ReadAsAsync<OrderRequestData>();
    string instanceId = await orchestrationClient.StartNewAsync("PlaceOrder", data);

    return orchestrationClient.CreateCheckStatusResponse(req, instanceId);
}
```

[!include[](../includes/takeaways-heading.md)]
* `StartNewAsync` method of `DurableOrchestrationClient` is used to start a stateful workflow.
* `StartNewAsync` has overloads that accept input that may need to be passed to the orchestration.
* The `OrchestrationClient` binding is used to get access to the `DurableOrchestrationClient`
* The `OrchestrationClient` binding can be used with core Azure Functions triggers.

[!include[](../includes/read-more-heading.md)]
* [Durable Functions overview](https://docs.microsoft.com/azure/azure-functions/durable-functions-overview)
* [Bindings for Durable Functions](https://docs.microsoft.com/azure/azure-functions/durable-functions-bindings#orchestration-client)
* [Durable Functions NuGet package](https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.DurableTask)
* [Azure Functions triggers and bindings concepts](https://docs.microsoft.com/azure/azure-functions/functions-triggers-bindings)