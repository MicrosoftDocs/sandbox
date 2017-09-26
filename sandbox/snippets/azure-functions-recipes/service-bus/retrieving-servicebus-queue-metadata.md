## Retrieving queue metadata from an Azure Service Bus Queue/Topic Trigger
With the Service Bus Trigger, the `BrokeredMessage` class can be used to retrieve metadata about the queue message.

Some common properties include:
* ContentType - Type of the message content
* MessageId - User-defined identifier
* Size - Size of the message in bytes
* ExpiresAtUtc - Date and time in UTC when the message expires

```csharp
[FunctionName("ServiceBusTriggerThingy")]
public static void Run([ServiceBusTrigger("funcqueue", AccessRights.Manage, Connection = "Func101SB")]BrokeredMessage queueMessage,
                        TraceWriter log)
{
    log.Info("101 Azure Function Demo - Service Bus Queue Trigger");

    log.Info($"Message ID: {queueMessage.MessageId}");
    log.Info($"Message Content Type: {queueMessage.ContentType}");
}

```

[!include[](../includes/takeaways-heading.md)]
* Use the `ServiceBus` attribute to specify the output binding to an Azure Service Bus Queue.
* The `ServiceBus` attribute requires the name of the queue, an `EntityType`, and the name of the setting for the Azure Service Bus connection string.
* If POCOs, strings, and byte arrays are parameters of your function, they must be marked with the `out` keyword.

[!include[](../includes/read-more-heading.md)]
* [Azure Functions Service Bus bindings](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-service-bus)
* [Service Bus Messaging documentation](https://docs.microsoft.com/en-us/azure/service-bus-messaging/)
* [Service Bus client samples](https://github.com/Azure/azure-service-bus/tree/master/samples)