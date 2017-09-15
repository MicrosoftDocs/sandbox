## Returning conditional responses based on backend response codes

Azure Functions Proxies can be configured to return a custom responses based on the backend response.

To configure proxies, edit `proxies.json`.

```json
{
  "proxies": {
    "statuses": {
      "matchCondition": {
        "methods": [
          "GET"
        ],
        "route": "/status/{code}"
      },
      "backendUri": "https://httpbin.org/status/{code}",
      "responseOverrides": {
        "backend.response.statusCode": {
          "401": {
            "response.statusCode": 302,
            "response.headers.Location": "https://myloginpage"
          },
          "418": {
            "response.headers.Content-Type": "text/plain",
            "response.body": "I'm a teapot"
          },
          "5xx": {
            "response.headers.Content-Type": "application/json",
            "response.body": {
              "statusCode": "{backend.response.statusCode}"
            }
          }
        }
      }
    }
  }
}
```

[!include[](../includes/takeaways-heading.md)]

- Azure Functions Proxies are configured using `proxies.json`.
- Proxies can customize the response based on the backend response status code. 

[!include[](../includes/read-more-heading.md)]

- [Azure Functions Proxies documentation](https://docs.microsoft.com/en-us/azure/azure-functions/functions-proxies)
- [Proxies Sample](https://gist.github.com/sjkp/890d94b958965898e45e69bf199c88d4)
