## Configuring queues

Functions that depend on queues can have the behavior of the queues customized. 

Among the different possibilities, it's possible to set a polling interval, retry interval, as well as the size of the batch of messages to process in parallel.


```json
{
  "queues": {
    // Interval in milliseconds
    "maxPollingInterval": 2000,
    // Time between calls/retries
    "visibilityTimeout": "00:00:30",
    //Maximum of 32
    "batchSize": 16
  }
}
```

[!include[](../includes/read-more-heading.md)]

For the full range of options, look up the [complete documentation of host.json](https://github.com/Azure/azure-webjobs-sdk-script/wiki/host.json).