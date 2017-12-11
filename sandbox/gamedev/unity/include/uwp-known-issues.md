### UWP Builds

To build for UWP, ensure that the the DLLs in the root Plugins directory are excluded from the build, while the DLLs in the WSA directory are included in the build.  To do this:

1. In the **Project** window, select all DLLs that are in the root **Plugins\\&lt;SDK&gt;** directory (note that the DLLs and SDK directory name will vary based on the SDK).

   ![Select all DLLs](../media/unity-select-dlls.png)

1. In the Inspector window at the right, make sure both **Any Platform** and **WSAPlayer** are not selected.

   ![Exclude only WSAPlayer](../media/unity-wsaplayer-exclude.png)

1. In the **Project** window, select all DLLs that are in the root **Plugins\\&lt;SDK&gt;\\WSA** directory (note that the DLLs and SDK directory name will vary based on the SDK).

1. In the Inspector window at the right, make sure **Any Platform** is not selected and **WSAPlayer** is selected.

   ![Include only WSAPlayer](../media/unity-wsaplayer-include.png)

With these selections, you should be able to export your UWP build without issue.  To go back to building for another platform, reverse the process -- make sure both **Any Platform** and **WSAPlayer** are selected and then export.
