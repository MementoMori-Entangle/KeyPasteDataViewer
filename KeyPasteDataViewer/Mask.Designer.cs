namespace KeyPasteDataViewer
{
    partial class Mask
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
            this.KeyCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.DataBackButton = new System.Windows.Forms.Button();
            this.MaskStringTextBox = new System.Windows.Forms.TextBox();
            this.MaskStringLabel = new System.Windows.Forms.Label();
            this.DataMaskButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.MaskStringClearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KeyCheckedListBox
            // 
            this.KeyCheckedListBox.FormattingEnabled = true;
            this.KeyCheckedListBox.HorizontalScrollbar = true;
            this.KeyCheckedListBox.Location = new System.Drawing.Point(14, 60);
            this.KeyCheckedListBox.Name = "KeyCheckedListBox";
            this.KeyCheckedListBox.Size = new System.Drawing.Size(210, 340);
            this.KeyCheckedListBox.TabIndex = 1;
            // 
            // DataBackButton
            // 
            this.DataBackButton.Location = new System.Drawing.Point(14, 31);
            this.DataBackButton.Name = "DataBackButton";
            this.DataBackButton.Size = new System.Drawing.Size(75, 23);
            this.DataBackButton.TabIndex = 3;
            this.DataBackButton.Text = "Data Back";
            this.DataBackButton.UseVisualStyleBackColor = true;
            this.DataBackButton.Click += new System.EventHandler(this.DataBackButton_Click);
            // 
            // MaskStringTextBox
            // 
            this.MaskStringTextBox.Location = new System.Drawing.Point(84, 6);
            this.MaskStringTextBox.Name = "MaskStringTextBox";
            this.MaskStringTextBox.Size = new System.Drawing.Size(86, 19);
            this.MaskStringTextBox.TabIndex = 4;
            // 
            // MaskStringLabel
            // 
            this.MaskStringLabel.AutoSize = true;
            this.MaskStringLabel.Location = new System.Drawing.Point(12, 9);
            this.MaskStringLabel.Name = "MaskStringLabel";
            this.MaskStringLabel.Size = new System.Drawing.Size(66, 12);
            this.MaskStringLabel.TabIndex = 18;
            this.MaskStringLabel.Text = "Mask String";
            // 
            // DataMaskButton
            // 
            this.DataMaskButton.Location = new System.Drawing.Point(95, 31);
            this.DataMaskButton.Name = "DataMaskButton";
            this.DataMaskButton.Size = new System.Drawing.Size(75, 23);
            this.DataMaskButton.TabIndex = 2;
            this.DataMaskButton.Text = "Data Mask";
            this.DataMaskButton.UseVisualStyleBackColor = true;
            this.DataMaskButton.Click += new System.EventHandler(this.DataMaskButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(176, 31);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(48, 23);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MaskStringClearButton
            // 
            this.MaskStringClearButton.Location = new System.Drawing.Point(176, 6);
            this.MaskStringClearButton.Name = "MaskStringClearButton";
            this.MaskStringClearButton.Size = new System.Drawing.Size(48, 19);
            this.MaskStringClearButton.TabIndex = 5;
            this.MaskStringClearButton.Text = "Clear";
            this.MaskStringClearButton.UseVisualStyleBackColor = true;
            this.MaskStringClearButton.Click += new System.EventHandler(this.MaskStringClearButton_Click);
            // 
            // Mask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 411);
            this.Controls.Add(this.MaskStringClearButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.DataMaskButton);
            this.Controls.Add(this.MaskStringLabel);
            this.Controls.Add(this.MaskStringTextBox);
            this.Controls.Add(this.DataBackButton);
            this.Controls.Add(this.KeyCheckedListBox);
            this.Name = "Mask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TargetMask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox KeyCheckedListBox;
        private System.Windows.Forms.Button DataBackButton;
        private System.Windows.Forms.TextBox MaskStringTextBox;
        private System.Windows.Forms.Label MaskStringLabel;
        private System.Windows.Forms.Button DataMaskButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button MaskStringClearButton;
    }
}