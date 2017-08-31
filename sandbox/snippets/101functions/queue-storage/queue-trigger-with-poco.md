## Azure Storage Queue Trigger using a POCO
If your queue message is made up of a JSON payload, the runtime serializes it into a POCO for you.

```csharp
[FunctionName("SimpleQueue")]
public static void Run([QueueTrigger("101functionsqueue", Connection = "AzureWebJobsStorage")]Customer queuedCustomer, TraceWriter log)
{
    log.Info("101 Azure Functions Demo -  Queue Trigger w/ POCO");

    log.Info($"Customer Name: {queuedCustomer.FirstName}");
}
```

[!include[](../includes/takeaways-heading.md)]
* JSON payloads can be serialized into POCO objects
* JSON .NET types can also be used, e.g. `JOject`, `JArray`

[!include[](../includes/read-more-heading.md)]
* [Create a function trigger by Azure Storage queue](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-storage-queue-triggered-function)
* [Azure Functions triggers and bindings concepts](https://docs.microsoft.com/en-us/azure/azure-functions/functions-triggers-bindings)
* [Introduction to Queues](https://docs.microsoft.com/en-us/azure/storage/queues/storage-queues-introduction)
* [JSON .NET Documentation](https://www.newtonsoft.com/json/help/html/Introduction.htm)