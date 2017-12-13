## Adding parameters to function routes

To add parameters to your route, and to use them in your function, you must put the parameter in curly braces in the route, and define it in the method parameters like so:

```csharp
[FunctionName("Example")]
public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route="Example/{parameter}")]HttpRequestMessage req, string parameter, TraceWriter log)
{
    log.Info($"C# HTTP trigger function processed a request {parameter}");

    return new HttpResponseMessage(HttpStatusCode.Accepted);
}
```
If only the parameter name is entered, it defaults to type string. If you want to use another type, enter the parameter as `{parameter:type}` to change the type. If you do this, you will also need to change the type in the function header.

[!include[](../includes/takeaways-heading.md)]

- Parameters are defined in the route surrounded with curly braces, and must also be defined in the method parameters.
- This works whether you define the route in the function header, function.json, or Azure portal.

[!include[](../includes/read-more-heading.md)]

- [Azure Functions HTTP and webhook bindings](https://docs.microsoft.com/azure/azure-functions/functions-bindings-http-webhook)