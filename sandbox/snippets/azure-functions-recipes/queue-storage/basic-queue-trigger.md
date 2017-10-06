## Triggering via Azure Storage Queue
Storage Queues can be used as triggers for your functions.

Using the `QueuesTrigger` attribute, you can supply the queue along with the connection information for the storage account that should be used.


```csharp
 [FunctionName("FunctionsQueueTrigger")]
 public static void Run([QueueTrigger("101functionsqueue", Connection = "AzureWebJobsStorage")]string myQueueItem,
     TraceWriter log)
 {
     log.Info($"C# Queue trigger function processed: {myQueueItem}");
 }

```

[!include[](../includes/takeaways-heading.md)]
* Use the `QueueTrigger` attribute to trigger your function via an Azure Storage Queue.
* `QueueTrigger` requires the name of the queue and the name of the setting that holds the connection information for your storage account.

[!include[](../includes/read-more-heading.md)]
* [Create a function trigger by Azure Storage queue](https://docs.microsoft.com/azure/azure-functions/functions-create-storage-queue-triggered-function)
* [Azure Functions triggers and bindings concepts](https://docs.microsoft.com/azure/azure-functions/functions-triggers-bindings)
* [Introduction to Queues](https://docs.microsoft.com/azure/storage/queues/storage-queues-introduction)