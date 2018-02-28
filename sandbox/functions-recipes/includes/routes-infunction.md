## Define the function route with function properties

There are several ways to define function routes. One of those ways is in the function header.

```csharp
[FunctionName("Example")]
public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route="Example")]HttpRequestMessage req,
                                                   TraceWriter log)
{
    log.Info($"C# HTTP trigger function processed a request");

    return new HttpResponseMessage(HttpStatusCode.Accepted);
}
```

Adding the Route property to the HttpTrigger attribute allows you to customize the route of your function. The above function is called with http://yoururl/api/example. But if we change `Route="Example"` to `Route="Example/MyExample"` the url becomes http://yoururl/api/example/myexample. It can also be left blank so that it can be called by http://yoururl/api/.

[!include[](../includes/takeaways-heading.md)]

- Routes can be customized using the Route property inside of Trigger attributes.
- The function route does not have to match the name of the function.

[!include[](../includes/read-more-heading.md)]

- [Azure Functions HTTP and webhook bindings](https://docs.microsoft.com/azure/azure-functions/functions-bindings-http-webhook)