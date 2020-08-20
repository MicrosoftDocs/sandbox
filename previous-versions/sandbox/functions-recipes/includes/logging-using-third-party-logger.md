## Logging with a third-party logger
If you would rather use your preferred logger, you can easily do so by just adding a NuGet package.

The following code shows a function using
the [Serilog.Sinks.AzureTableStorage](https://www.nuget.org/packages/serilog.sinks.azuretablestorage) package.

# [C#](#tab/csharp) 

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

# [F#](#tab/fsharp) 

```fsharp
[<FunctionName("ThirdPartyLogger")>]
let Run([<HttpTrigger(AuthorizationLevel.Anonymous, "GET")>] req: HttpRequestMessage) =
  let connectionString = Environment.GetEnvironmentVariable("StorageAccountConnectionString", EnvironmentVariableTarget.Process)

  let tableName = Environment.GetEnvironmentVariable("StorageAccountTableName", EnvironmentVariableTarget.Process)

  let log = LoggerConfiguration()
              .WriteTo
              .AzureTableStorage(connectionString, storageTableName = tableName, restrictedToMinimumLevel = LogEventLevel.Verbose)
              .CreateLogger()

  log.Debug("Here is a debug message {message}", "with some structured content")

  log.Verbose "Here is a verbose log message"
  log.Warning "Here is a warning log message"
  log.Error "Here is an error log message"

  req.CreateResponse HttpStatusCode.OK
```

[!include[](../includes/takeaways-heading.md)]
* Alternative loggers can be used to capture log information from your functions.
* You can use NuGet to not only add loggers, but extend your functions with other functionality.

[!include[](../includes/read-more-heading.md)]
* [Serilog](https://serilog.net/)
* [Azure Functions C# Developer Reference](https://docs.microsoft.com/azure/azure-functions/functions-reference-csharp#logging)