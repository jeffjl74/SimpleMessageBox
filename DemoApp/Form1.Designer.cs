namespace DemoApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonYesNo = new System.Windows.Forms.Button();
            this.buttonBig = new System.Windows.Forms.Button();
            this.buttonFormatted = new System.Windows.Forms.Button();
            this.buttonCallback = new System.Windows.Forms.Button();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTextTitle = new System.Windows.Forms.Button();
            this.buttonYesNoCancel = new System.Windows.Forms.Button();
            this.buttonAbortRetry = new System.Windows.Forms.Button();
            this.groupBoxNonModal = new System.Windows.Forms.GroupBox();
            this.buttonBuilder = new System.Windows.Forms.Button();
            this.groupBoxModal = new System.Windows.Forms.GroupBox();
            this.buttonPositioned = new System.Windows.Forms.Button();
            this.buttonXthread = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonReadme = new System.Windows.Forms.Button();
            this.groupBoxNonModal.SuspendLayout();
            this.groupBoxModal.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonYesNo
            // 
            this.buttonYesNo.Location = new System.Drawing.Point(7, 19);
            this.buttonYesNo.Name = "buttonYesNo";
            this.buttonYesNo.Size = new System.Drawing.Size(75, 23);
            this.buttonYesNo.TabIndex = 0;
            this.buttonYesNo.Text = "Yes/No";
            this.toolTip1.SetToolTip(this.buttonYesNo, "Call with just the text and title");
            this.buttonYesNo.UseVisualStyleBackColor = true;
            this.buttonYesNo.Click += new System.EventHandler(this.buttonYesNo_Click);
            // 
            // buttonBig
            // 
            this.buttonBig.Location = new System.Drawing.Point(6, 106);
            this.buttonBig.Name = "buttonBig";
            this.buttonBig.Size = new System.Drawing.Size(75, 23);
            this.buttonBig.TabIndex = 1;
            this.buttonBig.Text = "Big";
            this.toolTip1.SetToolTip(this.buttonBig, "Call with a large amount of text");
            this.buttonBig.UseVisualStyleBackColor = true;
            this.buttonBig.Click += new System.EventHandler(this.buttonBig_Click);
            // 
            // buttonFormatted
            // 
            this.buttonFormatted.Location = new System.Drawing.Point(6, 77);
            this.buttonFormatted.Name = "buttonFormatted";
            this.buttonFormatted.Size = new System.Drawing.Size(75, 23);
            this.buttonFormatted.TabIndex = 2;
            this.buttonFormatted.Text = "Direct RTF";
            this.toolTip1.SetToolTip(this.buttonFormatted, "Call with explicit RTF");
            this.buttonFormatted.UseVisualStyleBackColor = true;
            this.buttonFormatted.Click += new System.EventHandler(this.buttonFormatted_Click);
            // 
            // buttonCallback
            // 
            this.buttonCallback.Location = new System.Drawing.Point(6, 48);
            this.buttonCallback.Name = "buttonCallback";
            this.buttonCallback.Size = new System.Drawing.Size(75, 23);
            this.buttonCallback.TabIndex = 3;
            this.buttonCallback.Text = "OK Callback";
            this.toolTip1.SetToolTip(this.buttonCallback, "Placed at the specified location with a button event");
            this.buttonCallback.UseVisualStyleBackColor = true;
            this.buttonCallback.Click += new System.EventHandler(this.buttonCallback_Click);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResult.Location = new System.Drawing.Point(85, 217);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(337, 20);
            this.textBoxResult.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Result:";
            // 
            // buttonTextTitle
            // 
            this.buttonTextTitle.Location = new System.Drawing.Point(6, 19);
            this.buttonTextTitle.Name = "buttonTextTitle";
            this.buttonTextTitle.Size = new System.Drawing.Size(75, 23);
            this.buttonTextTitle.TabIndex = 6;
            this.buttonTextTitle.Text = "Text/Title";
            this.toolTip1.SetToolTip(this.buttonTextTitle, "Call with just the text and title");
            this.buttonTextTitle.UseVisualStyleBackColor = true;
            this.buttonTextTitle.Click += new System.EventHandler(this.buttonTextTitle_Click);
            // 
            // buttonYesNoCancel
            // 
            this.buttonYesNoCancel.Location = new System.Drawing.Point(7, 48);
            this.buttonYesNoCancel.Name = "buttonYesNoCancel";
            this.buttonYesNoCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonYesNoCancel.TabIndex = 7;
            this.buttonYesNoCancel.Text = "3 Button";
            this.toolTip1.SetToolTip(this.buttonYesNoCancel, "3 possible button press return values");
            this.buttonYesNoCancel.UseVisualStyleBackColor = true;
            this.buttonYesNoCancel.Click += new System.EventHandler(this.buttonYesNoCancel_Click);
            // 
            // buttonAbortRetry
            // 
            this.buttonAbortRetry.Location = new System.Drawing.Point(6, 135);
            this.buttonAbortRetry.Name = "buttonAbortRetry";
            this.buttonAbortRetry.Size = new System.Drawing.Size(75, 23);
            this.buttonAbortRetry.TabIndex = 8;
            this.buttonAbortRetry.Text = "3 Button";
            this.toolTip1.SetToolTip(this.buttonAbortRetry, "3 button event");
            this.buttonAbortRetry.UseVisualStyleBackColor = true;
            this.buttonAbortRetry.Click += new System.EventHandler(this.buttonAbortRetry_Click);
            // 
            // groupBoxNonModal
            // 
            this.groupBoxNonModal.Controls.Add(this.buttonBuilder);
            this.groupBoxNonModal.Controls.Add(this.buttonAbortRetry);
            this.groupBoxNonModal.Controls.Add(this.buttonTextTitle);
            this.groupBoxNonModal.Controls.Add(this.buttonCallback);
            this.groupBoxNonModal.Controls.Add(this.buttonFormatted);
            this.groupBoxNonModal.Controls.Add(this.buttonBig);
            this.groupBoxNonModal.Location = new System.Drawing.Point(25, 12);
            this.groupBoxNonModal.Name = "groupBoxNonModal";
            this.groupBoxNonModal.Size = new System.Drawing.Size(97, 199);
            this.groupBoxNonModal.TabIndex = 9;
            this.groupBoxNonModal.TabStop = false;
            this.groupBoxNonModal.Text = "Non-Modal";
            // 
            // buttonBuilder
            // 
            this.buttonBuilder.Location = new System.Drawing.Point(7, 165);
            this.buttonBuilder.Name = "buttonBuilder";
            this.buttonBuilder.Size = new System.Drawing.Size(75, 23);
            this.buttonBuilder.TabIndex = 9;
            this.buttonBuilder.Text = "Rtf Builder";
            this.toolTip1.SetToolTip(this.buttonBuilder, "Uses the RtfBuilder to merge text with the default rtf document");
            this.buttonBuilder.UseVisualStyleBackColor = true;
            this.buttonBuilder.Click += new System.EventHandler(this.buttonBuilder_Click);
            // 
            // groupBoxModal
            // 
            this.groupBoxModal.Controls.Add(this.buttonPositioned);
            this.groupBoxModal.Controls.Add(this.buttonXthread);
            this.groupBoxModal.Controls.Add(this.buttonYesNoCancel);
            this.groupBoxModal.Controls.Add(this.buttonYesNo);
            this.groupBoxModal.Location = new System.Drawing.Point(322, 12);
            this.groupBoxModal.Name = "groupBoxModal";
            this.groupBoxModal.Size = new System.Drawing.Size(100, 199);
            this.groupBoxModal.TabIndex = 10;
            this.groupBoxModal.TabStop = false;
            this.groupBoxModal.Text = "Modal";
            // 
            // buttonPositioned
            // 
            this.buttonPositioned.Location = new System.Drawing.Point(7, 108);
            this.buttonPositioned.Name = "buttonPositioned";
            this.buttonPositioned.Size = new System.Drawing.Size(75, 23);
            this.buttonPositioned.TabIndex = 9;
            this.buttonPositioned.Text = "Positioned";
            this.toolTip1.SetToolTip(this.buttonPositioned, "Placed at the specified location");
            this.buttonPositioned.UseVisualStyleBackColor = true;
            this.buttonPositioned.Click += new System.EventHandler(this.buttonPositioned_Click);
            // 
            // buttonXthread
            // 
            this.buttonXthread.Location = new System.Drawing.Point(7, 78);
            this.buttonXthread.Name = "buttonXthread";
            this.buttonXthread.Size = new System.Drawing.Size(75, 23);
            this.buttonXthread.TabIndex = 8;
            this.buttonXthread.Text = "X Thread";
            this.toolTip1.SetToolTip(this.buttonXthread, "Call from a separate thread");
            this.buttonXthread.UseVisualStyleBackColor = true;
            this.buttonXthread.Click += new System.EventHandler(this.buttonXthread_Click);
            // 
            // buttonReadme
            // 
            this.buttonReadme.Location = new System.Drawing.Point(179, 100);
            this.buttonReadme.Name = "buttonReadme";
            this.buttonReadme.Size = new System.Drawing.Size(75, 23);
            this.buttonReadme.TabIndex = 10;
            this.buttonReadme.Text = "Readme.md";
            this.toolTip1.SetToolTip(this.buttonReadme, "Tests the README.md examples");
            this.buttonReadme.UseVisualStyleBackColor = true;
            this.buttonReadme.Click += new System.EventHandler(this.buttonReadme_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 249);
            this.Controls.Add(this.buttonReadme);
            this.Controls.Add(this.groupBoxModal);
            this.Controls.Add(this.groupBoxNonModal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxResult);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxNonModal.ResumeLayout(false);
            this.groupBoxModal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonYesNo;
        private System.Windows.Forms.Button buttonBig;
        private System.Windows.Forms.Button buttonFormatted;
        private System.Windows.Forms.Button buttonCallback;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTextTitle;
        private System.Windows.Forms.Button buttonYesNoCancel;
        private System.Windows.Forms.Button buttonAbortRetry;
        private System.Windows.Forms.GroupBox groupBoxNonModal;
        private System.Windows.Forms.GroupBox groupBoxModal;
        private System.Windows.Forms.Button buttonBuilder;
        private System.Windows.Forms.Button buttonXthread;
        private System.Windows.Forms.Button buttonPositioned;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonReadme;
    }
}

