## Retrieving queue metadata from an Azure Service Bus Queue/Topic Trigger
With the Service Bus Trigger, the `BrokeredMessage` class can be used to retrieve metadata about the queue message.

Some common properties include:
* `ContentType` - Type of the message content
* `MessageId` - User-defined identifier
* `Size` - Size of the message in bytes
* `ExpiresAtUtc` - Date and time in UTC when the message expires

```csharp
[FunctionName("ServiceBusQueuesTrigger")]
public static void Run([ServiceBusTrigger("funcqueue", AccessRights.Manage, Connection = "Func101SB")]BrokeredMessage queueMessage,
                        TraceWriter log)
{
    log.Info("101 Azure Function Demo - Service Bus Queue Trigger");

    log.Info($"Message ID: {queueMessage.MessageId}");
    log.Info($"Message Content Type: {queueMessage.ContentType}");
}

```

[!include[](../includes/takeaways-heading.md)]
* Use `BrokeredMessage` if you need access to properties of the input message.

[!include[](../includes/read-more-heading.md)]
* [Azure Functions Service Bus bindings](https://docs.microsoft.com/azure/azure-functions/functions-bindings-service-bus)
* [Service Bus Messaging documentation](https://docs.microsoft.com/azure/service-bus-messaging/)
* [Service Bus client samples](https://github.com/Azure/azure-service-bus/tree/master/samples)