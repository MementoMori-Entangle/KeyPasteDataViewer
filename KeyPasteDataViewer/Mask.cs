using System.Collections.Generic;
using System.Windows.Forms;

namespace KeyPasteDataViewer
{
    /// <summary>
    /// 対象マスク
    /// </summary>
    public partial class Mask : Form
    {
        /// <summary>
        /// キー貼り付けデータ
        /// </summary>
        readonly KeyPasteData keyPasteData;

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        /// <param name="keyPasteData">キー貼り付けデータ</param>
        public Mask(KeyPasteData keyPasteData)
        {
            InitializeComponent();

            this.keyPasteData = keyPasteData;
        }

        /// <summary>
        /// データ設定
        /// </summary>
        /// <param name="dataList">データリスト</param>
        public void SetData(List<string> dataList)
        {
            foreach (string data in dataList)
            {
                KeyCheckedListBox.Items.Add(data);
            }
        }

        /// <summary>
        /// データマスクボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataMaskButton_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(MaskStringTextBox.Text))
            {
                this.keyPasteData.MaskData(KeyCheckedListBox, MaskStringTextBox.Text);
            }
            else
            {
                this.keyPasteData.MaskData(KeyCheckedListBox);
            }
        }

        /// <summary>
        /// データ戻しボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataBackButton_Click(object sender, System.EventArgs e)
        {
            this.keyPasteData.BackData();
        }

        /// <summary>
        /// 閉じるボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// マスク文字列クリアボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskStringClearButton_Click(object sender, System.EventArgs e)
        {
            MaskStringTextBox.Text = "";
        }
    }
}
