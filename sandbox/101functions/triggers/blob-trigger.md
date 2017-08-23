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