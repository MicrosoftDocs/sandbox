## Triggering functions from Azure Service Bus Queues and Topics
Queues and Topics from Azure Service Bus can be used as triggers for your functions.

Using the `ServiceBusTrigger` attribute, you can supply the queue or topic name, along with the connection information for the Service Bus instance.

```csharp
 [FunctionName("ServiceBusQueueTrigger)]
 public static void Run([ServiceBusTrigger("funcqueue", AccessRights.Manage, Connection = "ConnectionSetting")]string queueMessage,
                        TraceWriter log)
 {
     log.Info("101 Azure Function Demo - Service Bus Queue Trigger");

     log.Info($"C# ServiceBus queue trigger function processed message: {queueMessage}");
 }
```
Topic Trigger
```csharp
[FunctionName("ServiceBusTopicTrigger")]
public static void RunTopic([ServiceBusTrigger("functopic","sampletopic", AccessRights.Manage, Connection = "ConnectionSetting")]string topicMessage,
                             TraceWriter log)
{
    log.Info("101 Azure Function Demo - Service Bus Topic Trigger");

    log.Info($"C# ServiceBus topic trigger function processed message: {topicMessage}");
}

```
[!include[](../includes/takeaways-heading.md)]
* Use the `ServiceBusTrigger` attribute to specify the Azure Service Bus instance.
* For queues, `ServiceBusTrigger` requires the queue name, and the name of the setting that has connection information.
* For topics, `ServiceBusTrigger` requires the topic name, subscription name, and the  name of the setting that has connection information.

[!include[](../includes/read-more-heading.md)]
* [Azure Functions Service Bus bindings](https://docs.microsoft.com/azure/azure-functions/functions-bindings-service-bus)
* [Service Bus Messaging documentation](https://docs.microsoft.com/azure/service-bus-messaging/)
* [Service Bus client samples](https://github.com/Azure/azure-service-bus/tree/master/samples)