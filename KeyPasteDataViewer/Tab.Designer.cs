namespace KeyPasteDataViewer
{
    partial class Tab
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabAddButton = new System.Windows.Forms.Button();
            this.TabAddTextBox = new System.Windows.Forms.TextBox();
            this.TabDelButton = new System.Windows.Forms.Button();
            this.SeparateFrameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Location = new System.Drawing.Point(0, 36);
            this.TabControl.Multiline = true;
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(942, 706);
            this.TabControl.TabIndex = 0;
            this.TabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl_Selected);
            // 
            // TabAddButton
            // 
            this.TabAddButton.Location = new System.Drawing.Point(4, 7);
            this.TabAddButton.Name = "TabAddButton";
            this.TabAddButton.Size = new System.Drawing.Size(62, 23);
            this.TabAddButton.TabIndex = 1;
            this.TabAddButton.Text = "Tab add";
            this.TabAddButton.UseVisualStyleBackColor = true;
            this.TabAddButton.Click += new System.EventHandler(this.TabAddButton_Click);
            // 
            // TabAddTextBox
            // 
            this.TabAddTextBox.Location = new System.Drawing.Point(72, 9);
            this.TabAddTextBox.Name = "TabAddTextBox";
            this.TabAddTextBox.Size = new System.Drawing.Size(100, 19);
            this.TabAddTextBox.TabIndex = 2;
            // 
            // TabDelButton
            // 
            this.TabDelButton.Location = new System.Drawing.Point(178, 7);
            this.TabDelButton.Name = "TabDelButton";
            this.TabDelButton.Size = new System.Drawing.Size(62, 23);
            this.TabDelButton.TabIndex = 3;
            this.TabDelButton.Text = "Tab del";
            this.TabDelButton.UseVisualStyleBackColor = true;
            this.TabDelButton.Click += new System.EventHandler(this.TabDelButton_Click);
            // 
            // SeparateFrameButton
            // 
            this.SeparateFrameButton.Location = new System.Drawing.Point(246, 7);
            this.SeparateFrameButton.Name = "SeparateFrameButton";
            this.SeparateFrameButton.Size = new System.Drawing.Size(93, 23);
            this.SeparateFrameButton.TabIndex = 4;
            this.SeparateFrameButton.Text = "Separate frame";
            this.SeparateFrameButton.UseVisualStyleBackColor = true;
            this.SeparateFrameButton.Click += new System.EventHandler(this.SeparateFrameButton_Click);
            // 
            // Tab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 741);
            this.Controls.Add(this.SeparateFrameButton);
            this.Controls.Add(this.TabDelButton);
            this.Controls.Add(this.TabAddTextBox);
            this.Controls.Add(this.TabAddButton);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Tab";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeyPasteDataViewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.Button TabAddButton;
        private System.Windows.Forms.TextBox TabAddTextBox;
        private System.Windows.Forms.Button TabDelButton;
        private System.Windows.Forms.Button SeparateFrameButton;
    }
}