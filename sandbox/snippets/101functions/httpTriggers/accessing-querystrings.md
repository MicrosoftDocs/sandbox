## Accessing querystring values in Http Triggers

When making HTTP request, you have the ability of supplying addional parameters via a query string to the request URL which can be retrieved from by the website or web api to alter how the response is returned.

The example below appends 2 query string variables along with their associated values
:

   `http://&lt;your-function-url&gt;/api/function-name?page=1&orderby=name`

Code
```csharp
[FunctionName("AccessQueryString")]
public static Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "GET")]HttpRequestMessage req, TraceWriter log)
{
    log.Info("101 Azure Function Demo - Accessing the query string values in HTTP Triggers");

    // Retrieve query parameters
    var values = req.GetQueryNameValuePairs();

    // Write query parameters to log
    foreach (var val in values)
    {
        log.Info($"Parameter: {val.Key}\nValue: {val.Value}\n");
    }

    // return query parameters in response
    return Task.FromResult(req.CreateResponse(HttpStatusCode.OK, values));
}

```

Takeaways
* Use the `GetQueryNameValuePairs` of `HttpRequestMessage` to retrieve query string parameters
* `GetQueryNameValuePairs` returns a list of KeyValuePairs<string, string>

Learn more
* [Azure Functions HTTP and webhook bindings](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-http-webhook)
*  [Create a function triggered by a generic webhook](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-generic-webhook-triggered-function)