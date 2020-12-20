# Simple Message Boxes
Similar to MessageBox.Show() but with
* user positioning of the dialog
* RTF text
* modal and non-modal versions

 Includes a simple RTF Builder to set font, color and alignment.

![Example](DemoApp/images/formatted.PNG?raw=true)

Non-Modal ShowDialog() versions start their own thread, so they may be called from a non-UI thread that might die before the dialog is dismissed. ShowDialog() versions accept an event handler for a button press event.

The message box class itself is in the SimpleMessageBox folder. A windows form demonstration app is in the DemoApp folder.