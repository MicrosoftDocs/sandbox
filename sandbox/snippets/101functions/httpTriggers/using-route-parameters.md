## Using custom route parameters in HTTP triggers

### Description
In addition to being able to customize the route name, route parameters can also be defined to extract data out of the route.

In the example below, the route parameter `name` is defined in the `Route` property of `HttpTrigger`.

Code
```csharp
[FunctionName("CustomRouteParams")]
public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "RouteParams/{name}")]HttpRequestMessage req, string name, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    // Fetching the name from the path parameter in the request URL
    return req.CreateResponse(HttpStatusCode.OK, new { name });
}

```

Takeaways
* Route parameters are definied on the route in the `Route` property of the `HttpTrigger` attribute
* Method parameters with names matching the route parameters can be add to the function to extract the values

Learn more
* <Add links>