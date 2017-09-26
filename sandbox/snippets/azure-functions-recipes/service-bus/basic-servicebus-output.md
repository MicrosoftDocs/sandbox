## Azure Service Bus output binding
Azure Service Bus can be used as output bindings for your Azure Functions app. Using the `ServiceBus` attribute allows you to take a parameter as a source to push queue messages. Some supported parameter types include:

* out <POCO> -  a .NET POCO is serialized into JSON before being added to the message payload
* out string
* out byte[]


```csharp
[FunctionName("ServiceBusOutput")]
public static void Run([TimerTrigger("0/10 * * * * *")]TimerInfo myTimer,
                       TraceWriter log,
                       [ServiceBus("funcqueue", Connection = "ConnectionSetting", EntityType = EntityType.Queue)]out string queueMessage)
{
    log.Info("101 Azure Function Demo - Azure Service Bus Queue output");

    queueMessage = DateTime.UtcNow.ToString();
}
```

[!include[](../includes/takeaways-heading.md)]
* Use the `ServiceBus` attribute to specify the output binding to an Azure Service Bus Queue.
* The `ServiceBus` attribute requires the name of the queue, an `EntityType`, and the name of the setting for the Azure Service Bus connection string.
* If POCOs, strings, and byte arrays are parameters of your function, they must be marked with the `out` keyword.

[!include[](../includes/read-more-heading.md)]
* [Azure Functions Service Bus bindings](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-service-bus)
* [Service Bus Messaging documentations](https://docs.microsoft.com/en-us/azure/service-bus-messaging/)
* [Service Bus client samples](https://github.com/Azure/azure-service-bus/tree/master/samples)