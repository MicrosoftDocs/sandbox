## Using ICollector with Azure Storage Queue bindings
One way to trigger your Azure Function is to use a queue defined in an Azure storage account.

Using the `QueueTrigger` attribute, you can supply the queue name and connection information of the storage account queue that your function monitors for messages.


```csharp
[FunctionName("CollectorQueueOutput")]
public static void Run([TimerTrigger("*/30 * * * * *")]TimerInfo myTimer,
                       TraceWriter log,
                       [Queue("101functionsqueue", Connection = "AzureWebJobsStorage")] ICollector<Customer> queueCollector)
{
    log.Info("101 Azure Function Demo - Storage Queue output");

    queueCollector.Add(new Customer { FirstName = "John" });

}
```

[!include[](../includes/takeaways-heading.md)]
* Use the `QueueTrigger` attribute to trigger your function via an Azure Storage Queue.
* `QueueTrigger` requires the name of the queue and the name of the setting that holds the connection information for your storage account.
* The queue name and connection values are required.

[!include[](../includes/read-more-heading.md)]
* [Create a function trigger by Azure Storage queue](https://docs.microsoft.com/azure/azure-functions/functions-create-storage-queue-triggered-function)
* [Azure Functions triggers and bindings concepts](https://docs.microsoft.com/azure/azure-functions/functions-triggers-bindings)
* [Introduction to Queues](https://docs.microsoft.com/azure/storage/queues/storage-queues-introduction)