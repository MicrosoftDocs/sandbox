## Accessing Environment variables

You may need to store custom settings for your Azure function. One availabe option is to use Environment variables. You can manage these settings in the `Application settings` section of your function app in the Azure portal.


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
* Environment varibles get configured in the `Application Settings` section
* Use the static `GetEnvironmentVariable` method of the `Environment` type to get access to the

[!include[](../includes/read-more-heading.md)]
* [Environment Variables](https://docs.microsoft.com/azure/azure-functions/functions-reference-csharp#environment-variables)