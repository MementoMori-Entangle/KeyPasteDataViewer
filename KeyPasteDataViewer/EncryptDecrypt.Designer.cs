namespace KeyPasteDataViewer
{
    partial class EncryptDecrypt
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
            this.AESModeComboBox = new System.Windows.Forms.ComboBox();
            this.AESModeLabel = new System.Windows.Forms.Label();
            this.AESBlockSizeComboBox = new System.Windows.Forms.ComboBox();
            this.AESKeySizeComboBox = new System.Windows.Forms.ComboBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.AESKeyTextBox = new System.Windows.Forms.TextBox();
            this.AESIVTextBox = new System.Windows.Forms.TextBox();
            this.AESBlockSizeLabel = new System.Windows.Forms.Label();
            this.AESKeySizeLabel = new System.Windows.Forms.Label();
            this.AESKeyLabel = new System.Windows.Forms.Label();
            this.AESIVLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.RSAKeySizeComboBox = new System.Windows.Forms.ComboBox();
            this.RSAKeySizeLabel = new System.Windows.Forms.Label();
            this.PrivateKeyLabel = new System.Windows.Forms.Label();
            this.PrivateKeyRichTextBox = new System.Windows.Forms.RichTextBox();
            this.PublicKeyLabel = new System.Windows.Forms.Label();
            this.PublicKeyRichTextBox = new System.Windows.Forms.RichTextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.Reloadbutton = new System.Windows.Forms.Button();
            this.TypeGroupBox = new System.Windows.Forms.GroupBox();
            this.RSARadioButton = new System.Windows.Forms.RadioButton();
            this.AESRadioButton = new System.Windows.Forms.RadioButton();
            this.TypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AESModeComboBox
            // 
            this.AESModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AESModeComboBox.FormattingEnabled = true;
            this.AESModeComboBox.Items.AddRange(new object[] {
            "CBC",
            "ECB",
            "OFB",
            "CFB",
            "CTS"});
            this.AESModeComboBox.Location = new System.Drawing.Point(239, 57);
            this.AESModeComboBox.Name = "AESModeComboBox";
            this.AESModeComboBox.Size = new System.Drawing.Size(68, 20);
            this.AESModeComboBox.TabIndex = 15;
            // 
            // AESModeLabel
            // 
            this.AESModeLabel.AutoSize = true;
            this.AESModeLabel.Location = new System.Drawing.Point(176, 61);
            this.AESModeLabel.Name = "AESModeLabel";
            this.AESModeLabel.Size = new System.Drawing.Size(58, 12);
            this.AESModeLabel.TabIndex = 35;
            this.AESModeLabel.Text = "AES Mode";
            // 
            // AESBlockSizeComboBox
            // 
            this.AESBlockSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AESBlockSizeComboBox.FormattingEnabled = true;
            this.AESBlockSizeComboBox.Items.AddRange(new object[] {
            "128",
            "192",
            "256"});
            this.AESBlockSizeComboBox.Location = new System.Drawing.Point(97, 83);
            this.AESBlockSizeComboBox.Name = "AESBlockSizeComboBox";
            this.AESBlockSizeComboBox.Size = new System.Drawing.Size(68, 20);
            this.AESBlockSizeComboBox.TabIndex = 14;
            // 
            // AESKeySizeComboBox
            // 
            this.AESKeySizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AESKeySizeComboBox.FormattingEnabled = true;
            this.AESKeySizeComboBox.Items.AddRange(new object[] {
            "128",
            "192",
            "256"});
            this.AESKeySizeComboBox.Location = new System.Drawing.Point(97, 57);
            this.AESKeySizeComboBox.Name = "AESKeySizeComboBox";
            this.AESKeySizeComboBox.Size = new System.Drawing.Size(68, 20);
            this.AESKeySizeComboBox.TabIndex = 13;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(414, 109);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(49, 23);
            this.ClearButton.TabIndex = 33;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // AESKeyTextBox
            // 
            this.AESKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AESKeyTextBox.Location = new System.Drawing.Point(97, 32);
            this.AESKeyTextBox.Name = "AESKeyTextBox";
            this.AESKeyTextBox.Size = new System.Drawing.Size(476, 19);
            this.AESKeyTextBox.TabIndex = 12;
            // 
            // AESIVTextBox
            // 
            this.AESIVTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AESIVTextBox.Location = new System.Drawing.Point(97, 6);
            this.AESIVTextBox.Name = "AESIVTextBox";
            this.AESIVTextBox.Size = new System.Drawing.Size(476, 19);
            this.AESIVTextBox.TabIndex = 11;
            // 
            // AESBlockSizeLabel
            // 
            this.AESBlockSizeLabel.AutoSize = true;
            this.AESBlockSizeLabel.Location = new System.Drawing.Point(12, 86);
            this.AESBlockSizeLabel.Name = "AESBlockSizeLabel";
            this.AESBlockSizeLabel.Size = new System.Drawing.Size(85, 12);
            this.AESBlockSizeLabel.TabIndex = 29;
            this.AESBlockSizeLabel.Text = "AES Block Size";
            // 
            // AESKeySizeLabel
            // 
            this.AESKeySizeLabel.AutoSize = true;
            this.AESKeySizeLabel.Location = new System.Drawing.Point(12, 61);
            this.AESKeySizeLabel.Name = "AESKeySizeLabel";
            this.AESKeySizeLabel.Size = new System.Drawing.Size(75, 12);
            this.AESKeySizeLabel.TabIndex = 28;
            this.AESKeySizeLabel.Text = "AES Key Size";
            // 
            // AESKeyLabel
            // 
            this.AESKeyLabel.AutoSize = true;
            this.AESKeyLabel.Location = new System.Drawing.Point(12, 35);
            this.AESKeyLabel.Name = "AESKeyLabel";
            this.AESKeyLabel.Size = new System.Drawing.Size(50, 12);
            this.AESKeyLabel.TabIndex = 27;
            this.AESKeyLabel.Text = "AES Key";
            // 
            // AESIVLabel
            // 
            this.AESIVLabel.AutoSize = true;
            this.AESIVLabel.Location = new System.Drawing.Point(12, 9);
            this.AESIVLabel.Name = "AESIVLabel";
            this.AESIVLabel.Size = new System.Drawing.Size(42, 12);
            this.AESIVLabel.TabIndex = 26;
            this.AESIVLabel.Text = "AES IV";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(524, 109);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(49, 23);
            this.SaveButton.TabIndex = 31;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // RSAKeySizeComboBox
            // 
            this.RSAKeySizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RSAKeySizeComboBox.FormattingEnabled = true;
            this.RSAKeySizeComboBox.Items.AddRange(new object[] {
            "512",
            "1024",
            "2048",
            "4096"});
            this.RSAKeySizeComboBox.Location = new System.Drawing.Point(97, 140);
            this.RSAKeySizeComboBox.Name = "RSAKeySizeComboBox";
            this.RSAKeySizeComboBox.Size = new System.Drawing.Size(68, 20);
            this.RSAKeySizeComboBox.TabIndex = 21;
            // 
            // RSAKeySizeLabel
            // 
            this.RSAKeySizeLabel.AutoSize = true;
            this.RSAKeySizeLabel.Location = new System.Drawing.Point(15, 143);
            this.RSAKeySizeLabel.Name = "RSAKeySizeLabel";
            this.RSAKeySizeLabel.Size = new System.Drawing.Size(76, 12);
            this.RSAKeySizeLabel.TabIndex = 42;
            this.RSAKeySizeLabel.Text = "RSA Key Size";
            // 
            // PrivateKeyLabel
            // 
            this.PrivateKeyLabel.AutoSize = true;
            this.PrivateKeyLabel.Location = new System.Drawing.Point(15, 170);
            this.PrivateKeyLabel.Name = "PrivateKeyLabel";
            this.PrivateKeyLabel.Size = new System.Drawing.Size(64, 12);
            this.PrivateKeyLabel.TabIndex = 41;
            this.PrivateKeyLabel.Text = "Private Key";
            // 
            // PrivateKeyRichTextBox
            // 
            this.PrivateKeyRichTextBox.Location = new System.Drawing.Point(17, 185);
            this.PrivateKeyRichTextBox.Name = "PrivateKeyRichTextBox";
            this.PrivateKeyRichTextBox.Size = new System.Drawing.Size(270, 157);
            this.PrivateKeyRichTextBox.TabIndex = 22;
            this.PrivateKeyRichTextBox.Text = "";
            // 
            // PublicKeyLabel
            // 
            this.PublicKeyLabel.AutoSize = true;
            this.PublicKeyLabel.Location = new System.Drawing.Point(302, 170);
            this.PublicKeyLabel.Name = "PublicKeyLabel";
            this.PublicKeyLabel.Size = new System.Drawing.Size(59, 12);
            this.PublicKeyLabel.TabIndex = 39;
            this.PublicKeyLabel.Text = "Public Key";
            // 
            // PublicKeyRichTextBox
            // 
            this.PublicKeyRichTextBox.Location = new System.Drawing.Point(304, 185);
            this.PublicKeyRichTextBox.Name = "PublicKeyRichTextBox";
            this.PublicKeyRichTextBox.Size = new System.Drawing.Size(270, 157);
            this.PublicKeyRichTextBox.TabIndex = 23;
            this.PublicKeyRichTextBox.Text = "";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(414, 81);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(49, 23);
            this.CloseButton.TabIndex = 34;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Reloadbutton
            // 
            this.Reloadbutton.Location = new System.Drawing.Point(469, 109);
            this.Reloadbutton.Name = "Reloadbutton";
            this.Reloadbutton.Size = new System.Drawing.Size(49, 23);
            this.Reloadbutton.TabIndex = 32;
            this.Reloadbutton.Text = "Reload";
            this.Reloadbutton.UseVisualStyleBackColor = true;
            this.Reloadbutton.Click += new System.EventHandler(this.Reloadbutton_Click);
            // 
            // TypeGroupBox
            // 
            this.TypeGroupBox.Controls.Add(this.RSARadioButton);
            this.TypeGroupBox.Controls.Add(this.AESRadioButton);
            this.TypeGroupBox.Location = new System.Drawing.Point(239, 109);
            this.TypeGroupBox.Name = "TypeGroupBox";
            this.TypeGroupBox.Size = new System.Drawing.Size(109, 43);
            this.TypeGroupBox.TabIndex = 1;
            this.TypeGroupBox.TabStop = false;
            this.TypeGroupBox.Text = "Type";
            // 
            // RSARadioButton
            // 
            this.RSARadioButton.AutoSize = true;
            this.RSARadioButton.Location = new System.Drawing.Point(57, 18);
            this.RSARadioButton.Name = "RSARadioButton";
            this.RSARadioButton.Size = new System.Drawing.Size(46, 16);
            this.RSARadioButton.TabIndex = 16;
            this.RSARadioButton.Text = "RSA";
            this.RSARadioButton.UseVisualStyleBackColor = true;
            // 
            // AESRadioButton
            // 
            this.AESRadioButton.AutoSize = true;
            this.AESRadioButton.Checked = true;
            this.AESRadioButton.Location = new System.Drawing.Point(6, 18);
            this.AESRadioButton.Name = "AESRadioButton";
            this.AESRadioButton.Size = new System.Drawing.Size(45, 16);
            this.AESRadioButton.TabIndex = 0;
            this.AESRadioButton.TabStop = true;
            this.AESRadioButton.Text = "AES";
            this.AESRadioButton.UseVisualStyleBackColor = true;
            // 
            // EncryptDecrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 355);
            this.Controls.Add(this.TypeGroupBox);
            this.Controls.Add(this.Reloadbutton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.RSAKeySizeComboBox);
            this.Controls.Add(this.RSAKeySizeLabel);
            this.Controls.Add(this.PrivateKeyLabel);
            this.Controls.Add(this.PrivateKeyRichTextBox);
            this.Controls.Add(this.PublicKeyLabel);
            this.Controls.Add(this.PublicKeyRichTextBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.AESModeComboBox);
            this.Controls.Add(this.AESModeLabel);
            this.Controls.Add(this.AESBlockSizeComboBox);
            this.Controls.Add(this.AESKeySizeComboBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.AESKeyTextBox);
            this.Controls.Add(this.AESIVTextBox);
            this.Controls.Add(this.AESBlockSizeLabel);
            this.Controls.Add(this.AESKeySizeLabel);
            this.Controls.Add(this.AESKeyLabel);
            this.Controls.Add(this.AESIVLabel);
            this.Name = "EncryptDecrypt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EncryptionDecryption";
            this.TypeGroupBox.ResumeLayout(false);
            this.TypeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox AESModeComboBox;
        private System.Windows.Forms.Label AESModeLabel;
        private System.Windows.Forms.ComboBox AESBlockSizeComboBox;
        private System.Windows.Forms.ComboBox AESKeySizeComboBox;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TextBox AESKeyTextBox;
        private System.Windows.Forms.TextBox AESIVTextBox;
        private System.Windows.Forms.Label AESBlockSizeLabel;
        private System.Windows.Forms.Label AESKeySizeLabel;
        private System.Windows.Forms.Label AESKeyLabel;
        private System.Windows.Forms.Label AESIVLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ComboBox RSAKeySizeComboBox;
        private System.Windows.Forms.Label RSAKeySizeLabel;
        private System.Windows.Forms.Label PrivateKeyLabel;
        private System.Windows.Forms.RichTextBox PrivateKeyRichTextBox;
        private System.Windows.Forms.Label PublicKeyLabel;
        private System.Windows.Forms.RichTextBox PublicKeyRichTextBox;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button Reloadbutton;
        private System.Windows.Forms.GroupBox TypeGroupBox;
        private System.Windows.Forms.RadioButton RSARadioButton;
        private System.Windows.Forms.RadioButton AESRadioButton;
    }
}