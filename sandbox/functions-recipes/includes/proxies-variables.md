## Referencing application settings

Azure Functions Proxies configurations can reference application settings and other environment variables using `%` signs.

To configure proxies, edit `proxies.json`.

```json
{
  "proxies": {
    "statuses": {
      "matchCondition": {
        "methods": [
          "GET"
        ],
        "route": "/test/{id}"
      },
      "backendUri": "https://%WEBSITE_HOSTNAME%/{id}",
      "responseOverrides": {
        "response.statusCode": "200",
        "response.headers.Content-Type": "application/json",
        "response.body": {
          "id": "{id}",
          "value": "%DEFAULT_VALUE%"
        }
      }
    }
  }
}
```

[!include[](../includes/takeaways-heading.md)]
- Azure Functions Proxies are configured using `proxies.json`.
- Proxies configuration can reference environment variables and application settings. 

[!include[](../includes/read-more-heading.md)]

- [Azure Functions Proxies documentation](https://docs.microsoft.com/en-us/azure/azure-functions/functions-proxies)
