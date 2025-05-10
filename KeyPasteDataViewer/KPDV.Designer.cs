namespace KeyPasteDataViewer
{
    partial class KPDV
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.ConnectionResetButton = new System.Windows.Forms.Button();
            this.ConnectionSaveButton = new System.Windows.Forms.Button();
            this.AllUnCheckButton = new System.Windows.Forms.Button();
            this.AllCheckButton = new System.Windows.Forms.Button();
            this.DataBackButton = new System.Windows.Forms.Button();
            this.MaskButton = new System.Windows.Forms.Button();
            this.QuerySaveButton = new System.Windows.Forms.Button();
            this.ChartButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.TentativeHeaderCheckBox = new System.Windows.Forms.CheckBox();
            this.PreconditionAllClearButton = new System.Windows.Forms.Button();
            this.AndOrButton = new System.Windows.Forms.Button();
            this.QueryCheckBox = new System.Windows.Forms.CheckBox();
            this.QueryRichTextBox = new System.Windows.Forms.RichTextBox();
            this.PreconditionClearButton = new System.Windows.Forms.Button();
            this.PreconditionValueLabel = new System.Windows.Forms.Label();
            this.ViewColumnsLabel = new System.Windows.Forms.Label();
            this.KeyDataLabel = new System.Windows.Forms.Label();
            this.PreconditionTextBox = new System.Windows.Forms.TextBox();
            this.KeyCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.DataNumberLabel = new System.Windows.Forms.Label();
            this.ConnectionLabel = new System.Windows.Forms.Label();
            this.DataComboBox = new System.Windows.Forms.ComboBox();
            this.ConnectionButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ViewButton = new System.Windows.Forms.Button();
            this.DataKeyComboBox = new System.Windows.Forms.ComboBox();
            this.KeyRichTextBox = new System.Windows.Forms.RichTextBox();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.PasswordComboBox = new System.Windows.Forms.ComboBox();
            this.UserComboBox = new System.Windows.Forms.ComboBox();
            this.PortComboBox = new System.Windows.Forms.ComboBox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.DataNameComboBox = new System.Windows.Forms.ComboBox();
            this.DataSourceComboBox = new System.Windows.Forms.ComboBox();
            this.DataTypeComboBox = new System.Windows.Forms.ComboBox();
            this.MainDataGridView = new System.Windows.Forms.DataGridView();
            this.DataTypeLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UserLabel = new System.Windows.Forms.Label();
            this.DataSourceLabel = new System.Windows.Forms.Label();
            this.DataNameLabel = new System.Windows.Forms.Label();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.EncryptButton = new System.Windows.Forms.Button();
            this.EncryptSetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectionResetButton
            // 
            this.ConnectionResetButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConnectionResetButton.Location = new System.Drawing.Point(1327, 100);
            this.ConnectionResetButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ConnectionResetButton.Name = "ConnectionResetButton";
            this.ConnectionResetButton.Size = new System.Drawing.Size(92, 34);
            this.ConnectionResetButton.TabIndex = 49;
            this.ConnectionResetButton.Text = "Reset";
            this.ConnectionResetButton.UseVisualStyleBackColor = true;
            this.ConnectionResetButton.Click += new System.EventHandler(this.ConnectionResetButton_Click);
            // 
            // ConnectionSaveButton
            // 
            this.ConnectionSaveButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConnectionSaveButton.Location = new System.Drawing.Point(1228, 100);
            this.ConnectionSaveButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ConnectionSaveButton.Name = "ConnectionSaveButton";
            this.ConnectionSaveButton.Size = new System.Drawing.Size(92, 34);
            this.ConnectionSaveButton.TabIndex = 48;
            this.ConnectionSaveButton.Text = "Save";
            this.ConnectionSaveButton.UseVisualStyleBackColor = true;
            this.ConnectionSaveButton.Click += new System.EventHandler(this.ConnectionSaveButton_Click);
            // 
            // AllUnCheckButton
            // 
            this.AllUnCheckButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AllUnCheckButton.Location = new System.Drawing.Point(518, 230);
            this.AllUnCheckButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.AllUnCheckButton.Name = "AllUnCheckButton";
            this.AllUnCheckButton.Size = new System.Drawing.Size(132, 28);
            this.AllUnCheckButton.TabIndex = 16;
            this.AllUnCheckButton.Text = "All UnCheck";
            this.AllUnCheckButton.UseVisualStyleBackColor = true;
            this.AllUnCheckButton.Click += new System.EventHandler(this.AllUnCheckButton_Click);
            // 
            // AllCheckButton
            // 
            this.AllCheckButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AllCheckButton.Location = new System.Drawing.Point(385, 230);
            this.AllCheckButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.AllCheckButton.Name = "AllCheckButton";
            this.AllCheckButton.Size = new System.Drawing.Size(123, 28);
            this.AllCheckButton.TabIndex = 15;
            this.AllCheckButton.Text = "All Check";
            this.AllCheckButton.UseVisualStyleBackColor = true;
            this.AllCheckButton.Click += new System.EventHandler(this.AllCheckButton_Click);
            // 
            // DataBackButton
            // 
            this.DataBackButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DataBackButton.Location = new System.Drawing.Point(1364, 395);
            this.DataBackButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.DataBackButton.Name = "DataBackButton";
            this.DataBackButton.Size = new System.Drawing.Size(154, 34);
            this.DataBackButton.TabIndex = 36;
            this.DataBackButton.Text = "Data Back";
            this.DataBackButton.UseVisualStyleBackColor = true;
            this.DataBackButton.Click += new System.EventHandler(this.DataBackButton_Click);
            // 
            // MaskButton
            // 
            this.MaskButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MaskButton.Location = new System.Drawing.Point(1364, 353);
            this.MaskButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaskButton.Name = "MaskButton";
            this.MaskButton.Size = new System.Drawing.Size(154, 34);
            this.MaskButton.TabIndex = 35;
            this.MaskButton.Text = "Data Mask";
            this.MaskButton.UseVisualStyleBackColor = true;
            this.MaskButton.Click += new System.EventHandler(this.MaskButton_Click);
            // 
            // QuerySaveButton
            // 
            this.QuerySaveButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.QuerySaveButton.Location = new System.Drawing.Point(1187, 254);
            this.QuerySaveButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.QuerySaveButton.Name = "QuerySaveButton";
            this.QuerySaveButton.Size = new System.Drawing.Size(167, 34);
            this.QuerySaveButton.TabIndex = 27;
            this.QuerySaveButton.Text = "Query Save";
            this.QuerySaveButton.UseVisualStyleBackColor = true;
            this.QuerySaveButton.Click += new System.EventHandler(this.QuerySaveButton_Click);
            // 
            // ChartButton
            // 
            this.ChartButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ChartButton.Location = new System.Drawing.Point(1364, 311);
            this.ChartButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ChartButton.Name = "ChartButton";
            this.ChartButton.Size = new System.Drawing.Size(154, 34);
            this.ChartButton.TabIndex = 34;
            this.ChartButton.Text = "Data Chart";
            this.ChartButton.UseVisualStyleBackColor = true;
            this.ChartButton.Click += new System.EventHandler(this.ChartButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SaveButton.Location = new System.Drawing.Point(1069, 441);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(153, 34);
            this.SaveButton.TabIndex = 33;
            this.SaveButton.Text = "Data Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // TentativeHeaderCheckBox
            // 
            this.TentativeHeaderCheckBox.AutoSize = true;
            this.TentativeHeaderCheckBox.Enabled = false;
            this.TentativeHeaderCheckBox.Location = new System.Drawing.Point(555, 200);
            this.TentativeHeaderCheckBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.TentativeHeaderCheckBox.Name = "TentativeHeaderCheckBox";
            this.TentativeHeaderCheckBox.Size = new System.Drawing.Size(160, 22);
            this.TentativeHeaderCheckBox.TabIndex = 14;
            this.TentativeHeaderCheckBox.Text = "TentativeHeader";
            this.TentativeHeaderCheckBox.UseVisualStyleBackColor = true;
            // 
            // PreconditionAllClearButton
            // 
            this.PreconditionAllClearButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PreconditionAllClearButton.Location = new System.Drawing.Point(1110, 225);
            this.PreconditionAllClearButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PreconditionAllClearButton.Name = "PreconditionAllClearButton";
            this.PreconditionAllClearButton.Size = new System.Drawing.Size(100, 28);
            this.PreconditionAllClearButton.TabIndex = 24;
            this.PreconditionAllClearButton.Text = "All Clear";
            this.PreconditionAllClearButton.UseVisualStyleBackColor = true;
            this.PreconditionAllClearButton.Click += new System.EventHandler(this.PreconditionAllClearButton_Click);
            // 
            // AndOrButton
            // 
            this.AndOrButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AndOrButton.Location = new System.Drawing.Point(750, 225);
            this.AndOrButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.AndOrButton.Name = "AndOrButton";
            this.AndOrButton.Size = new System.Drawing.Size(55, 28);
            this.AndOrButton.TabIndex = 21;
            this.AndOrButton.Text = "And";
            this.AndOrButton.UseVisualStyleBackColor = true;
            this.AndOrButton.Click += new System.EventHandler(this.AndOrButton_Click);
            // 
            // QueryCheckBox
            // 
            this.QueryCheckBox.AutoSize = true;
            this.QueryCheckBox.Location = new System.Drawing.Point(750, 262);
            this.QueryCheckBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.QueryCheckBox.Name = "QueryCheckBox";
            this.QueryCheckBox.Size = new System.Drawing.Size(131, 22);
            this.QueryCheckBox.TabIndex = 25;
            this.QueryCheckBox.Text = "Where Query";
            this.QueryCheckBox.UseVisualStyleBackColor = true;
            // 
            // QueryRichTextBox
            // 
            this.QueryRichTextBox.Location = new System.Drawing.Point(750, 290);
            this.QueryRichTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.QueryRichTextBox.Name = "QueryRichTextBox";
            this.QueryRichTextBox.Size = new System.Drawing.Size(604, 139);
            this.QueryRichTextBox.TabIndex = 26;
            this.QueryRichTextBox.Text = "";
            this.QueryRichTextBox.WordWrap = false;
            // 
            // PreconditionClearButton
            // 
            this.PreconditionClearButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PreconditionClearButton.Location = new System.Drawing.Point(1033, 225);
            this.PreconditionClearButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PreconditionClearButton.Name = "PreconditionClearButton";
            this.PreconditionClearButton.Size = new System.Drawing.Size(67, 28);
            this.PreconditionClearButton.TabIndex = 23;
            this.PreconditionClearButton.Text = "Clear";
            this.PreconditionClearButton.UseVisualStyleBackColor = true;
            this.PreconditionClearButton.Click += new System.EventHandler(this.PreconditionClearButton_Click);
            // 
            // PreconditionValueLabel
            // 
            this.PreconditionValueLabel.AutoSize = true;
            this.PreconditionValueLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PreconditionValueLabel.Location = new System.Drawing.Point(745, 194);
            this.PreconditionValueLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PreconditionValueLabel.Name = "PreconditionValueLabel";
            this.PreconditionValueLabel.Size = new System.Drawing.Size(195, 23);
            this.PreconditionValueLabel.TabIndex = 127;
            this.PreconditionValueLabel.Text = "Precondition Value";
            // 
            // ViewColumnsLabel
            // 
            this.ViewColumnsLabel.AutoSize = true;
            this.ViewColumnsLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ViewColumnsLabel.Location = new System.Drawing.Point(380, 198);
            this.ViewColumnsLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ViewColumnsLabel.Name = "ViewColumnsLabel";
            this.ViewColumnsLabel.Size = new System.Drawing.Size(148, 23);
            this.ViewColumnsLabel.TabIndex = 126;
            this.ViewColumnsLabel.Text = "View Columns";
            // 
            // KeyDataLabel
            // 
            this.KeyDataLabel.AutoSize = true;
            this.KeyDataLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.KeyDataLabel.Location = new System.Drawing.Point(20, 198);
            this.KeyDataLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.KeyDataLabel.Name = "KeyDataLabel";
            this.KeyDataLabel.Size = new System.Drawing.Size(99, 23);
            this.KeyDataLabel.TabIndex = 125;
            this.KeyDataLabel.Text = "Key Data";
            // 
            // PreconditionTextBox
            // 
            this.PreconditionTextBox.Location = new System.Drawing.Point(815, 225);
            this.PreconditionTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PreconditionTextBox.Name = "PreconditionTextBox";
            this.PreconditionTextBox.Size = new System.Drawing.Size(206, 25);
            this.PreconditionTextBox.TabIndex = 22;
            this.PreconditionTextBox.Leave += new System.EventHandler(this.PreconditionTextBox_Leave);
            // 
            // KeyCheckedListBox
            // 
            this.KeyCheckedListBox.FormattingEnabled = true;
            this.KeyCheckedListBox.HorizontalScrollbar = true;
            this.KeyCheckedListBox.Location = new System.Drawing.Point(385, 267);
            this.KeyCheckedListBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.KeyCheckedListBox.Name = "KeyCheckedListBox";
            this.KeyCheckedListBox.Size = new System.Drawing.Size(347, 180);
            this.KeyCheckedListBox.TabIndex = 17;
            // 
            // DataNumberLabel
            // 
            this.DataNumberLabel.AutoSize = true;
            this.DataNumberLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DataNumberLabel.Location = new System.Drawing.Point(743, 444);
            this.DataNumberLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.DataNumberLabel.Name = "DataNumberLabel";
            this.DataNumberLabel.Size = new System.Drawing.Size(149, 23);
            this.DataNumberLabel.TabIndex = 121;
            this.DataNumberLabel.Text = "DataNumber : ";
            // 
            // ConnectionLabel
            // 
            this.ConnectionLabel.AutoSize = true;
            this.ConnectionLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConnectionLabel.Location = new System.Drawing.Point(1392, 64);
            this.ConnectionLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.ConnectionLabel.Name = "ConnectionLabel";
            this.ConnectionLabel.Size = new System.Drawing.Size(116, 23);
            this.ConnectionLabel.TabIndex = 117;
            this.ConnectionLabel.Text = ": Unsettled";
            // 
            // DataComboBox
            // 
            this.DataComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataComboBox.FormattingEnabled = true;
            this.DataComboBox.ItemHeight = 18;
            this.DataComboBox.Location = new System.Drawing.Point(660, 159);
            this.DataComboBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.DataComboBox.Name = "DataComboBox";
            this.DataComboBox.Size = new System.Drawing.Size(547, 26);
            this.DataComboBox.TabIndex = 12;
            this.DataComboBox.TextChanged += new System.EventHandler(this.DataComboBox_TextChanged);
            // 
            // ConnectionButton
            // 
            this.ConnectionButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConnectionButton.Location = new System.Drawing.Point(1228, 58);
            this.ConnectionButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ConnectionButton.Name = "ConnectionButton";
            this.ConnectionButton.Size = new System.Drawing.Size(160, 34);
            this.ConnectionButton.TabIndex = 47;
            this.ConnectionButton.Text = "Connection";
            this.ConnectionButton.UseVisualStyleBackColor = true;
            this.ConnectionButton.Click += new System.EventHandler(this.ConnectionButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ClearButton.Location = new System.Drawing.Point(1364, 230);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(154, 34);
            this.ClearButton.TabIndex = 31;
            this.ClearButton.Text = "All Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ViewButton
            // 
            this.ViewButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ViewButton.Location = new System.Drawing.Point(1364, 269);
            this.ViewButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ViewButton.Name = "ViewButton";
            this.ViewButton.Size = new System.Drawing.Size(154, 34);
            this.ViewButton.TabIndex = 32;
            this.ViewButton.Text = "Data View";
            this.ViewButton.UseVisualStyleBackColor = true;
            this.ViewButton.Click += new System.EventHandler(this.ViewButton_Click);
            // 
            // DataKeyComboBox
            // 
            this.DataKeyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataKeyComboBox.FormattingEnabled = true;
            this.DataKeyComboBox.Location = new System.Drawing.Point(92, 159);
            this.DataKeyComboBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.DataKeyComboBox.Name = "DataKeyComboBox";
            this.DataKeyComboBox.Size = new System.Drawing.Size(547, 26);
            this.DataKeyComboBox.TabIndex = 13;
            // 
            // KeyRichTextBox
            // 
            this.KeyRichTextBox.Location = new System.Drawing.Point(25, 225);
            this.KeyRichTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.KeyRichTextBox.Name = "KeyRichTextBox";
            this.KeyRichTextBox.Size = new System.Drawing.Size(347, 235);
            this.KeyRichTextBox.TabIndex = 18;
            this.KeyRichTextBox.Text = "";
            this.KeyRichTextBox.WordWrap = false;
            // 
            // KeyLabel
            // 
            this.KeyLabel.AutoSize = true;
            this.KeyLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.KeyLabel.Location = new System.Drawing.Point(20, 159);
            this.KeyLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(47, 23);
            this.KeyLabel.TabIndex = 110;
            this.KeyLabel.Text = "Key";
            // 
            // PasswordComboBox
            // 
            this.PasswordComboBox.FormattingEnabled = true;
            this.PasswordComboBox.Location = new System.Drawing.Point(660, 112);
            this.PasswordComboBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PasswordComboBox.Name = "PasswordComboBox";
            this.PasswordComboBox.Size = new System.Drawing.Size(414, 26);
            this.PasswordComboBox.TabIndex = 46;
            // 
            // UserComboBox
            // 
            this.UserComboBox.FormattingEnabled = true;
            this.UserComboBox.ItemHeight = 18;
            this.UserComboBox.Location = new System.Drawing.Point(92, 112);
            this.UserComboBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.UserComboBox.Name = "UserComboBox";
            this.UserComboBox.Size = new System.Drawing.Size(414, 26);
            this.UserComboBox.TabIndex = 45;
            // 
            // PortComboBox
            // 
            this.PortComboBox.FormattingEnabled = true;
            this.PortComboBox.ItemHeight = 18;
            this.PortComboBox.Location = new System.Drawing.Point(945, 64);
            this.PortComboBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PortComboBox.Name = "PortComboBox";
            this.PortComboBox.Size = new System.Drawing.Size(129, 26);
            this.PortComboBox.TabIndex = 44;
            this.PortComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PortComboBox_KeyPress);
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PortLabel.Location = new System.Drawing.Point(878, 64);
            this.PortLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(52, 23);
            this.PortLabel.TabIndex = 106;
            this.PortLabel.Text = "Port";
            // 
            // DataNameComboBox
            // 
            this.DataNameComboBox.FormattingEnabled = true;
            this.DataNameComboBox.ItemHeight = 18;
            this.DataNameComboBox.Location = new System.Drawing.Point(158, 64);
            this.DataNameComboBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.DataNameComboBox.Name = "DataNameComboBox";
            this.DataNameComboBox.Size = new System.Drawing.Size(707, 26);
            this.DataNameComboBox.TabIndex = 43;
            // 
            // DataSourceComboBox
            // 
            this.DataSourceComboBox.FormattingEnabled = true;
            this.DataSourceComboBox.ItemHeight = 18;
            this.DataSourceComboBox.Location = new System.Drawing.Point(593, 16);
            this.DataSourceComboBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.DataSourceComboBox.Name = "DataSourceComboBox";
            this.DataSourceComboBox.Size = new System.Drawing.Size(922, 26);
            this.DataSourceComboBox.TabIndex = 42;
            // 
            // DataTypeComboBox
            // 
            this.DataTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataTypeComboBox.FormattingEnabled = true;
            this.DataTypeComboBox.ItemHeight = 18;
            this.DataTypeComboBox.Location = new System.Drawing.Point(150, 16);
            this.DataTypeComboBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.DataTypeComboBox.Name = "DataTypeComboBox";
            this.DataTypeComboBox.Size = new System.Drawing.Size(261, 26);
            this.DataTypeComboBox.TabIndex = 41;
            this.DataTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.DataTypeComboBox_SelectedIndexChanged);
            // 
            // MainDataGridView
            // 
            this.MainDataGridView.AllowDrop = true;
            this.MainDataGridView.AllowUserToOrderColumns = true;
            this.MainDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDataGridView.Location = new System.Drawing.Point(25, 483);
            this.MainDataGridView.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MainDataGridView.Name = "MainDataGridView";
            this.MainDataGridView.RowHeadersWidth = 62;
            this.MainDataGridView.RowTemplate.Height = 21;
            this.MainDataGridView.Size = new System.Drawing.Size(1493, 525);
            this.MainDataGridView.TabIndex = 115;
            this.MainDataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainDataGridView_DragDrop);
            this.MainDataGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainDataGridView_DragEnter);
            // 
            // DataTypeLabel
            // 
            this.DataTypeLabel.AutoSize = true;
            this.DataTypeLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DataTypeLabel.Location = new System.Drawing.Point(20, 16);
            this.DataTypeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.DataTypeLabel.Name = "DataTypeLabel";
            this.DataTypeLabel.Size = new System.Drawing.Size(110, 23);
            this.DataTypeLabel.TabIndex = 103;
            this.DataTypeLabel.Text = "Data Type";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PasswordLabel.Location = new System.Drawing.Point(538, 112);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(103, 23);
            this.PasswordLabel.TabIndex = 101;
            this.PasswordLabel.Text = "Password";
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.UserLabel.Location = new System.Drawing.Point(20, 112);
            this.UserLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(56, 23);
            this.UserLabel.TabIndex = 99;
            this.UserLabel.Text = "User";
            // 
            // DataSourceLabel
            // 
            this.DataSourceLabel.AutoSize = true;
            this.DataSourceLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DataSourceLabel.Location = new System.Drawing.Point(438, 16);
            this.DataSourceLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.DataSourceLabel.Name = "DataSourceLabel";
            this.DataSourceLabel.Size = new System.Drawing.Size(132, 23);
            this.DataSourceLabel.TabIndex = 98;
            this.DataSourceLabel.Text = "Data Source";
            // 
            // DataNameLabel
            // 
            this.DataNameLabel.AutoSize = true;
            this.DataNameLabel.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DataNameLabel.Location = new System.Drawing.Point(20, 64);
            this.DataNameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.DataNameLabel.Name = "DataNameLabel";
            this.DataNameLabel.Size = new System.Drawing.Size(117, 23);
            this.DataNameLabel.TabIndex = 96;
            this.DataNameLabel.Text = "Data Name";
            // 
            // DecryptButton
            // 
            this.DecryptButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DecryptButton.Location = new System.Drawing.Point(1332, 440);
            this.DecryptButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(88, 34);
            this.DecryptButton.TabIndex = 97;
            this.DecryptButton.Text = "Decrypt";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // EncryptButton
            // 
            this.EncryptButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EncryptButton.Location = new System.Drawing.Point(1232, 440);
            this.EncryptButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(90, 34);
            this.EncryptButton.TabIndex = 96;
            this.EncryptButton.Text = "Encrypt";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // EncryptSetButton
            // 
            this.EncryptSetButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EncryptSetButton.Location = new System.Drawing.Point(1430, 440);
            this.EncryptSetButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.EncryptSetButton.Name = "EncryptSetButton";
            this.EncryptSetButton.Size = new System.Drawing.Size(88, 34);
            this.EncryptSetButton.TabIndex = 98;
            this.EncryptSetButton.Text = "EncSet";
            this.EncryptSetButton.UseVisualStyleBackColor = true;
            this.EncryptSetButton.Click += new System.EventHandler(this.EncryptSetButton_Click);
            // 
            // KPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EncryptSetButton);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.EncryptButton);
            this.Controls.Add(this.ConnectionResetButton);
            this.Controls.Add(this.ConnectionSaveButton);
            this.Controls.Add(this.AllUnCheckButton);
            this.Controls.Add(this.AllCheckButton);
            this.Controls.Add(this.DataBackButton);
            this.Controls.Add(this.MaskButton);
            this.Controls.Add(this.QuerySaveButton);
            this.Controls.Add(this.ChartButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.TentativeHeaderCheckBox);
            this.Controls.Add(this.PreconditionAllClearButton);
            this.Controls.Add(this.AndOrButton);
            this.Controls.Add(this.QueryCheckBox);
            this.Controls.Add(this.QueryRichTextBox);
            this.Controls.Add(this.PreconditionClearButton);
            this.Controls.Add(this.PreconditionValueLabel);
            this.Controls.Add(this.ViewColumnsLabel);
            this.Controls.Add(this.KeyDataLabel);
            this.Controls.Add(this.PreconditionTextBox);
            this.Controls.Add(this.KeyCheckedListBox);
            this.Controls.Add(this.DataNumberLabel);
            this.Controls.Add(this.ConnectionLabel);
            this.Controls.Add(this.DataComboBox);
            this.Controls.Add(this.ConnectionButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ViewButton);
            this.Controls.Add(this.DataKeyComboBox);
            this.Controls.Add(this.KeyRichTextBox);
            this.Controls.Add(this.KeyLabel);
            this.Controls.Add(this.PasswordComboBox);
            this.Controls.Add(this.UserComboBox);
            this.Controls.Add(this.PortComboBox);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.DataNameComboBox);
            this.Controls.Add(this.DataSourceComboBox);
            this.Controls.Add(this.DataTypeComboBox);
            this.Controls.Add(this.MainDataGridView);
            this.Controls.Add(this.DataTypeLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.DataSourceLabel);
            this.Controls.Add(this.DataNameLabel);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "KPDV";
            this.Size = new System.Drawing.Size(1535, 1020);
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectionResetButton;
        private System.Windows.Forms.Button ConnectionSaveButton;
        private System.Windows.Forms.Button AllUnCheckButton;
        private System.Windows.Forms.Button AllCheckButton;
        private System.Windows.Forms.Button DataBackButton;
        private System.Windows.Forms.Button MaskButton;
        private System.Windows.Forms.Button QuerySaveButton;
        private System.Windows.Forms.Button ChartButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.CheckBox TentativeHeaderCheckBox;
        private System.Windows.Forms.Button PreconditionAllClearButton;
        private System.Windows.Forms.Button AndOrButton;
        private System.Windows.Forms.CheckBox QueryCheckBox;
        private System.Windows.Forms.RichTextBox QueryRichTextBox;
        private System.Windows.Forms.Button PreconditionClearButton;
        private System.Windows.Forms.Label PreconditionValueLabel;
        private System.Windows.Forms.Label ViewColumnsLabel;
        private System.Windows.Forms.Label KeyDataLabel;
        private System.Windows.Forms.TextBox PreconditionTextBox;
        private System.Windows.Forms.CheckedListBox KeyCheckedListBox;
        private System.Windows.Forms.Label DataNumberLabel;
        private System.Windows.Forms.Label ConnectionLabel;
        private System.Windows.Forms.ComboBox DataComboBox;
        private System.Windows.Forms.Button ConnectionButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ViewButton;
        private System.Windows.Forms.ComboBox DataKeyComboBox;
        private System.Windows.Forms.RichTextBox KeyRichTextBox;
        private System.Windows.Forms.Label KeyLabel;
        private System.Windows.Forms.ComboBox PasswordComboBox;
        private System.Windows.Forms.ComboBox UserComboBox;
        private System.Windows.Forms.ComboBox PortComboBox;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.ComboBox DataNameComboBox;
        private System.Windows.Forms.ComboBox DataSourceComboBox;
        private System.Windows.Forms.ComboBox DataTypeComboBox;
        private System.Windows.Forms.DataGridView MainDataGridView;
        private System.Windows.Forms.Label DataTypeLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Label DataSourceLabel;
        private System.Windows.Forms.Label DataNameLabel;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.Button EncryptButton;
        private System.Windows.Forms.Button EncryptSetButton;
    }
}
