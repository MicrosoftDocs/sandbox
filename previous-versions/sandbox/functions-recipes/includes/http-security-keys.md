## Securing HTTP Triggers with security keys

When creating your function, you have the option of allowing it to be called by anyone (Anonymous) or to require a security key.

When making a request to a secure function, you are required to provide the security key as shown.

`http://&lt;your-function-url&gt;/api/function-name?code=<your-key>`

Keys are stored as part of your function app in Azure and are encrypted at rest. To view your keys, create new ones, or roll keys to new values, navigate to one of your functions within the Azure portal.

```csharp
[FunctionName("SecuredFunction")]
public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "GET")]HttpRequestMessage req, TraceWriter log)
{
    log.Info("Azure Function Demos - Restricting HTTP verbs");

    return  req.CreateResponse(HttpStatusCode.OK, "Secure Response");
}
```

[!include[](../includes/takeaways-heading.md)]
* There are two types of keys that can be used to secure your Azure Function; Host and Function.
* Host keys are shared by all functions in the same function app.
* Function keys apply only to the specific function where they are defined.
* Anonymous functions can be called by anyone.
* The `AuthorizationLevel` enum contains the levels of security you can set on the `HttpTrigger` attribute.
* In the HTTP request, keys can be specified in a `code` query string parameter or a `x-functions-key` HTTP header

[!include[](../includes/read-more-heading.md)]
* [Working with Keys](https://docs.microsoft.com/azure/azure-functions/functions-bindings-http-webhook#working-with-keys)