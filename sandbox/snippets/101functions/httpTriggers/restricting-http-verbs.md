## Restricting HTTP verbs in in HTTP Triggers

With the `HttpTrigger` attribute, you can list one or more HTTP verbs that your function will respond to.


```csharp
// Respond to only GET requests
Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "GET")]HttpRequestMessage req, TraceWriter log)

// Respond to  GET or PUT requests
Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "GET", "PUT")]HttpRequestMessage req, TraceWriter log)
```

Takeaways
* Using the `HttpTrigger` trigger you can list supported HTTP verbs.
* Always specify one or more HTTP verbs to respond to.

Learn More
* [Azure Functions HTTP and webhook bindings](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-http-webhook)
* [Method Definitions](https://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html)