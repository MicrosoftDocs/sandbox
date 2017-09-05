## Blob Trigger Function

This example reads and logs the contents of a text object in a blob container. This requires a blob storage account and a container for blobs.

```csharp
using System.Text;

public static async Task Run(Stream myBlob, TraceWriter log)
{  
    log.Info("Blob trigger processed. Reading contents:");

    var contents = new byte[myBlob.Length];
    await myBlob.ReadAsync(contents, 0, (int)myBlob.Length);
    log.Info(Encoding.ASCII.GetString(contents));
}
```

[!include[](../includes/takeaways-heading.md)]

- `myBlob` is a combination of the blob container and blob: `blob-container/blob-name.extension`

[!include[](../includes/read-more-heading.md)]

- [Create a function triggered by Azure Blob storage](https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-storage-blob-triggered-function)
- [Azure Functions Blob Storage Bindings](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-blob)