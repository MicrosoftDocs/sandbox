## Blob Trigger Function

This example reads the contents of a text object in a blob container.

```
using System.Text;

public static async Task Run(Stream myBlob, TraceWriter log)
{  
    log.Info("Blob trigger processed. Reading contents:");

    var contents = new byte[myBlob.Length];
    await myBlob.ReadAsync(contents, 0, (int)myBlob.Length);
    log.Info(Encoding.ASCII.GetString(contents));
}
```

## Read More
[Create a function triggered by Azure Blob storage](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-storage-blob-triggered-function)
[Azure Functions Blob Storage Bindings](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-blob)