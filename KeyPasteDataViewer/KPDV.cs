using EncryptionDecryptionLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace KeyPasteDataViewer
{
    public partial class KPDV : UserControl
    {
        /// <summary>
        /// キー貼り付けデータ
        /// </summary>
        private readonly KeyPasteData keyPasteData;

        /// <summary>
        /// データキーリスト
        /// </summary>
        private List<string> dataKeyList;

        /// <summary>
        /// 暗号・復号
        /// </summary>
        private readonly EncryptDecrypt encryptDecrypt;

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        public KPDV()
        {
            InitializeComponent();

            this.keyPasteData = new KeyPasteData();
            this.dataKeyList = new List<string>();
            this.keyPasteData.MainDataGridView = MainDataGridView;
            this.encryptDecrypt = new EncryptDecrypt();

            // 設定ファイル読込み
            this.LoadSetting();
        }

        /// <summary>
        /// 接続ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Connection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), KeyPasteData.MESSAGE_BOX_HEADER_TITLE_ERROR,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 接続情報保存ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectionSaveButton_Click(object sender, EventArgs e)
        {
            this.ConnectionInfoSave();
        }

        /// <summary>
        /// 接続情報リセットボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectionResetButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            this.LoadSetting();
        }

        /// <summary>
        /// クエリ保存ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuerySaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default[KeyPasteData.KEY_QUERY_TEXT] = QueryRichTextBox.Text;
            Properties.Settings.Default[KeyPasteData.KEY_QUERY_CHECK] = QueryCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// データ(テーブル/シート)変更時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataComboBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string data = DataComboBox.Text;

                if (!string.IsNullOrEmpty(data))
                {
                    switch (this.keyPasteData.DataType)
                    {
                        case KeyPasteData.DATA_TYPE_SQLSERVER:
                            this.dataKeyList = this.keyPasteData.GetTableInfo(KeyPasteData.DB_SQLSERVER_TABLE_COLUMNS_NAME_QUERY, data);
                            break;
                        case KeyPasteData.DATA_TYPE_MYSQL:
                            this.dataKeyList = this.keyPasteData.GetTableInfo(KeyPasteData.DB_MYSQL_TABLE_COLUMNS_NAME_QUERY, data, this.keyPasteData.Catalog);
                            break;
                        case KeyPasteData.DATA_TYPE_POSTGRESQL:
                            this.dataKeyList = this.keyPasteData.GetTableInfo(KeyPasteData.DB_POSTGRESQL_TABLE_COLUMNS_NAME_QUERY, data, null);
                            break;
                        case KeyPasteData.DATA_TYPE_ORACLE:
                            this.dataKeyList = this.keyPasteData.GetTableInfo(KeyPasteData.DB_ORACLE_TABLE_COLUMNS_NAME_QUERY, data, null);
                            break;
                        case KeyPasteData.DATA_TYPE_EXCEL:
                            this.dataKeyList = this.keyPasteData.GetExcelHeaderInfo(TentativeHeaderCheckBox.Checked, data);
                            this.keyPasteData.LoadDataTable(TentativeHeaderCheckBox.Checked, data);
                            break;
                        default:
                            break;
                    }

                    DataKeyComboBox.Items.Clear();
                    KeyCheckedListBox.Items.Clear();

                    PreconditionTextBox.Text = KeyPasteData.BLANK;

                    foreach (string dataKey in this.dataKeyList)
                    {
                        DataKeyComboBox.Items.Add(dataKey);
                        KeyCheckedListBox.Items.Add(dataKey, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), KeyPasteData.MESSAGE_BOX_HEADER_TITLE_ERROR,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// クリアボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        /// <summary>
        /// 表示ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewButton_Click(object sender, EventArgs e)
        {
            try
            {
                string query = null;
                string data = DataComboBox.Text;
                string dataKey = DataKeyComboBox.Text;

                if ((KeyPasteData.DATA_TYPE_CSV != this.keyPasteData.DataType && KeyPasteData.DATA_TYPE_TSV != this.keyPasteData.DataType)
                    && string.IsNullOrEmpty(data))
                {
                    MessageBox.Show(KeyPasteData.INPUT_ERROR_DATA_MESSAGE, KeyPasteData.MESSAGE_BOX_HEADER_TITLE_CONFIRM,
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

                if (!QueryCheckBox.Checked && string.IsNullOrEmpty(dataKey))
                {
                    MessageBox.Show(KeyPasteData.INPUT_ERROR_KEY_MESSAGE, KeyPasteData.MESSAGE_BOX_HEADER_TITLE_CONFIRM,
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

                string[] keyDatas = this.keyPasteData.RemoveBlankAndNewLineData(KeyRichTextBox.Text.Split(KeyPasteData.NEW_LINE_SP, StringSplitOptions.RemoveEmptyEntries));

                string inData = KeyPasteData.BLANK;

                if (null != keyDatas && KeyPasteData.ZERO < keyDatas.Length)
                {
                    inData = this.keyPasteData.GetInValue(keyDatas);
                }

                if (!QueryCheckBox.Checked && string.IsNullOrWhiteSpace(inData))
                {
                    MessageBox.Show(KeyPasteData.INPUT_ERROR_KEY_DATA_MESSAGE, KeyPasteData.MESSAGE_BOX_HEADER_TITLE_CONFIRM,
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

                DataTable table = null;

                string precondition = this.keyPasteData.GetPrecondition(DataComboBox.Text, AndOrButton.Text);

                switch (this.keyPasteData.DataType)
                {
                    case KeyPasteData.DATA_TYPE_SQLSERVER:
                    case KeyPasteData.DATA_TYPE_MYSQL:
                    case KeyPasteData.DATA_TYPE_POSTGRESQL:
                    case KeyPasteData.DATA_TYPE_ORACLE:
                        if (QueryCheckBox.Checked)
                        {
                            query = QueryRichTextBox.Text.Replace(KeyPasteData.NEW_LINE_R, KeyPasteData.BLANK).Replace(KeyPasteData.NEW_LINE_N, KeyPasteData.BLANK);

                            if (string.IsNullOrEmpty(query))
                            {
                                if (string.IsNullOrEmpty(precondition))
                                {
                                    query = KeyPasteData.SQL_SELECT + KeyPasteData.HALF_SPACE_BLANK + this.ConvertColumnName()
                                          + KeyPasteData.HALF_SPACE_BLANK + KeyPasteData.SQL_FROM + KeyPasteData.HALF_SPACE_BLANK + DataComboBox.Text;
                                }
                                else
                                {
                                    query = KeyPasteData.SQL_SELECT + KeyPasteData.HALF_SPACE_BLANK + this.ConvertColumnName()
                                          + KeyPasteData.HALF_SPACE_BLANK + KeyPasteData.SQL_FROM + KeyPasteData.HALF_SPACE_BLANK + DataComboBox.Text
                                          + KeyPasteData.HALF_SPACE_BLANK + KeyPasteData.SQL_WHERE + KeyPasteData.HALF_SPACE_BLANK + precondition;
                                }
                            }
                            else
                            {
                                query = KeyPasteData.SQL_SELECT + KeyPasteData.HALF_SPACE_BLANK + this.ConvertColumnName() + KeyPasteData.HALF_SPACE_BLANK
                                      + KeyPasteData.SQL_FROM + KeyPasteData.HALF_SPACE_BLANK + DataComboBox.Text + KeyPasteData.HALF_SPACE_BLANK
                                      + KeyPasteData.SQL_WHERE + KeyPasteData.HALF_SPACE_BLANK + precondition + query;
                            }
                        }

                        if (string.IsNullOrEmpty(query))
                        {
                            query = KeyPasteData.SQL_SELECT + KeyPasteData.HALF_SPACE_BLANK + this.ConvertColumnName() + KeyPasteData.HALF_SPACE_BLANK
                                  + KeyPasteData.SQL_FROM + KeyPasteData.HALF_SPACE_BLANK + DataComboBox.Text + KeyPasteData.HALF_SPACE_BLANK
                                  + KeyPasteData.SQL_WHERE + KeyPasteData.HALF_SPACE_BLANK + precondition + dataKey + KeyPasteData.SQL_WHERE_IN_PREFIX
                                  + inData + KeyPasteData.SQL_WHERE_IN_SUFFIX;
                        }

                        table = this.keyPasteData.GetDataTableFromQuery(query);
                        this.keyPasteData.ConvertDataGridView(table);
                        break;
                    case KeyPasteData.DATA_TYPE_EXCEL:
                    case KeyPasteData.DATA_TYPE_CSV:
                    case KeyPasteData.DATA_TYPE_TSV:
                        if (QueryCheckBox.Checked)
                        {
                            query = QueryRichTextBox.Text.Replace(KeyPasteData.NEW_LINE_R, KeyPasteData.BLANK).Replace(KeyPasteData.NEW_LINE_N, KeyPasteData.BLANK);


                            if (string.IsNullOrEmpty(query))
                            {
                                if (string.IsNullOrEmpty(precondition))
                                {
                                    query = KeyPasteData.WHERE_ALL;
                                }
                                else
                                {
                                    query = precondition + KeyPasteData.WHERE_ALL;
                                }
                            }
                            else
                            {
                                query = precondition + query;
                            }
                        }

                        if (string.IsNullOrEmpty(query))
                        {
                            query = precondition + dataKey + KeyPasteData.SQL_WHERE_IN_PREFIX + inData + KeyPasteData.SQL_WHERE_IN_SUFFIX;
                        }

                        this.ConvertColumnName();

                        DataRow[] dataRows = this.keyPasteData.DataTable.Select(query);

                        table = this.keyPasteData.DataTable.Clone();

                        foreach (DataRow dataRow in dataRows)
                        {
                            table.ImportRow(dataRow);
                        }

                        this.keyPasteData.ConvertDataGridView(table);
                        break;
                    default:
                        break;
                }

                int cnt = MainDataGridView.RowCount;

                if (KeyPasteData.ZERO < cnt)
                {
                    cnt--;
                }

                DataNumberLabel.Text = KeyPasteData.DATA_NUMBER_PREFIX + string.Format(KeyPasteData.COMMA_NUMBER_FORMAT, cnt);

                this.keyPasteData.BackDataGridView = this.keyPasteData.CopyDataOfDataGridView(MainDataGridView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), KeyPasteData.MESSAGE_BOX_HEADER_TITLE_ERROR,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// キーチェック選択時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreconditionValueLabel.Text = KeyCheckedListBox.Text;

            if (this.keyPasteData.PreconditionDictionary.ContainsKey(this.keyPasteData.DataType)
                && this.keyPasteData.PreconditionDictionary[this.keyPasteData.DataType].ContainsKey(this.keyPasteData.Catalog)
                && this.keyPasteData.PreconditionDictionary[this.keyPasteData.DataType][this.keyPasteData.Catalog].ContainsKey(DataComboBox.Text)
                && this.keyPasteData.PreconditionDictionary[this.keyPasteData.DataType][this.keyPasteData.Catalog][DataComboBox.Text].ContainsKey(KeyCheckedListBox.Text))
            {
                PreconditionTextBox.Text = this.keyPasteData.PreconditionDictionary[this.keyPasteData.DataType][this.keyPasteData.Catalog][DataComboBox.Text][KeyCheckedListBox.Text];
            }
            else
            {
                PreconditionTextBox.Text = KeyPasteData.BLANK;
            }
        }

        /// <summary>
        /// 前提条件値変更時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreconditionTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.keyPasteData.DataType))
            {
                return;
            }

            if (string.IsNullOrEmpty(this.keyPasteData.Catalog))
            {
                return;
            }

            if ((KeyPasteData.DATA_TYPE_SQLSERVER == this.keyPasteData.DataType || KeyPasteData.DATA_TYPE_MYSQL == this.keyPasteData.DataType
                || KeyPasteData.DATA_TYPE_POSTGRESQL == this.keyPasteData.DataType || KeyPasteData.DATA_TYPE_ORACLE == this.keyPasteData.DataType
                || KeyPasteData.DATA_TYPE_EXCEL == this.keyPasteData.DataType)
                && string.IsNullOrEmpty(DataComboBox.Text))
            {
                return;
            }

            if (string.IsNullOrEmpty(KeyCheckedListBox.Text))
            {
                return;
            }

            if (!this.keyPasteData.PreconditionDictionary.ContainsKey(this.keyPasteData.DataType))
            {
                this.keyPasteData.PreconditionDictionary.Add(this.keyPasteData.DataType, new Dictionary<string, Dictionary<string, Dictionary<string, string>>>());
            }

            if (!this.keyPasteData.PreconditionDictionary[this.keyPasteData.DataType].ContainsKey(this.keyPasteData.Catalog))
            {
                this.keyPasteData.PreconditionDictionary[this.keyPasteData.DataType].Add(this.keyPasteData.Catalog, new Dictionary<string, Dictionary<string, string>>());
            }

            if (!this.keyPasteData.PreconditionDictionary[this.keyPasteData.DataType][this.keyPasteData.Catalog].ContainsKey(DataComboBox.Text))
            {
                this.keyPasteData.PreconditionDictionary[this.keyPasteData.DataType][this.keyPasteData.Catalog].Add(DataComboBox.Text, new Dictionary<string, string>());
            }

            if (this.keyPasteData.PreconditionDictionary[this.keyPasteData.DataType][this.keyPasteData.Catalog][DataComboBox.Text].ContainsKey(KeyCheckedListBox.Text))
            {
                this.keyPasteData.PreconditionDictionary[this.keyPasteData.DataType][this.keyPasteData.Catalog][DataComboBox.Text][KeyCheckedListBox.Text] = PreconditionTextBox.Text;
            }
            else
            {
                this.keyPasteData.PreconditionDictionary[this.keyPasteData.DataType][this.keyPasteData.Catalog][DataComboBox.Text].Add(KeyCheckedListBox.Text, PreconditionTextBox.Text);
            }
        }

        /// <summary>
        /// 前提条件クリアボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreconditionClearButton_Click(object sender, EventArgs e)
        {
            if (this.keyPasteData.PreconditionDictionary.ContainsKey(this.keyPasteData.DataType)
                && this.keyPasteData.PreconditionDictionary[this.keyPasteData.DataType].ContainsKey(this.keyPasteData.Catalog)
                && this.keyPasteData.PreconditionDictionary[this.keyPasteData.DataType][this.keyPasteData.Catalog].ContainsKey(DataComboBox.Text)
                && this.keyPasteData.PreconditionDictionary[this.keyPasteData.DataType][this.keyPasteData.Catalog][DataComboBox.Text].ContainsKey(KeyCheckedListBox.Text))
            {
                this.keyPasteData.PreconditionDictionary[this.keyPasteData.DataType][this.keyPasteData.Catalog][DataComboBox.Text].Remove(KeyCheckedListBox.Text);

                PreconditionTextBox.Text = KeyPasteData.BLANK;
            }
        }

        /// <summary>
        /// 前提条件全クリアボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreconditionAllClearButton_Click(object sender, EventArgs e)
        {
            this.keyPasteData.PreconditionDictionary = new Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>>();

            PreconditionTextBox.Text = KeyPasteData.BLANK;
        }

        /// <summary>
        /// And or Orボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AndOrButton_Click(object sender, EventArgs e)
        {
            if (KeyPasteData.WHERE_AND == AndOrButton.Text)
            {
                AndOrButton.Text = KeyPasteData.WHERE_OR;
            }
            else
            {
                AndOrButton.Text = KeyPasteData.WHERE_AND;
            }
        }

        /// <summary>
        /// データ種別変更時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DataTypeComboBox.Text)
            {
                case KeyPasteData.DATA_TYPE_SQLSERVER:
                case KeyPasteData.DATA_TYPE_MYSQL:
                case KeyPasteData.DATA_TYPE_POSTGRESQL:
                case KeyPasteData.DATA_TYPE_ORACLE:
                    TentativeHeaderCheckBox.Enabled = false;
                    PortComboBox.Enabled = true;
                    break;
                default:
                    TentativeHeaderCheckBox.Enabled = true;
                    PortComboBox.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// 保存ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            int record = MainDataGridView.RowCount;
            int columns = MainDataGridView.ColumnCount;

            if (KeyPasteData.ONE > record || KeyPasteData.ZERO == columns)
            {
                MessageBox.Show(KeyPasteData.OUTPUT_ERROR_DATA_MESSAGE, KeyPasteData.MESSAGE_BOX_HEADER_TITLE_CONFIRM,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                FileName = KeyPasteData.SAVE_FILE_NAME,
                InitialDirectory = KeyPasteData.SAVE_FILE_PATH,
                Filter = KeyPasteData.SAVE_FILE_FILTER,
                Title = KeyPasteData.SAVE_FILE_TITLE,
                RestoreDirectory = true
            };

            if (DialogResult.OK == sfd.ShowDialog())
            {
                this.keyPasteData.OutPutFile(sfd.FileName, DataComboBox.Text);

                MessageBox.Show(KeyPasteData.OUTPUT_COMPLETED_MESSAGE, KeyPasteData.MESSAGE_BOX_HEADER_TITLE_COMPLETED,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// チャートボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChartButton_Click(object sender, EventArgs e)
        {
            try
            {
                string title = KeyPasteData.BLANK;

                switch (this.keyPasteData.DataType)
                {
                    case KeyPasteData.DATA_TYPE_SQLSERVER:
                    case KeyPasteData.DATA_TYPE_MYSQL:
                    case KeyPasteData.DATA_TYPE_POSTGRESQL:
                    case KeyPasteData.DATA_TYPE_ORACLE:
                    case KeyPasteData.DATA_TYPE_EXCEL:
                        title = DataComboBox.Text;
                        break;
                    case KeyPasteData.DATA_TYPE_CSV:
                    case KeyPasteData.DATA_TYPE_TSV:
                        title = DataNameComboBox.Text;
                        break;
                    default:
                        break;
                }

                Chart chart = new Chart
                {
                    ChartDataGridView = MainDataGridView,
                    Title = title,
                    TitleX = KeyPasteData.CHART_X_TITLE,
                    TitleY = KeyPasteData.CHART_Y_TITLE
                };

                chart.ChartCreator();
                chart.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), KeyPasteData.MESSAGE_BOX_HEADER_TITLE_ERROR,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// マスク押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskButton_Click(object sender, EventArgs e)
        {
            Mask mask = new Mask(this.keyPasteData);

            mask.SetData(this.keyPasteData.KeyCheckedList);
            mask.ShowDialog(this);
        }

        /// <summary>
        /// 戻しボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataBackButton_Click(object sender, EventArgs e)
        {
            this.keyPasteData.BackData();
        }

        /// <summary>
        /// データグリッドビュードラックアンドドロップ処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainDataGridView_DragDrop(object sender, DragEventArgs e)
        {
            string filePath = null;

            foreach (String file in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                filePath = file;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            string keyPasteData = Path.GetDirectoryName(filePath) + KeyPasteData.DIRECTORY_DELIMITER;
            string dataName = Path.GetFileName(filePath);

            DataSourceComboBox.Items.Add(keyPasteData);

            DataSourceComboBox.SelectedItem = keyPasteData;

            DataNameComboBox.Items.Add(dataName);

            DataNameComboBox.SelectedItem = dataName;

            switch (Path.GetExtension(filePath))
            {
                case KeyPasteData.EXCEL_EXP_NEW:
                case KeyPasteData.EXCEL_EXP_OLD:
                    DataTypeComboBox.SelectedItem = KeyPasteData.DATA_TYPE_EXCEL;
                    break;
                case KeyPasteData.CSV_EXP:
                    DataTypeComboBox.SelectedItem = KeyPasteData.DATA_TYPE_CSV;
                    break;
                case KeyPasteData.TSV_EXP:
                case KeyPasteData.TXT_EXP:
                    DataTypeComboBox.SelectedItem = KeyPasteData.DATA_TYPE_TSV;
                    break;
                default:
                    break;
            }

            this.Connection();
        }

        /// <summary>
        /// データグリッドビュー受け取り時制御
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainDataGridView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        /// <summary>
        /// 全チェックボックス ON処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllCheckButton_Click(object sender, EventArgs e)
        {
            int cnt = KeyCheckedListBox.Items.Count;

            for (int i = KeyPasteData.ZERO; i < cnt; i++)
            {
                KeyCheckedListBox.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// 全チェックボックス OFF処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllUnCheckButton_Click(object sender, EventArgs e)
        {
            int cnt = KeyCheckedListBox.Items.Count;

            for (int i = KeyPasteData.ZERO; i < cnt; i++)
            {
                KeyCheckedListBox.SetItemChecked(i, false);
            }
        }

        /// <summary>
        /// 復号化ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                EncryptionDecryption.Type type = this.CreateEncryptionDecryption(out EncryptionDecryption encryptionDecryption);

                foreach (DataGridViewCell c in MainDataGridView.SelectedCells)
                {
                    MainDataGridView[c.ColumnIndex, c.RowIndex].Value = encryptionDecryption.Decrypt(
                                                                            type,
                                                                            MainDataGridView[c.ColumnIndex, c.RowIndex].Value.ToString()
                                                                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), KeyPasteData.MESSAGE_BOX_HEADER_TITLE_ERROR,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 暗号化ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EncryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                EncryptionDecryption.Type type = this.CreateEncryptionDecryption(out EncryptionDecryption encryptionDecryption);

                foreach (DataGridViewCell c in MainDataGridView.SelectedCells)
                {
                    MainDataGridView[c.ColumnIndex, c.RowIndex].Value = encryptionDecryption.Encryption(
                                                                            type,
                                                                            MainDataGridView[c.ColumnIndex, c.RowIndex].Value.ToString()
                                                                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), KeyPasteData.MESSAGE_BOX_HEADER_TITLE_ERROR,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 暗号設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EncryptSetButton_Click(object sender, EventArgs e)
        {
            this.encryptDecrypt.ShowDialog();
        }

        /// <summary>
        /// 暗号・復号インスタンス情報を生成し、暗号種別を返す
        /// </summary>
        /// <param name="encryptionDecryption">暗号・復号クラス</param>
        /// <returns>暗号種別</returns>
        private EncryptionDecryption.Type CreateEncryptionDecryption(out EncryptionDecryption encryptionDecryption)
        {
            encryptionDecryption = new EncryptionDecryption
            {
                IvAES = this.encryptDecrypt.IvAES,
                KeyAES = this.encryptDecrypt.KeyAES,
                KeySizeAES = this.encryptDecrypt.KeySizeAES,
                BlockSizeAES = this.encryptDecrypt.BlockSizeAES
            };

            CipherMode mode;

            switch (this.encryptDecrypt.ModeAES)
            {
                case EncryptionDecryption.AES_CBC:
                    mode = CipherMode.CBC;
                    break;
                case EncryptionDecryption.AES_ECB:
                    mode = CipherMode.ECB;
                    break;
                case EncryptionDecryption.AES_OFB:
                    mode = CipherMode.OFB;
                    break;
                case EncryptionDecryption.AES_CFB:
                    mode = CipherMode.CFB;
                    break;
                case EncryptionDecryption.AES_CTS:
                    mode = CipherMode.CTS;
                    break;
                default:
                    mode = CipherMode.CBC;
                    break;
            }

            encryptionDecryption.ModeAES = mode;
            encryptionDecryption.KeySizeRSA = this.encryptDecrypt.KeySizeRSA;
            encryptionDecryption.PrivateKey = this.encryptDecrypt.PrivateKey;
            encryptionDecryption.PublicKey = this.encryptDecrypt.PublicKey;

            EncryptionDecryption.Type type;

            switch (this.encryptDecrypt.EncryptType)
            {
                case EncryptDecrypt.TYPE_AES:
                    type = EncryptionDecryption.Type.ASE;
                    break;
                case EncryptDecrypt.TYPE_RSA:
                    type = EncryptionDecryption.Type.RSA;
                    break;
                default:
                    type = EncryptionDecryption.Type.ASE;
                    break;
            }

            return type;
        }

        /// <summary>
        /// ポートの空白位置を返す
        /// </summary>
        /// <returns>ポートの空白位置</returns>
        private String GetPortBlankPosition()
        {
            string result = KeyPasteData.ZERO.ToString();

            int cnt = PortComboBox.Items.Count;

            for (int i = KeyPasteData.ZERO; i < cnt; i++)
            {
                if (KeyPasteData.BLANK == PortComboBox.Items[i].ToString())
                {
                    result = i.ToString();
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 接続情報を保存
        /// </summary>
        private void ConnectionInfoSave()
        {
            Properties.Settings.Default[KeyPasteData.KEY_DATA_SOURCE] = this.GetDataSourceCSV();
            Properties.Settings.Default[KeyPasteData.KEY_DATA_NAME] = this.GetDataNameCSV();
            Properties.Settings.Default[KeyPasteData.KEY_PORT] = this.GetPortCSV();
            Properties.Settings.Default[KeyPasteData.KEY_USER] = this.GetUserCSV();
            Properties.Settings.Default[KeyPasteData.KEY_PASSWORD] = this.GetPasswordCSV();
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// パスワードのCSV情報を返す
        /// </summary>
        /// <returns>パスワードのCSV情報</returns>
        private string GetPasswordCSV()
        {
            List<string> dataList = PasswordComboBox.Items.Cast<string>().ToList();
            string newData = PasswordComboBox.Text;

            return this.keyPasteData.GetDataCSV(dataList, newData);
        }

        /// <summary>
        /// ユーザーのCSV情報を返す
        /// </summary>
        /// <returns>ユーザーのCSV情報</returns>
        private string GetUserCSV()
        {
            List<string> dataList = UserComboBox.Items.Cast<string>().ToList();
            string newData = UserComboBox.Text;

            return this.keyPasteData.GetDataCSV(dataList, newData);
        }

        /// <summary>
        /// ポートのCSV情報を返す
        /// </summary>
        /// <returns>ポートのCSV情報</returns>
        private string GetPortCSV()
        {
            List<string> dataList = PortComboBox.Items.Cast<string>().ToList();
            string newData = PortComboBox.Text;

            return this.keyPasteData.GetPortCSV(dataList, newData);
        }

        /// <summary>
        /// データ名のCSV情報を返す
        /// </summary>
        /// <returns>データ名のCSV情報</returns>
        private string GetDataNameCSV()
        {
            List<string> dataList = DataNameComboBox.Items.Cast<string>().ToList();
            string newData = DataNameComboBox.Text;

            return this.keyPasteData.GetDataCSV(dataList, newData);
        }

        /// <summary>
        /// データソースのCSV情報を返す
        /// </summary>
        /// <returns>データソースのCSV情報</returns>
        private string GetDataSourceCSV()
        {
            List<string> dataList = DataSourceComboBox.Items.Cast<string>().ToList();
            string newData = DataSourceComboBox.Text;

            return this.keyPasteData.GetDataCSV(dataList, newData);
        }

        /// <summary>
        /// よく使う接続情報CSVを返す
        /// </summary>
        /// <returns>よく使う接続情報CSV</returns>
        private string GetUseConnection()
        {
            string ds = DataSourceComboBox.SelectedIndex.ToString();
            string dn = DataNameComboBox.SelectedIndex.ToString();
            string port = PortComboBox.SelectedIndex.ToString();
            string user = UserComboBox.SelectedIndex.ToString();
            string password = PasswordComboBox.SelectedIndex.ToString();

            if (0 > DataSourceComboBox.SelectedIndex && KeyPasteData.BLANK == DataSourceComboBox.Text)
            {
                ds = KeyPasteData.MINUS.ToString();
            }
            else if (0 > DataSourceComboBox.SelectedIndex)
            {
                ds = DataSourceComboBox.Items.Count.ToString();
            }

            if (0 > DataNameComboBox.SelectedIndex && KeyPasteData.BLANK == DataNameComboBox.Text)
            {
                dn = KeyPasteData.MINUS.ToString();
            }
            else if (0 > DataNameComboBox.SelectedIndex)
            {
                dn = DataNameComboBox.Items.Count.ToString();
            }

            if (0 > PortComboBox.SelectedIndex && KeyPasteData.BLANK == PortComboBox.Text)
            {
                port = KeyPasteData.BLANK_JUDGMENT_VALUE;
            }
            else if (0 > PortComboBox.SelectedIndex)
            {
                port = PortComboBox.Items.Count.ToString();
            }

            if (0 > UserComboBox.SelectedIndex && KeyPasteData.BLANK == UserComboBox.Text)
            {
                user = KeyPasteData.MINUS.ToString();
            }
            else if (0 > UserComboBox.SelectedIndex)
            {
                user = UserComboBox.Items.Count.ToString();
            }

            if (0 > PasswordComboBox.SelectedIndex && KeyPasteData.BLANK == PasswordComboBox.Text)
            {
                password = KeyPasteData.MINUS.ToString();
            }
            else if (0 > PasswordComboBox.SelectedIndex)
            {
                password = PasswordComboBox.Items.Count.ToString();
            }

            string csvTemp = DataTypeComboBox.SelectedIndex.ToString() + KeyPasteData.COMMA
                           + ds + KeyPasteData.COMMA
                           + dn + KeyPasteData.COMMA
                           + port + KeyPasteData.COMMA
                           + user + KeyPasteData.COMMA
                           + password;

            return csvTemp;
        }

        /// <summary>
        /// クリア処理
        /// </summary>
        private void Clear()
        {
            int cnt = this.keyPasteData.KeyCheckedList.Count;

            if (KeyPasteData.ZERO < MainDataGridView.Columns.Count)
            {
                for (int i = KeyPasteData.ZERO; i < cnt; i++)
                {
                    MainDataGridView.Columns[i].HeaderText = KeyPasteData.BLANK;
                }
            }

            MainDataGridView.ColumnCount = KeyPasteData.ZERO;

            DataNumberLabel.Text = KeyPasteData.DATA_NUMBER_PREFIX;
            PreconditionValueLabel.Text = KeyPasteData.PRECONDITION_VALUE_PREFIX;

            PreconditionTextBox.Text = KeyPasteData.BLANK;

            KeyRichTextBox.Clear();

            QueryCheckBox.Checked = false;

            TentativeHeaderCheckBox.Checked = false;

            QueryRichTextBox.Text = KeyPasteData.BLANK;

            MainDataGridView.Rows.Clear();

            this.keyPasteData.KeyCheckedList.Clear();
        }

        /// <summary>
        /// キーチェックからチェック済みのカラム名を返す
        /// </summary>
        /// <returns>カラム名</returns>
        private string ConvertColumnName()
        {
            string result = KeyPasteData.SYMBOL_ASTERISK;

            int cnt = KeyCheckedListBox.Items.Count;

            this.keyPasteData.KeyCheckedList.Clear();

            for (int i = KeyPasteData.ZERO; i < cnt; i++)
            {
                if (KeyCheckedListBox.GetItemChecked(i))
                {
                    this.keyPasteData.KeyCheckedList.Add(KeyCheckedListBox.Items[i].ToString());
                }
            }

            int num = this.keyPasteData.KeyCheckedList.Count - KeyPasteData.ONE;

            if (KeyPasteData.MINUS < num)
            {
                StringBuilder sb = new StringBuilder();
                int index = KeyPasteData.ZERO;

                for (; index < num; index++)
                {
                    sb.Append(this.keyPasteData.KeyCheckedList[index]);
                    sb.Append(KeyPasteData.COMMA);
                }

                sb.Append(this.keyPasteData.KeyCheckedList[index].ToString());

                result = sb.ToString();
            }

            return result;
        }

        /// <summary>
        /// 利用接続処理
        /// </summary>
        /// <param name="useCsv">利用CSV文字列</param>
        private void UseConnection(string useCsv)
        {
            string[] comboBoxDatas = useCsv.Split(KeyPasteData.CSV_SP, StringSplitOptions.RemoveEmptyEntries);

            int pos = KeyPasteData.ZERO;

            if (null != comboBoxDatas && KeyPasteData.USE_CONNECTION_SAVE_ITEM_NUM == comboBoxDatas.Length)
            {
                int.TryParse(comboBoxDatas[KeyPasteData.ZERO], out pos);
                DataTypeComboBox.SelectedIndex = pos;
                int.TryParse(comboBoxDatas[KeyPasteData.ONE], out pos);
                DataSourceComboBox.SelectedIndex = pos;
                int.TryParse(comboBoxDatas[KeyPasteData.TWO], out pos);
                DataNameComboBox.SelectedIndex = pos;

                if (KeyPasteData.BLANK_JUDGMENT_VALUE == comboBoxDatas[KeyPasteData.THREE])
                {
                    comboBoxDatas[KeyPasteData.THREE] = this.GetPortBlankPosition();
                }

                int.TryParse(comboBoxDatas[KeyPasteData.THREE], out pos);
                PortComboBox.SelectedIndex = pos;
                int.TryParse(comboBoxDatas[KeyPasteData.FOUR], out pos);
                UserComboBox.SelectedIndex = pos;
                int.TryParse(comboBoxDatas[KeyPasteData.FIVE], out pos);
                PasswordComboBox.SelectedIndex = pos;
            }
            else
            {
                DataTypeComboBox.SelectedIndex = pos;
                DataSourceComboBox.SelectedIndex = pos;
                DataNameComboBox.SelectedIndex = pos;
                PortComboBox.SelectedIndex = pos;
                UserComboBox.SelectedIndex = pos;
                PasswordComboBox.SelectedIndex = pos;
            }
        }

        /// <summary>
        /// 接続処理
        /// </summary>
        private void Connection()
        {
            bool isConnection = false;

            this.keyPasteData.DataType = DataTypeComboBox.Text;
            this.keyPasteData.DataSource = DataSourceComboBox.Text;
            this.keyPasteData.Catalog = DataNameComboBox.Text;
            this.keyPasteData.User = UserComboBox.Text;
            this.keyPasteData.Password = PasswordComboBox.Text;

            string port = PortComboBox.Text;

            List<string> dataList = new List<string>();

            try
            {
                switch (this.keyPasteData.DataType)
                {
                    case KeyPasteData.DATA_TYPE_SQLSERVER:
                        if (!string.IsNullOrEmpty(port))
                        {
                            keyPasteData.DataSource += KeyPasteData.COMMA + port;
                        }

                        this.keyPasteData.ConnectionString = KeyPasteData.CONNECTION_SQLSERVER_DATA_SOURCE + this.keyPasteData.DataSource + KeyPasteData.CONNECTION_SQLSERVER_CATALOG + this.keyPasteData.Catalog
                                              + KeyPasteData.CONNECTION_SQLSERVER_SECURITY + KeyPasteData.CONNECTION_SQLSERVER_USER + this.keyPasteData.User
                                              + KeyPasteData.CONNECTION_SQLSERVER_PASSWORD + this.keyPasteData.Password;

                        isConnection = this.keyPasteData.IsDataBaseConnection();

                        if (isConnection)
                        {
                            dataList = this.keyPasteData.GetTableInfo(KeyPasteData.DB_SQLSERVER_TABLE_NAME_QUERY);
                        }
                        break;
                    case KeyPasteData.DATA_TYPE_MYSQL:
                        if (!string.IsNullOrEmpty(port))
                        {
                            port = KeyPasteData.CONNECTION_MYSQL_PORT + port;
                        }

                        this.keyPasteData.ConnectionString = KeyPasteData.CONNECTION_MYSQL_DATA_SOURCE + this.keyPasteData.DataSource + KeyPasteData.CONNECTION_MYSQL_USER + this.keyPasteData.User
                                              + KeyPasteData.CONNECTION_MYSQL_PASSWORD + this.keyPasteData.Password + KeyPasteData.CONNECTION_MYSQL_SECURITY
                                              + KeyPasteData.CONNECTION_MYSQL_CATALOG + this.keyPasteData.Catalog + KeyPasteData.CONNECTION_MYSQL_SSL_MODE + port;

                        isConnection = this.keyPasteData.IsDataBaseConnection();

                        if (isConnection)
                        {
                            dataList = this.keyPasteData.GetTableInfo(KeyPasteData.DB_MYSQL_TABLE_NAME_QUERY, null, this.keyPasteData.Catalog);
                        }
                        break;
                    case KeyPasteData.DATA_TYPE_POSTGRESQL:
                        if (!string.IsNullOrEmpty(port))
                        {
                            port = KeyPasteData.CONNECTION_POSTGRESQL_PORT + port;
                        }

                        this.keyPasteData.ConnectionString = KeyPasteData.CONNECTION_POSTGRESQL_DATA_SOURCE + this.keyPasteData.DataSource + port + KeyPasteData.CONNECTION_POSTGRESQL_CATALOG
                                              + this.keyPasteData.Catalog + KeyPasteData.CONNECTION_POSTGRESQL_USER + this.keyPasteData.User
                                              + KeyPasteData.CONNECTION_POSTGRESQL_PASSWORD + this.keyPasteData.Password + KeyPasteData.CONNECTION_POSTGRESQL_SECURITY;

                        isConnection = this.keyPasteData.IsDataBaseConnection();

                        if (isConnection)
                        {
                            dataList = this.keyPasteData.GetTableInfo(KeyPasteData.DB_POSTGRESQL_TABLE_NAME_QUERY, null, this.keyPasteData.Catalog);
                        }
                        break;
                    case KeyPasteData.DATA_TYPE_ORACLE:
                        if (!string.IsNullOrEmpty(port))
                        {
                            port = KeyPasteData.CONNECTION_ORACLE_PORT + port;
                        }
                        this.keyPasteData.ConnectionString = KeyPasteData.CONNECTION_ORACLE_USER + this.keyPasteData.User + KeyPasteData.CONNECTION_ORACLE_PASSWORD
                                              + this.keyPasteData.Password + KeyPasteData.CONNECTION_ORACLE_DATA_SOURCE + this.keyPasteData.DataSource + port
                                              + KeyPasteData.CONNECTION_ORACLE_SERVICE + this.keyPasteData.Catalog;
                        isConnection = this.keyPasteData.IsDataBaseConnection();
                        if (isConnection)
                        {
                            dataList = this.keyPasteData.GetTableInfo(KeyPasteData.DB_ORACLE_TABLE_NAME_QUERY, null, this.keyPasteData.Catalog);
                        }
                        break;
                    case KeyPasteData.DATA_TYPE_EXCEL:
                        this.keyPasteData.ConnectionString = this.keyPasteData.DataSource + this.keyPasteData.Catalog;

                        this.keyPasteData.NetworkConnection();

                        isConnection = File.Exists(this.keyPasteData.ConnectionString);

                        if (isConnection)
                        {
                            dataList = this.keyPasteData.GetExcelSheetInfo();
                        }
                        break;
                    case KeyPasteData.DATA_TYPE_CSV:
                    case KeyPasteData.DATA_TYPE_TSV:
                        this.keyPasteData.ConnectionString = this.keyPasteData.DataSource + this.keyPasteData.Catalog;

                        this.keyPasteData.NetworkConnection();

                        isConnection = File.Exists(this.keyPasteData.ConnectionString);

                        if (isConnection)
                        {
                            string separator = KeyPasteData.BLANK;
                            if (KeyPasteData.DATA_TYPE_CSV == this.keyPasteData.DataType)
                            {
                                separator = KeyPasteData.COMMA;
                            }
                            else if (KeyPasteData.DATA_TYPE_TSV == this.keyPasteData.DataType)
                            {
                                separator = KeyPasteData.TAB;
                            }

                            this.dataKeyList = this.keyPasteData.GetFileHeaderInfo(TentativeHeaderCheckBox.Checked, separator);
                            this.keyPasteData.LoadDataTable(TentativeHeaderCheckBox.Checked, KeyPasteData.BLANK, separator);

                            DataKeyComboBox.Items.Clear();
                            KeyCheckedListBox.Items.Clear();

                            PreconditionTextBox.Text = KeyPasteData.BLANK;

                            foreach (string dataKey in this.dataKeyList)
                            {
                                DataKeyComboBox.Items.Add(dataKey);
                                KeyCheckedListBox.Items.Add(dataKey, true);
                            }
                        }
                        break;
                    default:
                        break;
                }

                if (isConnection)
                {
                    ConnectionLabel.ForeColor = Color.Blue;
                    ConnectionLabel.Text = KeyPasteData.CONNECTION_VIEW_OK;

                    PreconditionTextBox.Text = KeyPasteData.BLANK;

                    QueryCheckBox.Checked = false;

                    QueryRichTextBox.Text = KeyPasteData.BLANK;

                    DataComboBox.Items.Clear();
                    this.Clear();

                    if (KeyPasteData.DATA_TYPE_CSV != this.keyPasteData.DataType && KeyPasteData.DATA_TYPE_TSV != this.keyPasteData.DataType)
                    {
                        DataKeyComboBox.Items.Clear();
                        KeyCheckedListBox.Items.Clear();
                    }

                    foreach (string data in dataList)
                    {
                        DataComboBox.Items.Add(data);
                    }

                    QueryRichTextBox.Text = (string)Properties.Settings.Default[KeyPasteData.KEY_QUERY_TEXT];
                    QueryCheckBox.Checked = (bool)Properties.Settings.Default[KeyPasteData.KEY_QUERY_CHECK];
                }
                else
                {
                    ConnectionLabel.ForeColor = Color.Red;
                    ConnectionLabel.Text = KeyPasteData.CONNECTION_VIEW_NG;
                }
            }
            catch (Exception)
            {
                ConnectionLabel.ForeColor = Color.Red;
                ConnectionLabel.Text = KeyPasteData.CONNECTION_VIEW_NG;

                throw;
            }
        }

        /// <summary>
        /// 設定ファイル読み込み
        /// </summary>
        private void LoadSetting()
        {
            string csvTemp = (string)Properties.Settings.Default[KeyPasteData.KEY_DATA_TYPE];

            string[] comboBoxDatas = csvTemp.Split(KeyPasteData.CSV_SP, StringSplitOptions.RemoveEmptyEntries);

            if (null != comboBoxDatas)
            {
                DataTypeComboBox.Items.Clear();

                foreach (string text in comboBoxDatas)
                {
                    DataTypeComboBox.Items.Add(text);
                }
            }

            csvTemp = (string)Properties.Settings.Default[KeyPasteData.KEY_DATA_SOURCE];

            comboBoxDatas = csvTemp.Split(KeyPasteData.CSV_SP, StringSplitOptions.RemoveEmptyEntries);

            if (null != comboBoxDatas)
            {
                DataSourceComboBox.Items.Clear();

                foreach (string text in comboBoxDatas)
                {
                    DataSourceComboBox.Items.Add(text);
                }
            }

            csvTemp = (string)Properties.Settings.Default[KeyPasteData.KEY_DATA_NAME];

            comboBoxDatas = csvTemp.Split(KeyPasteData.CSV_SP, StringSplitOptions.RemoveEmptyEntries);

            if (null != comboBoxDatas)
            {
                DataNameComboBox.Items.Clear();

                foreach (string text in comboBoxDatas)
                {
                    DataNameComboBox.Items.Add(text);
                }
            }

            csvTemp = (string)Properties.Settings.Default[KeyPasteData.KEY_PORT];

            comboBoxDatas = csvTemp.Split(KeyPasteData.CSV_SP, StringSplitOptions.RemoveEmptyEntries);

            if (null != comboBoxDatas)
            {
                PortComboBox.Items.Clear();

                foreach (string text in comboBoxDatas)
                {
                    if (KeyPasteData.BLANK_JUDGMENT_VALUE != text)
                    {
                        PortComboBox.Items.Add(text);
                    }
                    else
                    {
                        PortComboBox.Items.Add(KeyPasteData.BLANK);
                    }
                }
            }

            csvTemp = (string)Properties.Settings.Default[KeyPasteData.KEY_USER];

            comboBoxDatas = csvTemp.Split(KeyPasteData.CSV_SP, StringSplitOptions.RemoveEmptyEntries);

            if (null != comboBoxDatas)
            {
                UserComboBox.Items.Clear();

                foreach (string text in comboBoxDatas)
                {
                    UserComboBox.Items.Add(text);
                }
            }

            csvTemp = (string)Properties.Settings.Default[KeyPasteData.KEY_PASSWORD];

            comboBoxDatas = csvTemp.Split(KeyPasteData.CSV_SP, StringSplitOptions.RemoveEmptyEntries);

            if (null != comboBoxDatas)
            {
                PasswordComboBox.Items.Clear();

                foreach (string text in comboBoxDatas)
                {
                    PasswordComboBox.Items.Add(text);
                }
            }
        }

        /// <summary>
        /// ポート番号入力制限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PortComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < char.Parse(KeyPasteData.ZERO.ToString()) || e.KeyChar > char.Parse(KeyPasteData.NINE.ToString()))
                && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
