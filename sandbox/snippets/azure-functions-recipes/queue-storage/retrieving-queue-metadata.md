## Retrieving queue metadata from an Azure Storage Queue Trigger
With Storage Queue triggers, the `CloudQueueMessage` class can be used to retrieve metadata about the queue message.
Some common properties include:

* DequeueCount - The number of times this message has been dequeued.
* ExpirationTime - The time that the message expires.
* ID - Queue message ID.
* InsertionTime - TThe time that the message was added to the queue.

```csharp
[FunctionName("QueueTriggerMetadata")]
public static void Run([QueueTrigger("101functionsqueue", Connection = "AzureWebJobsStorage")]CloudQueueMessage myQueueItem, TraceWriter log)
{
    log.Info("101 Azure Function Demo - Retrieving Queue metadata");

    log.Info($"Queue ID: {myQueueItem.Id}");
    log.Info($"Queue Insertion Time: {myQueueItem.InsertionTime}");
    log.Info($"Queue Expiration Time: {myQueueItem.ExpirationTime}");
    log.Info($"Queue Payload: {myQueueItem.AsString}");
}
```

[!include[](../includes/takeaways-heading.md)]
* Using `CloudQueueMessage` as a queue trigger parameter enables metadata retrieval.
* The `AsBytes` and `AsString` methods can be used to return the message payload in the respective format.

[!include[](../includes/read-more-heading.md)]
* [Azure Functions triggers and bindings concepts](https://docs.microsoft.com/azure/azure-functions/functions-triggers-bindings)
* [Azure Functions Queue Storage bindings](https://docs.microsoft.com/azure/azure-functions/functions-bindings-storage-queue#using-a-queue-trigger)
* [Introduction to Queues](https://docs.microsoft.com/azure/storage/queues/storage-queues-introduction)
