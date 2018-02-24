## Accessing query string values in Http Triggers

When making HTTP requests, you have the ability of supplying additional parameters via a query string. These parameters can be retrieved to alter how the response is returned.

The following example appends two query string variables along with their associated values:

   `http://<your-function-url>/api/function-name?page=1&orderby=name`

```csharp
[FunctionName("AccessQueryString")]
public static Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "GET")]HttpRequestMessage req, TraceWriter log)
{
    log.Info("101 Azure Function Demo - Accessing the query string values in HTTP Triggers");

    // Retrieve query parameters
    IEnumerable<KeyValuePair<string, string>> values = req.GetQueryNameValuePairs();

    // Write query parameters to log
    foreach (KeyValuePair<string, string> val in values)
    {
        log.Info($"Parameter: {val.Key}\nValue: {val.Value}\n");
    }

    // return query parameters in response
    return Task.FromResult(req.CreateResponse(HttpStatusCode.OK, values));
}

```

[!include[](../includes/takeaways-heading.md)]
* Use the `GetQueryNameValuePairs` method of `HttpRequestMessage` to retrieve query string parameters
* `GetQueryNameValuePairs` returns a list of `KeyValuePairs<string, string>`

[!include[](../includes/read-more-heading.md)]
* [Azure Functions HTTP and webhook bindings](https://docs.microsoft.com/azure/azure-functions/functions-bindings-http-webhook)
*  [Create a function triggered by a generic webhook](https://docs.microsoft.com/azure/azure-functions/functions-create-generic-webhook-triggered-function)