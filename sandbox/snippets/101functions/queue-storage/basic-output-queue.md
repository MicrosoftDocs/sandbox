## Azure Storage Queue output binding
Azure Storage Queues can be used as output bindings for your Azure Functions app. Using the `Queue` attribute will allow you to make a paramter as a source to push queue messages. Some suported parameter types include:

* out <POCO> -  a .NET POCO will be serialized into JSON before being added to the message payload
* out string
* out byte[]


```csharp
[FunctionName("BasicQueueOutput")]
public static void Run([TimerTrigger("*/30 * * * * *")]TimerInfo myTimer,
                       TraceWriter log,
                       [Queue("101functionsqueue",Connection = "AzureWebJobsStorage")] out string queueMessage)
{
    log.Info("101 Azure Function Demo - Storage Queue output");

    queueMessage = DateTime.UtcNow.ToString();
}
```

[!include[](../includes/takeaways-heading.md)]
* Use the `Queue` attribute .
* The `Queue` attribute requries the name of the queue and the name of the setting that holds the connection information for your storage account.
* If POCOs, strings, and byte arrays are parameters of your function, they must be marked with the `out` keyword.

[!include[](../includes/read-more-heading.md)]
* [Create a function trigger by Azure Storage queue](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-storage-queue-triggered-function)
* [Azure Functions triggers and bindings concepts](https://docs.microsoft.com/en-us/azure/azure-functions/functions-triggers-bindings)
* [Introduction to Queues](https://docs.microsoft.com/en-us/azure/storage/queues/storage-queues-introduction)