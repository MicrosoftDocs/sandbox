## Configuring timeout

Timeouts allow the host to determine when the function will timeout.

On a Consumption plan, the valid values are between 1 second (`00:00:01`) and 10 minutes (`00:10:00`). On an App Service Plan, any interval can be used including null. Setting it to null will have it wait indefinitely.

```json
{
    "functionTimeout": "00:05:00"
}
```
