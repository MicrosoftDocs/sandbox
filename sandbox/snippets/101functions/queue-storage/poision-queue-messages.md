## Poison queue messages with Azure Storage Queue Triggers
If a function triggered by a `QueueTrigger` fails, the Azure Functions runtime will automatically try that function five times for that specific queue message.
If the message continues to fail, then the bad message will moved to a "poison" queue. The name of the queue will be based on the original + "-poison".

For example, for a storage queue named `myqueue` then resultant poison queue will be named `myqueue-poison`.


```csharp
[FunctionName("PoisionQueues")]
public static void Run([QueueTrigger("101functionsqueue", Connection = "AzureWebJobsStorage")]CloudQueueMessage myQueueItem, TraceWriter log)
{
    log.Info("101 Azure Function Demo - Poision Queue Messages");


    log.Info($"Queue ID: {myQueueItem.Id}");
    log.Info($"Queue Dequeue Count: {myQueueItem.DequeueCount}");
    log.Info($"Queue Payload: {myQueueItem.AsString}");

    throw new Exception("Intentional failure");
}
```

After letting the code above run, there should be a queue names `101functionsqueue-poison` with the message that failed to process.

[!include[](../includes/takeaways-heading.md)]
* Using `CloudQueueMessage`, metadata such a the message dequeue count can be retrieved.
* Five attempts will be made to process a queue message before moving it to a poison queue.


[!include[](../includes/read-more-heading.md)]
* [Azure Functions triggers and bindings concepts](https://docs.microsoft.com/azure/azure-functions/functions-triggers-bindings)
* [Azure Functions Queue Storage bindings](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-queue#trigger-sample)
* [Introduction to Queues](https://docs.microsoft.com/azure/storage/queues/storage-queues-introduction)
