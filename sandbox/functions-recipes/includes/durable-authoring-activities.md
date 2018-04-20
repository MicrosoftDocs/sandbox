## Authoring Activity Functions
Activities are composed together in orchestration functions to create a stateful workflow. Activities are where most of the processing happens for a given orchestration. `ActivityTriggerAttribute` is used to annotate functions as orchestration activities.

Activity functions can accept either an instance of `DurableActivityContext` or a JSON serializable type as a parameter. The return values are serialized to JSON and persisted to the orchestration history table when the orchestrator function does checkpointing.

```csharp
 [FunctionName("CheckAndReserveInventory")]
 public static bool CheckAndReserveInventory([ActivityTrigger] DurableActivityContext context)
 {
     OrderRequestData orderData = context.GetInput<OrderRequestData>();

     // Check inventory system and reserve products
     return true;
 }
```

[!include[](../includes/takeaways-heading.md)]
* `ActivityTriggerAttribute` marks functions as orchestration activities.
* `DurableActivityContext` can be used to access input values for the activities
* Activities functions can return output values. The output must be JSON-serializable.
* A null value will be saved as the output if an orchestrator function returns `Task` or `void`.

[!include[](../includes/read-more-heading.md)]
* [Durable Functions overview](https://docs.microsoft.com/azure/azure-functions/durable-functions-overview)
* [Activity Trigger](https://docs.microsoft.com/azure/azure-functions/durable-functions-bindings#activity-triggers)
* [Durable Functions repo and samples](https://github.com/Azure/azure-functions-durable-extension)