## Controlling the route prefix with host.json

By default Azure Functions has a route prefix on all functions /api/. To change this, access the routePrefix property in the http field of host.json. To remove it completely, leave the field blank.

```json
{
  "http": {
    "routePrefix": ""
  }
}
```

This would turn http://yourUrl/api/Example into http://yourUrl/Example.

[!include[](../includes/takeaways-heading.md)]

- Route prefixes are customizable and removable using host.json.

[!include[](../includes/read-more-heading.md)]

- [More on host.json](https://github.com/Azure/azure-webjobs-sdk-script/wiki/host.json)