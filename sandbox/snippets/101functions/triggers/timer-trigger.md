## Timer Trigger Function

Functions can be triggered on a schedule. This examples logs the time, and the next 5 occurrences when a function timer is triggered or logs when it is late. 

```csharp
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

[!include[](../includes/takeaways-heading.md)]

- Use `IsPastDue` to find out if a timer trigger is delayed.
- The trigger schedule can be altered in the Integrate section of your function in the Azure portal, or in the function's `function.json` file.

[!include[](../includes/read-more-heading.md)]

[Create a function in Azure that is triggered by a timer](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-scheduled-function)

[Azure Functions timer trigger](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-timer)