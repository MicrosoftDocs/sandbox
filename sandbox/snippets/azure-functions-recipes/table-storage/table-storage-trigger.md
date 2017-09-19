## Table storage trigger function

Defining a binding between an Azure Function and a table in a storage account can be defined in two different ways. 

The sample functions presented here do not include a trigger and do not work as-is.

Bindings can be declared through code in C# using the `TableAttribute`.

```csharp
public static void Run([Table("Persons")]ICollector<Person> tableBinding, TraceWriter log)
{           
    tableBinding.Add(
        new Person() { 
            PartitionKey = "Default", 
            RowKey = 1, 
            Name = "Some name" }
        );
}
```

Bindings can also be declared through a configuration file. To do so, create a `functions.json` file and define your binding. This binding automatically adds the objects added to the `ICollector` to the defined table.

```json
{
  "bindings": [
    {
      "type": "table",
      "name": "tableBindings",
      "tableName": "Person",
      "direction": "out"
    }
  ],
  "disabled": false
}

```

```csharp
public static void Run(ICollector<Person> tableBinding, TraceWriter log)
{           
    tableBinding.Add(
        new Person() { 
            PartitionKey = "Default", 
            RowKey = 1, 
            Name = "Some name" }
        );
}
```
[!include[](../includes/read-more-heading.md)]

See the [full Table Storage documentation](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-table).
