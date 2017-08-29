## Timer Trigger Function

```
using System;

public static void Run(TimerInfo myTimer, TraceWriter log)
{
    if(myTimer.IsPastDue)
    {
        log.Info("Timer is late!");
    }

    log.Info($"C# Timer trigger function executed at: {DateTime.Now}.\n{myTimer.FormatNextOccurrences(5)}"); 
}
```

## Read more
[Create a function in Azure that is triggered by a timer](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-scheduled-function)

[Azure Functions timer trigger](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-timer)