## Creating an HTTP Redirect

Azure Functions Proxies can be configured to return a custom response. You can use it to return custom HTTP status codes and headers. For a permanent redirect, respond with a 301 status code. For a temporary redirect, respond with 302. Indicate the URL to redirect to in the `Location` header.

To configure proxies, edit `proxies.json`.

```json
{
  "proxies": {
    "permanent redirect": {
      "matchCondition": {
        "methods": [
          "GET"
        ],
        "route": "/permanent"
      },
      "responseOverrides": {
        "response.statusCode": "301",
        "response.headers.Location": "https://docs.microsoft.com/"
      }
    },
    "temporary redirect": {
      "matchCondition": {
        "methods": [
          "GET"
        ],
        "route": "/temporary"
      },
      "responseOverrides": {
        "response.statusCode": "302",
        "response.headers.Location": "https://dosc.microsoft.com/"
      }
    }
  }
}
```

[!include[](../includes/takeaways-heading.md)]

- Azure Functions Proxies are configured using `proxies.json`.
- You can edit `proxies.json` using App Service Editor. 

[!include[](../includes/read-more-heading.md)]

- [Azure Functions Proxies documentation](https://docs.microsoft.com/en-us/azure/azure-functions/functions-proxies)
