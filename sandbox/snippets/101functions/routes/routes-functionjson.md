## Define the function route in function.json

Another option for controlling function routes is in the "route" property of the bindings array in the function.json file.

```json
"bindings": [
    {
        "type": "httpTrigger",
        "name": "req",
        "direction": "in",
        "methods": [ "get" ],
        "route": "example/myexample"
    }
]
```

This will typically be seen if you are developing functions in the Azure Portal.

[!include[](../includes/takeaways-heading.md)]

- Function routes can be changed in the function.json file.

[!include[](../includes/read-more-heading.md)]

- [More on the function.json file](https://github.com/Azure/azure-webjobs-sdk-script/wiki/function.json)