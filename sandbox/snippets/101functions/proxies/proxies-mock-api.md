## Creating a mock API

Azure Functions Proxies can return custom responses without a backend service. It can be used to create a mock API.

Here is the `proxies.json` of a mock API that responds to GET and POST requests.

```json
{
  "proxies": {
    "Mock API - GET": {
      "matchCondition": {
        "methods": [
          "GET"
        ],
        "route": "/api/v1/orders/{orderId}"
      },
      "responseOverrides": {
        "response.statusCode": "200",
        "response.headers.Content-Type": "application/json",
        "response.body": {
          "id": "{orderId}",
          "total": 100,
          "items": [
            {
              "item": "2e649ae3-09f2-474a-bec6-0d066d32cd0a",
              "quantity": 5,
              "price": 20
            }
          ]
        }
      }
    },
    "Mock API - POST": {
      "matchCondition": {
        "methods": [
          "POST"
        ],
        "route": "/api/v1/orders"
      },
      "responseOverrides": {
        "response.statusCode": "201",
        "response.headers.Location": "https://%WEBSITE_HOSTNAME%/api/v1/orders/d0458144-407c-4f05-aa8d-90102c488603"
      }
    }
  }
}
```

[!include[](../includes/takeaways-heading.md)]

- Proxies can be used to set the status code, headers, and body of a response.
- Proxies can be configured to without a `backendUri`. 

[!include[](../includes/read-more-heading.md)]

- [Azure Functions Proxies documentation](https://docs.microsoft.com/en-us/azure/azure-functions/functions-proxies)
