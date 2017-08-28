## Basic logging with TraceWriter
To enable basic logging in your functions, you can include a parameter of type `TraceWriter` and an instance will be provided to you. `TraceWritier` is definied in the [Azure WebJobs SDK](https://github.com/Azure/azure-webjobs-sdk/blob/master/src/Microsoft.Azure.WebJobs.Host/TraceWriter.cs). The `tracing` property in `host.json` can be used to configure `TraceWriter`.


Code
```csharp
[FunctionName("TraceWritterLogging")]
public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "GET")]HttpRequestMessage req, TraceWriter log)
{
    log.Info("101 Azure Function Demo - Basic logging with TraceWriter");
    log.Verbose("Here is a verbose log message");
    log.Warning("Here is a warning log message");
    log.Error("Here is an error log message");

    TraceEvent traceEvent = new TraceEvent(TraceLevel.Info, "and another one!");
    log.Trace(traceEvent);

    return req.CreateResponse(HttpStatusCode.OK);
}
```
host.json
```json
{
  "tracing": {   
    "consoleLevel": "verbose"
  }
}
```
Takeaways
* You can optionally include a `TraceWriter` parameter to your function.
* `TraceWriter` provides the `Trace`, `Verbose`, `Info`, `Warning` & `Error` methods.
* `TraceWriter` is a part of the `Microsoft.Azure.WebJobs` package.
* Avoid using `Console.WriteLine` for logging.
* Log levels can be configured in `host.json`. The default log level is `info`.

Learn More
* [Azure Functions C# Developer Reference](https://docs.microsoft.com/en-us/azure/azure-functions/functions-reference-csharp#logging)