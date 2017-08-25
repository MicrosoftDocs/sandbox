## Definig custom routes in HTTP triggers

### Description


Code
```csharp

[FunctionName("CustomRoute")]
public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "MyCustomRouteName")]HttpRequestMessage req, TraceWriter log)
{
    log.Info("101 Azure Function Demo - Accessing Environment variables");

    // Fetching the name from the path parameter in the request URL
    return req.CreateResponse(HttpStatusCode.OK);
}

```

Takeaways
* The `HttpTrigger` attribute has a `Route` property that can be used to define custom route names
* The value of `Route` can be any valid 
*  HTTP routes for Azure functions always begin with `/api`

Learn more
