## Making route parameters optional

In order to make route parameters optional in your function call, add a `?` after the parameter name in the route definition and the type in the function header.

```csharp
[FunctionName("Example")]
public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route="Example/{parameter?}")]HttpRequestMessage req,
                                                  string? parameter,
                                                  TraceWriter log)
{
    log.Info($"C# HTTP trigger function processed a request {parameter}");

    return new HttpResponseMessage(HttpStatusCode.Accepted);
}
```

If you are specifying a parameter type, put the `?` after the type name like so: `{parameter:int?}`

[!include[](../includes/takeaways-heading.md)]

 - Parameters can be optional in functions.
 - All you need to do to make them optional is add a `?` after the parameter in the route.

[!include[](../includes/read-more-heading.md)]

 - [Azure Functions HTTP and webhook bindings](https://docs.microsoft.com/azure/azure-functions/functions-bindings-http-webhook)