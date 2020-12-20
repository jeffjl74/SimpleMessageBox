# Simple Message Boxes
Similar to MessageBox.Show() but with user positioning of the dialog, RTF text, modal and non-modal versions. Includes a simple RTF Builder to set font, color and alignment.

Non-Modal ShowDialog() versions start their own thread, so they may be called from a non-UI thread that might die before the dialog is dismissed. ShowDialog() versions accept an event handler for a button press event.

The text of all message boxes is rich text format (RTF). By default, plain text is added to the blank RTF document in the RichTextEdit control. To add text formatting, the "text" parameter of .Show() and .ShowDialog() may contain RTF control words. 

There are a few ways to include RTF control words.
* The entire RTF document in the RichTextEdit control may be replaced by starting the "text" parameter with "{\rtf".
* Text group(s) may be added to the default document by specifying the "text" parameter as text groups.
* The included RtfBuilder can build color, font, alignment, bold, underline, strikethrough, and italic text groups to be merged with the default document.

## C# / .NET Examples
```csharp
// Equivalent to MessageBox.Show(text, title)
SimpleMessageBox.Show("Message is center screen with [OK] button", "Text/Title - Modal");

// Center the dialog on the parent
SimpleMessageBox.Show(this, "Centered on parent, [OK] button", "Centered - Modal");

// Position the dialog at the upper left corner of the parent
SimpleMessageBox.Show(this.Location, "Positioned with [OK] button", "Placed at location - Modal");

// Same button, icon, and default button choices as MessageBox
DialogResult result = SimpleMessageBox.Show(this, 
    "Yes/No/Cancel centered on parent", "Buttons - Modal",
    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button3);

// Use ShowDialog() for non-modal messsages.
SimpleMessageBox.ShowDialog(this, "Centered on parent, [OK] button", "Centered - Non-Modal");

// Use an event handler to get button press data from a non-modal dialog.
// OkEventArgs contains the DialogResult, and the message box size and location when the button was pressed.
private void SMB_ButtonPressed(object sender, EventArgs e)
{
    SimpleMessageBox.OkEventArgs args = e as SimpleMessageBox.OkEventArgs;
    if (args != null)
    {
        if (textBoxResult.InvokeRequired)
            textBoxResult.Invoke((MethodInvoker)delegate { textBoxResult.Text = args.ToString(); });
        else
            textBoxResult.Text = args.ToString();
    }
}

// Pass the event handler to a non-modal dialog
SimpleMessageBox.ShowDialog(this,
                "Non-modal 3 buttons centered on the parent. Generates an event when a button is pressed.",
                "3 Event - Non-Modal",
                MessageBoxButtons.AbortRetryIgnore, SMB_ButtonPressed, MessageBoxIcon.Hand);

// Example of directly setting text groups
SimpleMessageBox.ShowDialog(this,
                  @"plain string (default alignment is centered)"
                + @"{\par\b bold}"
                + @"{\par\ul underline}"
                + @"{{\colortbl;\red0\green0\blue0;\red255\green0\blue0;\red0\green128\blue0;}"
                + @"\par\pard\ql left justified {\cf2 red} and {\cf3 green} \par}"
                + @"{\fonttbl{\f1\fcharset0 Times New Roman;}}{\f1\fs30 15pt Roman font}"
                + @"{\par https://www.google.com/}"
                , "Formatted - Non-Modal");

//
// Example using RtfBuilder
//
RtfBuilder rtf = new RtfBuilder();
// underlined title line with a following blank line (\par)
rtf.AppendLine(new RtfControl { style = RtfStyle.Underline }, @"Demonstrates RtfBuilder capabilities.\par");
// color & alignment
rtf.AppendLine(new RtfControl { color = Color.Magenta, alignment = RtfAlign.Left }, "Left aligned magenta");
// change the font
int halfPts = 24;
rtf.AppendLine(new RtfControl { font = "Courier New", halfPts = halfPts }, $"{halfPts / 2}pt Courier font");
// convert to string
string text = rtf.ToString();
SimpleMessageBox.ShowDialog(this, text, "RtfBuilder - Non-Modal", 
    MessageBoxButtons.OK, null, MessageBoxIcon.Information);


```

