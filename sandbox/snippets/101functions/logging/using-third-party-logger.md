## Logging with a third party logger
If you rather use your preferred logger, you can easily do so by just adding a NuGet package.

The code below shows a function leveraging
the [Serilog.Sinks.AzureTableStorage](https://www.nuget.org/packages/serilog.sinks.azuretablestorage) package.


```csharp
[FunctionName("ThirdPartyLogger")]
public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "GET")]HttpRequestMessage req)
{

    string connectionString = Environment.GetEnvironmentVariable("StorageAccountConnectionString", EnvironmentVariableTarget.Process);

    string tableName = Environment.GetEnvironmentVariable("StorageAccountTableName", EnvironmentVariableTarget.Process);

    Logger log = new LoggerConfiguration()
                .WriteTo.AzureTableStorage(connectionString, storageTableName: tableName, restrictedToMinimumLevel: LogEventLevel.Verbose)
                .CreateLogger();

    log.Debug("Here is a debug message {message}", "with some structured content");

    log.Verbose("Here is a verbose log message");
    log.Warning("Here is a warning log message");
    log.Error("Here is an error log message");

    return req.CreateResponse(HttpStatusCode.OK);
}
```

Takeaways
* Alternative loggers can be used to capture log information from your functions
* You can use NuGet to not only add loggers, but extend your functions with various functionality

Learn More
* [Serilog](https://serilog.net/)
* [Azure Functions C# Developer Reference](https://docs.microsoft.com/en-us/azure/azure-functions/functions-reference-csharp#logging)