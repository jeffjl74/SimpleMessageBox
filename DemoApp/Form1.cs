using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleMessageBoxes;

namespace DemoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = true;  //set true to debug cross-thread calls
        }

        /// <summary>
        /// Centers the demo form on the screen
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            Rectangle screen = Screen.FromControl(this).Bounds;
            int x = (screen.Width - this.ClientSize.Width) / 2;
            int y = (screen.Height - this.ClientSize.Height) / 2;
            Point client = new Point(x, y);
            this.Location = client;
        }

        /// <summary>
        /// Event from the message box, which is on another thread.
        /// </summary>
        /// <remarks>
        /// Getting back on our UI thread:
        /// https://stackoverflow.com/questions/7750519/methodinvoke-delegate-or-lambda-expression
        /// </remarks>
        /// <param name="sender"><see cref="SimpleMessageBox"/></param>
        /// <param name="e"><see cref="SimpleMessageBox.OkEventArgs"/></param>
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

        #region NON MODAL

        /// <summary>
        /// Two parameter text/title non-modal instance. Will be centered on the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTextTitle_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "";
            SimpleMessageBox.ShowDialog("Pass only the text and title. Non-modal message is in the center of the screen. Button press closes the form with no event.",
                "Text/Title - Non-Modal");
            textBoxResult.Text = ((Button)sender).Text + ": returned from launch";
        }

        /// <summary>
        /// Show the message at a location and get an event when its button is pressed.
        /// </summary>
        private void buttonCallback_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "";
            SimpleMessageBox.ShowDialog(this.Location,
                "Non-Modal message specifically placed at the top left of the parent, with an event on button press.",
                "Event callback - Non-Modal", MessageBoxButtons.OK, SMB_ButtonPressed);
            textBoxResult.Text = ((Button)sender).Text + ": returned from launch";
        }

        /// <summary>
        /// Examples of some RTF formatting
        /// </summary>
        /// <remarks>
        /// If the text starts with "{\rtf", it will become the entire rtf document in the message box.
        /// <para>Otherwise, it will be merged with the existing blank document of the RichTextBox.</para>
        /// <para>If merging, your first font needs to be f1, since the default document already contains f0.</para>
        /// </remarks>
        private void buttonFormatted_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "";
            SimpleMessageBox.ShowDialog(this,
                  @"plain string (default alignment is centered)"
                + @"{\par\b bold}"
                + @"{\par\ul underline}"
                + @"{{\colortbl;\red0\green0\blue0;\red255\green0\blue0;\red0\green128\blue0;}\par\pard\ql left justified {\cf2 red} and {\cf3 green} \par}"
                + @"{\fonttbl{\f1\fcharset0 Times New Roman;}}{\f1\fs30 15pt Roman font}"
                + @"{\par https://www.google.com/}"
                , "Formatted - Non-Modal");
            textBoxResult.Text = ((Button)sender).Text + ": returned from launch";
        }

        /// <summary>
        /// Sets enough text that the form should be max size (but that depends on your screen resolution)
        /// and the scroll bar shows up
        /// </summary>
        private void buttonBig_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "";
            SimpleMessageBox.ShowDialog(this,
                  @"{\ql Four score and seven years ago our forefathers brought forth on this continent, a new nation, "
                + @"conceived in Liberty, and dedicated to the proposition that all men are created equal. "
                + @"\par\par Now we are engaged in a great civil war, testing whether that nation, or any nation so conceived and so dedicated, can long endure. "
                + @"We are met on a great battle field of that war. "
                + @"We have come to dedicate a portion of that field, as a final resting place for those who here gave their lives that the nation might live. "
                + @"It is altogether fitting and proper that we should do this. "
                + @"\par\par But, in a larger sense, we can not dedicate -- we can not consecrate -- we can not hallow -- this ground. "
                + @"The brave men, living and dead, who struggled here, have consecrated it, far above our poor power to add or detract. "
                + @"The world will little note, nor long remember what we say here. "
                + @"But it can never forget what they did here. "
                + @"It is for us the living, rather, to be dedicated here to the unfinished work which they who fought here have thus far so nobly advanced. "
                + @"It is rather for us to be here dedicated to the great task remaining before us -- "
                + @"that from these honored dead we take increased devotion to that cause for which they gave the last full measure of devotion --  "
                + @"that this nation, under God, shall have a new birth of freedom -- "
                + @"and that government of the people, by the people, for the people, shall not perish from the earth.\par}"
                , "Size Test - Non-Modal");
            textBoxResult.Text = ((Button)sender).Text + ": returned from launch";
        }

        /// <summary>
        /// Modal 3 buttons.
        /// </summary>
        private void buttonAbortRetry_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "";
            SimpleMessageBox.ShowDialog(this,
                "Non-modal 3 buttons centered on the parent. Generates an event when a button is pressed.",
                "3 Event - Non-Modal",
                MessageBoxButtons.AbortRetryIgnore, SMB_ButtonPressed, MessageBoxIcon.Hand);
            textBoxResult.Text = ((Button)sender).Text + ": returned from launch";
        }

        /// <summary>
        /// Demonstrate using the RtfBuilder.
        /// </summary>
        private void buttonBuilder_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "";

            // use the builder instead of writing raw rtf
            RtfBuilder rtf = new RtfBuilder();

            // underlined title line with a following blank line (\par)
            rtf.AppendLine(new RtfControl { style = RtfStyle.Underline }, @"Demonstrates RtfBuilder capabilities.\par");

            // color & alignment
            rtf.AppendLine(new RtfControl { color = Color.Magenta, alignment = RtfAlign.Left }, "Left aligned magenta");

            //blank line
            rtf.AppendLine("");

            //build a line that has different formats in the same line using Append() then AppendLine()
            // alignment should be in the first group
            rtf.Append(new RtfControl { alignment = RtfAlign.Right, style = RtfStyle.Underline | RtfStyle.Bold }, "bold underlined");
            rtf.Append(new RtfControl { style = RtfStyle.Italic }, " italic");
            rtf.Append(new RtfControl { color = Color.Green }, " green");
            rtf.AppendLine(new RtfControl { style = RtfStyle.Strikethrough }, @" right\par");


            // change the font
            int halfPts = 24;
            rtf.AppendLine(new RtfControl { font = "Courier New", halfPts = halfPts }, $"{halfPts / 2}pt Courier font");

            //control default = centered, plain text
            rtf.AppendLine("Default format line.");

            string text = rtf.ToString();

            SimpleMessageBox.ShowDialog(this, text, "RtfBuilder - Non-Modal", MessageBoxButtons.OK, null, MessageBoxIcon.Information);
            textBoxResult.Text = ((Button)sender).Text + ": returned from launch";
        }

        #endregion NON MODAL

        #region MODAL

        /// <summary>
        /// Simple modal Yes/No
        /// </summary>
        private void buttonYesNo_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "";
            DialogResult result = SimpleMessageBox.Show(this, 
                "Modal question at the center of the parent. Returns when the button is pressed.", 
                "Yes/No - Modal", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            textBoxResult.Text = ((Button)sender).Text + ": returned " + result.ToString();
        }

        /// <summary>
        /// Show 3 buttons, centered on the parent.
        /// </summary>
        private void buttonYesNoCancel_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "";
            DialogResult result = SimpleMessageBox.Show(this,
                "3 button test, centered on parent, returns the result.",
                "3 Event - Modal",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button3);
            textBoxResult.Text = ((Button)sender).Text + ": returned " + result.ToString();
        }

        /// <summary>
        /// Activates a modal message box from a new thread.
        /// </summary>
        private void buttonXthread_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "";
            // start a new thread
            Task.Run(() =>
            {
                // block this thread (but not the UI thread) with ShowDialog
                DialogResult result = SimpleMessageBox.Show(this, 
                    "Demonstrates Modal show from a non-UI thread. " 
                    + "3 buttons centered on the parent. " 
                    + "Blocks the calling thread but not the UI thread. " 
                    + "Returns DialogResult for the button pressed.", 
                    "3 Event - Modal",
                    MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand);

                // gets here only after a button click in the message box
                // Invoke since we are not on the UI thread
                textBoxResult.Invoke((MethodInvoker)delegate { textBoxResult.Text = ((Button)sender).Text + ": returned from launch. Returned:" + result.ToString(); });
            });

        }

        /// <summary>
        /// Positions a modal message box at the desired location.
        /// </summary>
        private void buttonPositioned_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "";
            DialogResult result = SimpleMessageBox.Show(new Point(this.Right, this.Top),
                "Modal 2 buttons located at the upper right corner of the parent. "
                + "Returns DialogResult for the button pressed.",
                "2 Button Positioned - Modal",
                MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
            textBoxResult.Text = ((Button)sender).Text + ": Returned:" + result.ToString();
        }

        #endregion MODAL
    }
}
