## Accessing the request body  in HTTP Triggers

### Description
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

Code
```csharp
[FunctionName("ReadingRequestBody")]
public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "POST", Route = null)]HttpRequestMessage req, TraceWriter log)
{
    log.Info("101 Azure Function Demo - Reading the request body in HTTP Triggers");

    // Read body
    var data = await req.Content.ReadAsAsync<Customer>();

    // Echo request data back in the response
    return  req.CreateResponse(HttpStatusCode.OK, data);
}

public class Customer
{
    public string FirstName { get; set; }
    public bool IsDisabled { get; set; }
}

```

Takeaways
* Use the `ReadAsAsync` method to serialize the request body to a specified object type.
* JSON and XML content types are supported out of the box
* JSON serialization uses JSON.NET
* Other methods available to ready body content include `ReadAsStringAsync`, `ReadAsStreamAsync` and `ReadAsByteArrayAsync`.

Learn more
* <Add links>