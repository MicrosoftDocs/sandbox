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