## Accessing environment variables

You may need to store custom settings for your Azure function. One available option is to use environment variables. You can manage these settings in the `Application settings` section of your function app in the Azure portal.


```csharp
[FunctionName("CustomSettings")]
public static Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "GET")]HttpRequestMessage req, TraceWriter log)
{
    log.Info("101 Azure Function Demo - Accessing Environment variables");
    var customSetting =  Environment.GetEnvironmentVariable("CustomSetting", EnvironmentVariableTarget.Process);
    return Task.FromResult(req.CreateResponse(HttpStatusCode.OK, new { setting= customSetting }));
}
```

[!include[](../includes/takeaways-heading.md)]
* Environment variables are configured in the `Application Settings` section
* Use the static `GetEnvironmentVariable` method of the `Environment` type to get access to the

[!include[](../includes/read-more-heading.md)]
* [Environment Variables](https://docs.microsoft.com/azure/azure-functions/functions-dotnet-class-library#environment-variables)