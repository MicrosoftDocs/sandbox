## Exposing HTTP Management APIs
When using a `HttpTrigger` along with Durable Functions, the `CreateCheckStatusResponse` method from `DurableOrchestrationClient` enables the creation of an `HttpResponseMessage`. The response contains links to the various management operations that can be invoked on am orchestration instance. These operations include querying the orchestration status, raising events, and terminating the orchestration.

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

The HTTP response body will resemble the following JSON payload, which contains the instance ID and management endpoints.

```json
{
    "id": "instanceId",
    "statusQueryGetUri": "http://host/statusUri",
    "sendEventPostUri": "http://host/eventUri",
    "terminatePostUri": "http://host/terminateUri"
}
```

[!include[](../includes/takeaways-heading.md)]
* `CreateCheckStatusResponse` method of `DurableOrchestrationClient` returns an `HttpResponseMessage` instance containing management links.
* The links in the payload are endpoints to the management API operations.
* `CreateCheckStatusResponse` requires the unique instance ID.

[!include[](../includes/read-more-heading.md)]
* [HTTP APIs in Durable Functions](https://docs.microsoft.com/azure/azure-functions/durable-functions-http-api)
* [Bindings for Durable Functions](https://docs.microsoft.com/azure/azure-functions/durable-functions-bindings#orchestration-client)
* [Azure Functions HTTP and webhook bindings](https://docs.microsoft.com/azure/azure-functions/functions-bindings-http-webhook)
* [Durable Functions repo and samples](https://github.com/Azure/azure-functions-durable-extension)