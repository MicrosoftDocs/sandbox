## Accessing the request body  in HTTP Triggers

When making HTTP requests, you may need to pass on additional data via the body of the request. You can easily get access to content of the message body using `HttpRequestMessage`.

JSON body content
```json
{
	"firstname" : "Scott",
	"isdisabled" : "true"
}
```
XML body content
```xml
<Customer xmlns="http://schemas.datacontract.org/2004/07/Demos">
	<FirstName>cecil</FirstName>
	<IsDisabled>true</IsDisabled>
</Customer>
```


```csharp
[FunctionName("ReadingRequestBody")]
public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "POST", Route = null)]HttpRequestMessage req, TraceWriter log)
{
    log.Info("101 Azure Function Demo - Reading the request body in HTTP Triggers");

    // Read body
    Customer data = await req.Content.ReadAsAsync<Customer>();

    // Echo request data back in the response
    return  req.CreateResponse(HttpStatusCode.OK, data);
}

public class Customer
{
    public string FirstName { get; set; }
    public bool IsDisabled { get; set; }
}

```

[!include[](../includes/takeaways-heading.md)]
* Use the `ReadAsAsync` method to deserialize the request body to a specified object type.
* `application/json` and `application/xml` content types are supported out of the box. Ensure the `Content-type` header is properly set.
* JSON serialization uses JSON.NET.
* Other methods available to ready body content include `ReadAsStringAsync`, `ReadAsStreamAsync` and, `ReadAsByteArrayAsync`.

[!include[](../includes/read-more-heading.md)]
* [HttpRequestMessage](https://docs.microsoft.com/dotnet/api/system.net.http.httprequestmessage)
* [HttpResponseMessage](https://docs.microsoft.com/dotnet/api/system.net.http.httpresponsemessage)