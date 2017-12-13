## Using ICollector with Service Bus queue bindings
`ICollector` and `IAsyncCollector` can be used as parameter types for Azure Service Bus output bindings. Using these interfaces allows you to add multiple messages to the respective Service Bus queue or topic.

```csharp
[FunctionName("CollectorQueueOutput")]
public static void Run([TimerTrigger("*/10 * * * * *")]TimerInfo myTimer,
                       TraceWriter log,
                     [ServiceBus("funcqueue", Connection = "ConnectionSetting", EntityType = EntityType.Queue)] ICollector<string> queueCollector)
{
    log.Info("101 Azure Function Demo - Azure Service Bus output");

    queueCollector.Add(DateTime.UtcNow.ToString());
    queueCollector.Add("Sample");
    queueCollector.Add("Message");
}        
```

[!include[](../includes/takeaways-heading.md)]
*  Using `ICollector` or `IAsyncCollector` allows you to output multiple messages to a Service Bus queue or topic.

[!include[](../includes/read-more-heading.md)]
* [Azure Functions Service Bus bindings](https://docs.microsoft.com/azure/azure-functions/functions-bindings-service-bus)
* [Service Bus Messaging documentations](https://docs.microsoft.com/azure/service-bus-messaging/)
* [Service Bus client samples](https://github.com/Azure/azure-service-bus/tree/master/samples)