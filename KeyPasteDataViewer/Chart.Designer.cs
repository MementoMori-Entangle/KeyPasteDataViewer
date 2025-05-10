namespace KeyPasteDataViewer
{
    partial class Chart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.MainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.PrintDocument = new System.Drawing.Printing.PrintDocument();
            this.PrintButton = new System.Windows.Forms.Button();
            this.PreviewButton = new System.Windows.Forms.Button();
            this.PrintSettingButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).BeginInit();
            this.SuspendLayout();
            // 
            // MainChart
            // 
            this.MainChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.MainChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.MainChart.Legends.Add(legend1);
            this.MainChart.Location = new System.Drawing.Point(12, 40);
            this.MainChart.Name = "MainChart";
            this.MainChart.Size = new System.Drawing.Size(760, 509);
            this.MainChart.TabIndex = 0;
            this.MainChart.Text = "テスト";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(581, 13);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(130, 20);
            this.TypeComboBox.TabIndex = 1;
            this.TypeComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeComboBox_SelectedIndexChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CloseButton.Location = new System.Drawing.Point(717, 12);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(55, 21);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // PrintDocument
            // 
            this.PrintDocument.DocumentName = "chart";
            // 
            // PrintButton
            // 
            this.PrintButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PrintButton.Location = new System.Drawing.Point(73, 13);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(55, 21);
            this.PrintButton.TabIndex = 3;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // PreviewButton
            // 
            this.PreviewButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PreviewButton.Location = new System.Drawing.Point(12, 13);
            this.PreviewButton.Name = "PreviewButton";
            this.PreviewButton.Size = new System.Drawing.Size(55, 21);
            this.PreviewButton.TabIndex = 4;
            this.PreviewButton.Text = "Preview";
            this.PreviewButton.UseVisualStyleBackColor = true;
            this.PreviewButton.Click += new System.EventHandler(this.PreviewButton_Click);
            // 
            // PrintSettingButton
            // 
            this.PrintSettingButton.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PrintSettingButton.Location = new System.Drawing.Point(134, 13);
            this.PrintSettingButton.Name = "PrintSettingButton";
            this.PrintSettingButton.Size = new System.Drawing.Size(77, 21);
            this.PrintSettingButton.TabIndex = 2;
            this.PrintSettingButton.Text = "Print Setting";
            this.PrintSettingButton.UseVisualStyleBackColor = true;
            this.PrintSettingButton.Click += new System.EventHandler(this.PrintSettingButton_Click);
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.PrintSettingButton);
            this.Controls.Add(this.PreviewButton);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.MainChart);
            this.Name = "Chart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chart";
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart MainChart;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.Button CloseButton;
        private System.Drawing.Printing.PrintDocument PrintDocument;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button PreviewButton;
        private System.Windows.Forms.Button PrintSettingButton;
    }
}