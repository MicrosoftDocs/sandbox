## Authoring Orchestrator Functions
Orchestrator functions are responsible for managing the stateful workflows in Durable Functions. They take care of checkpointing progress and resuming workflows that are waiting for activities to complete. `OrchestrationTriggerAttribute` is used to annotate functions as orchestrator functions.

Orchestration functions support only `DurableOrchestrationContext` as a parameter type. `DurableOrchestrationContext` has methods that allow you to call activity functions, call sub-orchestrations, get input data for the orchestrator, and a few others.

```csharp
[FunctionName("PlaceOrder")]
public static async Task<InvoiceData> OrderOrchestration([OrchestrationTrigger] DurableOrchestrationContext context)
{
    OrderRequestData orderData = context.GetInput<OrderRequestData>();

    //long running operation
    InvoiceData invoice = await context.CallActivityAsync<InvoiceData>("ProcessPayment", orderData);
    return invoice;
}
```

[!include[](../includes/takeaways-heading.md)]
* `OrchestrationTriggerAttribute` marks functions are orchestrator functions.
* `DurableOrchestrationContext` is used to interact with the activity functions the make up the stateful workflow.
* Orchestrator functions all run on a single dispatcher thread per host. Therefore, orchestrators should not perform any I/O operations.
* Orchestrator functions can return output values. The output must be JSON-serializable.
* A null value will be saved as the output if an orchestrator function returns `Task` or `void`.

[!include[](../includes/read-more-heading.md)]
* [Durable Functions overview](https://docs.microsoft.com/azure/azure-functions/durable-functions-overview)
* [Orchestration Trigger](https://docs.microsoft.com/azure/azure-functions/durable-functions-bindings#orchestration-triggers)
* [Durable Functions repo and samples](https://github.com/Azure/azure-functions-durable-extension)