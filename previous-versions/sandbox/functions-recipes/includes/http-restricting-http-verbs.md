## Restricting HTTP verbs in HTTP Triggers

With the `HttpTrigger` attribute, you can list one or more HTTP verbs that your function responds to.


```csharp
// Respond to only GET requests
Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "GET")]HttpRequestMessage req, TraceWriter log)
{
    // ...
}

// Respond to  GET or PUT requests
Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "GET", "PUT")]HttpRequestMessage req, TraceWriter log)
{
    // ...
}
```

[!include[](../includes/takeaways-heading.md)]
* Using the `HttpTrigger` trigger you can list supported HTTP verbs.
* Always specify one or more HTTP verbs to respond to.

[!include[](../includes/read-more-heading.md)]
* [Azure Functions HTTP and webhook bindings](https://docs.microsoft.com/azure/azure-functions/functions-bindings-http-webhook)
* [Method Definitions](https://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html)