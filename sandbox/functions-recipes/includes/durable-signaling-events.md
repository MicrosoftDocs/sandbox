## Sending event notifications
Orchestrations can be sent event notifications by using the `RasieEventAsync` method of `DurableOrchestrationClient`. The method must be provided with the instance ID, an event name, and the associated event data.

```csharp
[FunctionName("NotifyEvent")]
public static async Task NotifyEvent(
    [QueueTrigger("event-queue")] NotificationInfo notification,
    [OrchestrationClient] DurableOrchestrationClient orchestrationClient)
{

    await orchestrationClient.RaiseEventAsync(notification.instanceID, notification.EventName, notification.EventData);
}
```

Orchestrations waiting for event notifications can use the `WaitForExternalEvent` method on their `DurableOrchestrationContext` instance. The method takes the event type as a generic type parameter as well as the event name as a function parameter.

```csharp
[FunctionName("PlaceOrder")]
public static async Task<InvoiceData> OrderOrchestration([OrchestrationTrigger] DurableOrchestrationContext context)
{
    OrderRequestData orderData = context.GetInput<OrderRequestData>();

    bool inventoryReserved = await context.CallActivityAsync<bool>("CheckAndReserveInventory", orderData);

    if (!inventoryReserved) {
        await context.WaitForExternalEvent<object>("Proceed");
        await context.CallActivityAsync<bool>("CheckAndReserveInventory", orderData);
    }

    InvoiceData invoice = await context.CallActivityAsync<InvoiceData>("ProcessPayment", orderData);
    return invoice;
}
```

[!include[](../includes/takeaways-heading.md)]
* `RasieEventAsync` method of `DurableOrchestrationClient` can be used to send event notifications to orchestrations.
* `WaitForExternalEvent` on `DurableOrchestrationContext` can be used to pause execution until a notification is received.
* Alternatively, the notification endpoint returned from `CreateCheckStatusResponse` can be used.

[!include[](../includes/read-more-heading.md)]
* [HTTP APIs in Durable Functions](https://docs.microsoft.com/azure/azure-functions/durable-functions-http-api)
* [Debugging and Diagnostics of Durable Functions](https://cda.ms/rH)
* [Durable Functions repo and samples](https://github.com/Azure/azure-functions-durable-extension)
