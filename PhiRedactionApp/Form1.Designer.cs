namespace PhiRedactionApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSelectFiles = new Button();
            lstFiles = new ListBox();
            btnProcessFiles = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnSelectFiles
            // 
            btnSelectFiles.Location = new Point(186, 13);
            btnSelectFiles.Margin = new Padding(3, 4, 3, 4);
            btnSelectFiles.Name = "btnSelectFiles";
            btnSelectFiles.Size = new Size(150, 38);
            btnSelectFiles.TabIndex = 0;
            btnSelectFiles.Text = "Select Lab Order Files";
            btnSelectFiles.UseVisualStyleBackColor = true;
            btnSelectFiles.Click += btnSelectFiles_Click;
            // 
            // lstFiles
            // 
            lstFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstFiles.FormattingEnabled = true;
            lstFiles.HorizontalScrollbar = true;
            lstFiles.Location = new Point(12, 60);
            lstFiles.Margin = new Padding(3, 4, 3, 4);
            lstFiles.Name = "lstFiles";
            lstFiles.SelectionMode = SelectionMode.None;
            lstFiles.Size = new Size(560, 324);
            lstFiles.TabIndex = 1;
            lstFiles.SelectedIndexChanged += lstFiles_SelectedIndexChanged;
            // 
            // btnProcessFiles
            // 
            btnProcessFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnProcessFiles.Location = new Point(422, 392);
            btnProcessFiles.Margin = new Padding(3, 4, 3, 4);
            btnProcessFiles.Name = "btnProcessFiles";
            btnProcessFiles.Size = new Size(150, 38);
            btnProcessFiles.TabIndex = 2;
            btnProcessFiles.Text = "Process Files";
            btnProcessFiles.UseVisualStyleBackColor = true;
            btnProcessFiles.Click += btnProcessFiles_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(12, 401);
            label1.Name = "label1";
            label1.Size = new Size(214, 20);
            label1.TabIndex = 3;
            label1.Text = "PHI Redaction Application v1.0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 445);
            Controls.Add(label1);
            Controls.Add(btnProcessFiles);
            Controls.Add(lstFiles);
            Controls.Add(btnSelectFiles);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(600, 488);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PHI Redaction Tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnProcessFiles;
        private System.Windows.Forms.Label label1;
    }
}
