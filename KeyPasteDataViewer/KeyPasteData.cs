using MySql.Data.MySqlClient;
using Npgsql;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static KeyPasteDataViewer.KeyPasteData;

namespace KeyPasteDataViewer
{
    /// <summary>
    /// キー貼り付けデータ
    /// </summary>
    public class KeyPasteData
    {
        /// <summary>
        /// 接続表示 OK
        /// </summary>
        public const string CONNECTION_VIEW_OK = ": OK";

        /// <summary>
        /// 接続表示 NG
        /// </summary>
        public const string CONNECTION_VIEW_NG = ": NG";

        /// <summary>
        /// 入力(選択)エラー データメッセージ
        /// </summary>
        public const string INPUT_ERROR_DATA_MESSAGE = "Please Select Data.";

        /// <summary>
        /// 入力(選択)エラー キーメッセージ
        /// </summary>
        public const string INPUT_ERROR_KEY_MESSAGE = "Please Select Key.";

        /// <summary>
        /// 入力(選択)エラー キーデータメッセージ
        /// </summary>
        public const string INPUT_ERROR_KEY_DATA_MESSAGE = "Please Select Key Data.";

        /// <summary>
        /// 読込エラー エクセル読込エラーメッセージ
        /// </summary>
        public const string INPUT_ERROR_EXCEL_MESSAGE = "Not Excel Load Data.";

        /// <summary>
        /// 出力エラー データメッセージ
        /// </summary>
        public const string OUTPUT_ERROR_DATA_MESSAGE = "Not Found Data.";

        /// <summary>
        /// 出力 完了メッセージ
        /// </summary>
        public const string OUTPUT_COMPLETED_MESSAGE = "Output complete.";

        /// <summary>
        /// データ件数表示 接頭辞
        /// </summary>
        public const string DATA_NUMBER_PREFIX = "DataNumber : ";

        /// <summary>
        /// 前提条件値表示 接頭辞
        /// </summary>
        public const string PRECONDITION_VALUE_PREFIX = "Precondition Value";

        /// <summary>
        /// 記号 アスタリスク
        /// </summary>
        public const string SYMBOL_ASTERISK = "*";

        /// <summary>
        /// 基底マスク文字列
        /// </summary>
        public const string BASE_MASK_STRING = "*****";

        /// <summary>
        /// 仮ヘッダ 接頭辞
        /// </summary>
        public const string TENTATIVE_HEADER_PREFIX = "Header";

        /// <summary>
        /// チャート X軸タイトル
        /// </summary>
        public const string CHART_X_TITLE = "X";

        /// <summary>
        /// チャート Y軸タイトル
        /// </summary>
        public const string CHART_Y_TITLE = "Y";

        /// <summary>
        /// 空白判定値
        /// </summary>
        public const string BLANK_JUDGMENT_VALUE = "-999";

        /// <summary>
        /// 数値フォーマット #,##0
        /// </summary>
        public const string COMMA_NUMBER_FORMAT = "{0:#,0}";

        /// <summary>
        /// 日時フォーマット
        /// </summary>
        public const string DATE_TIME_FORMAT = "yyyy/MM/dd HH:mm:ss";

        /// <summary>
        /// 保存ファイル名
        /// </summary>
        public const string SAVE_FILE_NAME = "save";

        /// <summary>
        /// 保存ファイルパス
        /// </summary>
        public const string SAVE_FILE_PATH = @"C:\";

        /// <summary>
        /// 保存ファイルフィルター
        /// </summary>
        public const string SAVE_FILE_FILTER = "File(*.xlsx;*.xls;*.csv;*.tsv;*.txt)|*.xlsx;*.xls;*.csv;*.tsv;*.txt|File of all(*.*)|*.*";

        /// <summary>
        /// 保存先ファイルタイトル
        /// </summary>
        public const string SAVE_FILE_TITLE = "Please select the save destination file";

        /// <summary>
        /// ファイルエンコード
        /// </summary>
        public const string FILE_ENCODE = "Shift_JIS";

        /// <summary>
        /// メッセージボックス ヘッダタイトル エラー
        /// </summary>
        public const string MESSAGE_BOX_HEADER_TITLE_ERROR = "Error";

        /// <summary>
        /// メッセージボックス ヘッダタイトル 確認
        /// </summary>
        public const string MESSAGE_BOX_HEADER_TITLE_CONFIRM = "Confirm";

        /// <summary>
        /// メッセージボックス ヘッダタイトル 完了
        /// </summary>
        public const string MESSAGE_BOX_HEADER_TITLE_COMPLETED = "Completed";

        /// <summary>
        /// DB テーブル/カラム 別名
        /// </summary>
        public const string DB_TABLE_NAME_COLUMNS_ALIAS = "name";

        /// <summary>
        /// DB スキーマ名 別名
        /// </summary>
        public const string DB_TABLE_S_NAME_COLUMNS_ALIAS = "s_name";

        /// <summary>
        /// DB SQLServer テーブル名取得クエリ
        /// </summary>
        public const string DB_SQLSERVER_TABLE_NAME_QUERY = "select name from sys.objects where type = 'U' order by name";

        /// <summary>
        /// DB SQLServer テーブルカラム名取得クエリ
        /// </summary>
        public const string DB_SQLSERVER_TABLE_COLUMNS_NAME_QUERY = "select name from sys.columns where object_id = object_id(N'dbo.{0}')";

        /// <summary>
        /// DB MySQL テーブル名取得クエリ
        /// </summary>
        public const string DB_MYSQL_TABLE_NAME_QUERY = "select table_name as name from information_schema.tables where table_schema = '{1}'";

        /// <summary>
        /// DB MySQL テーブルカラム名取得クエリ
        /// </summary>
        public const string DB_MYSQL_TABLE_COLUMNS_NAME_QUERY = "select column_name as name from information_schema.columns c"
                                                              + " where c.table_schema = '{1}' and c.table_name = '{0}' order by ordinal_position";

        /// <summary>
        /// DB POSTGRESQL テーブル名取得クエリ
        /// </summary>
        public const string DB_POSTGRESQL_TABLE_NAME_QUERY = "select table_schema as s_name, table_name as name from information_schema.tables"
                                                           + " where table_type = 'BASE TABLE' and table_schema not in ('pg_catalog', 'information_schema')";

        /// <summary>
        /// DB POSTGRESQL テーブルカラム名取得クエリ
        /// </summary>
        public const string DB_POSTGRESQL_TABLE_COLUMNS_NAME_QUERY = "select column_name as name from information_schema.columns"
                                                                   + " where table_schema = '{1}' AND table_name = '{0}' order by ordinal_position";
        /// <summary>
        /// DB ORACLE テーブル名取得クエリ
        /// </summary>
        public const string DB_ORACLE_TABLE_NAME_QUERY = "select TABLE_NAME AS name from USER_TABLES order by TABLE_NAME";

        /// <summary>
        /// DB ORACLE テーブルカラム名取得クエリ
        /// </summary>
        public const string DB_ORACLE_TABLE_COLUMNS_NAME_QUERY = "select COLUMN_NAME AS name from USER_TAB_COLUMNS"
                                                               + " where TABLE_NAME = '{0}' order by COLUMN_ID";


        /// <summary>
        /// キー 置換0
        /// </summary>
        public const string KEY_REPLACE_0 = "{0}";

        /// <summary>
        /// キー 置換1
        /// </summary>
        public const string KEY_REPLACE_1 = "{1}";

        /// <summary>
        /// キー データ種別
        /// </summary>
        public const string KEY_DATA_TYPE = "data_type";

        /// <summary>
        /// キー データソース
        /// </summary>
        public const string KEY_DATA_SOURCE = "data_source";

        /// <summary>
        /// キー データ名(テーブル名/シート名)
        /// </summary>
        public const string KEY_DATA_NAME = "data_name";

        /// <summary>
        /// キー ポート
        /// </summary>
        public const string KEY_PORT = "port";

        /// <summary>
        /// キー ユーザー
        /// </summary>
        public const string KEY_USER = "user";

        /// <summary>
        /// キー パスワード
        /// </summary>
        public const string KEY_PASSWORD = "password";

        /// <summary>
        /// キー 利用接続1
        /// </summary>
        public const string KEY_USE_CONNECTION_1 = "use_connection1";

        /// <summary>
        /// キー 利用接続2
        /// </summary>
        public const string KEY_USE_CONNECTION_2 = "use_connection2";

        /// <summary>
        /// キー 利用接続3
        /// </summary>
        public const string KEY_USE_CONNECTION_3 = "use_connection3";

        /// <summary>
        /// キー 利用接続4
        /// </summary>
        public const string KEY_USE_CONNECTION_4 = "use_connection4";

        /// <summary>
        /// キー 利用接続5
        /// </summary>
        public const string KEY_USE_CONNECTION_5 = "use_connection5";

        /// <summary>
        /// キー 利用接続名1
        /// </summary>
        public const string KEY_USE_CONNECTION_NAME_1 = "use_connection_name1";

        /// <summary>
        /// キー 利用接続名2
        /// </summary>
        public const string KEY_USE_CONNECTION_NAME_2 = "use_connection_name2";

        /// <summary>
        /// キー 利用接続名3
        /// </summary>
        public const string KEY_USE_CONNECTION_NAME_3 = "use_connection_name3";

        /// <summary>
        /// キー 利用接続名4
        /// </summary>
        public const string KEY_USE_CONNECTION_NAME_4 = "use_connection_name4";

        /// <summary>
        /// キー 利用接続名5
        /// </summary>
        public const string KEY_USE_CONNECTION_NAME_5 = "use_connection_name5";

        /// <summary>
        /// キー クエリテキスト
        /// </summary>
        public const string KEY_QUERY_TEXT = "query_text";

        /// <summary>
        /// キー クエリチェック
        /// </summary>
        public const string KEY_QUERY_CHECK = "query_check";

        /// <summary>
        /// データ種別 SQLServer
        /// </summary>
        public const string DATA_TYPE_SQLSERVER = "SQLServer";

        /// <summary>
        /// データ種別 MySQL
        /// </summary>
        public const string DATA_TYPE_MYSQL = "MySQL";

        /// <summary>
        /// データ種別 PostgreSQL
        /// </summary>
        public const string DATA_TYPE_POSTGRESQL = "PostgreSQL";

        /// <summary>
        /// データ種別 ORACLE
        /// </summary>
        public const string DATA_TYPE_ORACLE = "Oracle";

        /// <summary>
        /// データ種別 Excel
        /// </summary>
        public const string DATA_TYPE_EXCEL = "Excel";

        /// <summary>
        /// データ種別 CSV
        /// </summary>
        public const string DATA_TYPE_CSV = "CSV";

        /// <summary>
        /// データ種別 TSV
        /// </summary>
        public const string DATA_TYPE_TSV = "TSV";

        /// <summary>
        /// Excel 新拡張子
        /// </summary>
        public const string EXCEL_EXP_NEW = ".xlsx";

        /// <summary>
        /// Excel 旧拡張子
        /// </summary>
        public const string EXCEL_EXP_OLD = ".xls";

        /// <summary>
        /// CSV 拡張子
        /// </summary>
        public const string CSV_EXP = ".csv";

        /// <summary>
        /// TSV 拡張子
        /// </summary>
        public const string TSV_EXP = ".tsv";

        /// <summary>
        /// TXE 拡張子
        /// </summary>
        public const string TXT_EXP = ".txt";

        /// <summary>
        /// 接続 SQLSERVER データソース文字列
        /// </summary>
        public const string CONNECTION_SQLSERVER_DATA_SOURCE = "Data Source=";

        /// <summary>
        /// 接続 SQLSERVER カタログ文字列
        /// </summary>
        public const string CONNECTION_SQLSERVER_CATALOG = ";Initial Catalog=";

        /// <summary>
        /// 接続 SQLSERVER セキュリティ文字列
        /// </summary>
        public const string CONNECTION_SQLSERVER_SECURITY = ";Persist Security Info=True";

        /// <summary>
        /// 接続 SQLSERVER ユーザー文字列
        /// </summary>
        public const string CONNECTION_SQLSERVER_USER = ";User ID=";

        /// <summary>
        /// 接続 SQLSERVER パスワード文字列
        /// </summary>
        public const string CONNECTION_SQLSERVER_PASSWORD = ";Password=";

        /// <summary>
        /// 接続 MYSQL データソース文字列
        /// </summary>
        public const string CONNECTION_MYSQL_DATA_SOURCE = "server=";

        /// <summary>
        /// 接続 MYSQL ポート文字列
        /// </summary>
        public const string CONNECTION_MYSQL_PORT = ";port=";

        /// <summary>
        /// 接続 MYSQL カタログ文字列
        /// </summary>
        public const string CONNECTION_MYSQL_CATALOG = ";database=";

        /// <summary>
        /// 接続 MYSQL セキュリティ文字列
        /// </summary>
        public const string CONNECTION_MYSQL_SECURITY = ";persistsecurityinfo=True";

        /// <summary>
        /// 接続 MYSQL SSLモード文字列
        /// </summary>
        public const string CONNECTION_MYSQL_SSL_MODE = ";SslMode=none";

        /// <summary>
        /// 接続 MYSQL ユーザー文字列
        /// </summary>
        public const string CONNECTION_MYSQL_USER = ";user id=";

        /// <summary>
        /// 接続 MYSQL パスワード文字列
        /// </summary>
        public const string CONNECTION_MYSQL_PASSWORD = ";password=";

        /// <summary>
        /// 接続 POSTGRESQL データソース文字列
        /// </summary>
        public const string CONNECTION_POSTGRESQL_DATA_SOURCE = "server=";

        /// <summary>
        /// 接続 POSTGRESQL ポート文字列
        /// </summary>
        public const string CONNECTION_POSTGRESQL_PORT = ";port=";

        /// <summary>
        /// 接続 POSTGRESQL カタログ文字列
        /// </summary>
        public const string CONNECTION_POSTGRESQL_CATALOG = ";database=";

        /// <summary>
        /// 接続 POSTGRESQL セキュリティ文字列
        /// </summary>
        public const string CONNECTION_POSTGRESQL_SECURITY = ";Trust Server Certificate=false";

        /// <summary>
        /// 接続 POSTGRESQL SSLモード文字列
        /// </summary>
        public const string CONNECTION_POSTGRESQL_SSL_MODE = ";SSL Mode=Disable";

        /// <summary>
        /// 接続 POSTGRESQL ユーザー文字列
        /// </summary>
        public const string CONNECTION_POSTGRESQL_USER = ";user id=";

        /// <summary>
        /// 接続 POSTGRESQL パスワード文字列
        /// </summary>
        public const string CONNECTION_POSTGRESQL_PASSWORD = ";password=";

        /// <summary>
        /// 接続 ORACLE データソース文字列
        /// </summary>
        public const string CONNECTION_ORACLE_DATA_SOURCE = ";Data Source=";

        /// <summary>
        /// 接続 ORACLE ポート文字列
        /// </summary>
        public const string CONNECTION_ORACLE_PORT = ":";

        /// <summary>
        /// 接続 ORACLE サービス名文字列
        /// </summary>
        public const string CONNECTION_ORACLE_SERVICE = "/";

        /// <summary>
        /// 接続 ORACLE SSLモード文字列
        /// </summary>
        public const string CONNECTION_ORACLE_SSL_MODE = ";SSL_SERVER_DN_MATCH=true";

        /// <summary>
        /// 接続 ORACLE ユーザー文字列
        /// </summary>
        public const string CONNECTION_ORACLE_USER = "User Id=";

        /// <summary>
        /// 接続 ORACLE パスワード文字列
        /// </summary>
        public const string CONNECTION_ORACLE_PASSWORD = ";Password=";

        /// <summary>
        /// Excel 文字列フォーマット
        /// </summary>
        public const string EXCEL_STRING_FORMAT = "string";

        /// <summary>
        /// 入力 is null
        /// </summary>
        public const string INPUT_IS_NULL_LOW = "{is null}";

        /// <summary>
        /// 入力 is null
        /// </summary>
        public const string INPUT_IS_NULL_UP = "{IS NULL}";

        /// <summary>
        /// where is null
        /// </summary>
        public const string WHERE_IS_NULL = " is null";

        /// <summary>
        /// 入力 is not null
        /// </summary>
        public const string INPUT_IS_NOT_NULL_LOW = "{is not null}";

        /// <summary>
        /// 入力 is not null
        /// </summary>
        public const string INPUT_IS_NOT_NULL_UP = "{IS NOT NULL}";

        /// <summary>
        /// SQL select
        /// </summary>
        public const string SQL_SELECT = "select";

        /// <summary>
        /// SQL from
        /// </summary>
        public const string SQL_FROM = "from";

        /// <summary>
        /// SQL where
        /// </summary>
        public const string SQL_WHERE = "where";

        /// <summary>
        /// SQL where in 接頭辞
        /// </summary>
        public const string SQL_WHERE_IN_PREFIX = " in (";

        /// <summary>
        /// SQL where in 接尾辞
        /// </summary>
        public const string SQL_WHERE_IN_SUFFIX = ")";

        /// <summary>
        /// where is not null
        /// </summary>
        public const string WHERE_IS_NOT_NULL = " is not null";

        /// <summary>
        /// where句 ALL
        /// </summary>
        public const string WHERE_ALL = "1 = 1";

        /// <summary>
        /// where句 or
        /// </summary>
        public const string WHERE_OR = "Or";

        /// <summary>
        /// where句 and
        /// </summary>
        public const string WHERE_AND = "And";

        /// <summary>
        /// カンマ
        /// </summary>
        public const string COMMA = ",";

        /// <summary>
        /// 改行 \n
        /// </summary>
        public const string NEW_LINE_N = "\n";

        /// <summary>
        /// 改行 \r
        /// </summary>
        public const string NEW_LINE_R = "\r";

        /// <summary>
        /// タブ
        /// </summary>
        public const string TAB = "\t";

        /// <summary>
        /// ディレクトリ区切り
        /// </summary>
        public const string DIRECTORY_DELIMITER = "\\";

        /// <summary>
        /// ネットワークセパレーター
        /// </summary>
        public const string NETWORK_SP = DIRECTORY_DELIMITER + DIRECTORY_DELIMITER;

        /// <summary>
        /// 記号 '
        /// </summary>
        public const string SYMBOL_SINGLE_COAT = "'";

        /// <summary>
        /// 空白
        /// </summary>
        public const string BLANK = "";

        /// <summary>
        /// 半角空白
        /// </summary>
        public const string HALF_SPACE_BLANK = " ";

        /// <summary>
        /// 記号 =
        /// </summary>
        public const string SYNBOL_EQUAL = "=";

        /// <summary>
        /// -1
        /// </summary>
        public const int MINUS = -1;

        /// <summary>
        /// 0
        /// </summary>
        public const int ZERO = 0;

        /// <summary>
        /// 1
        /// </summary>
        public const int ONE = 1;

        /// <summary>
        /// 2
        /// </summary>
        public const int TWO = 2;

        /// <summary>
        /// 3
        /// </summary>
        public const int THREE = 3;

        /// <summary>
        /// 4
        /// </summary>
        public const int FOUR = 4;

        /// <summary>
        /// 5
        /// </summary>
        public const int FIVE = 5;

        /// <summary>
        /// 9
        /// </summary>
        public const int NINE = 9;

        /// <summary>
        /// 利用接続保存項目数
        /// </summary>
        public const int USE_CONNECTION_SAVE_ITEM_NUM = 6;

        /// <summary>
        /// 改行セパレーター
        /// </summary>
        public static readonly string[] NEW_LINE_SP = new string[] { NEW_LINE_N };

        /// <summary>
        /// CSVセパレーター
        /// </summary>
        public static readonly string[] CSV_SP = new string[] { COMMA };

        /// <summary>
        /// WNetAddConnection2に渡す接続詳細情報構造体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct NETRESOURCE
        {
            /// <summary>
            /// 列挙の範囲
            /// </summary>
            public int dwScope;

            /// <summary>
            /// リソースタイプ
            /// </summary>
            public int dwType;

            /// <summary>
            /// 表示オブジェクト
            /// </summary>
            public int dwDisplayType;

            /// <summary>
            /// リソースの使用方法
            /// </summary>
            public int dwUsage;

            /// <summary>
            /// ローカルデバイス名
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpLocalName;

            /// <summary>
            /// //リモートネットワーク名
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpRemoteName;

            /// <summary>
            /// ネットワーク内の提供者に提供された文字列
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpComment;

            /// <summary>
            /// リソースを所有しているプロバイダ名
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpProvider;
        }

        /// <summary>
        /// 接続情報
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// データ種別
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// データソース
        /// </summary>
        public string DataSource { get; set; }

        /// <summary>
        /// カタログ(DB名/ファイル名)
        /// </summary>
        public string Catalog { get; set; }

        /// <summary>
        /// ユーザー
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// パスワード
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// キーチェック済みリスト
        /// </summary>
        public List<string> KeyCheckedList { get; set; }

        /// <summary>
        /// データ種別 > データ名 > (テーブル / シート) > カラム辞書
        /// </summary>
        public Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>> PreconditionDictionary { get; set; }

        /// <summary>
        /// テーブル名とスキーマ名辞書
        /// </summary>
        public Dictionary<string, string> TableSchemaDictionary { get; set; }

        /// <summary>
        /// データグリッドビュー
        /// </summary>
        public DataGridView MainDataGridView { get; set; }

        /// <summary>
        /// 戻しデータグリッドビュー
        /// </summary>
        public DataGridView BackDataGridView { get; set; }

        /// <summary>
        /// データテーブル
        /// </summary>
        public DataTable DataTable { get; set; }

        /// <summary>
        /// ExcelBook
        /// </summary>
        private IWorkbook readBook;

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        public KeyPasteData()
        {
            ConnectionString = BLANK;
            DataType = BLANK;
            DataSource = BLANK;
            Catalog = BLANK;
            User = BLANK;
            Password = BLANK;

            KeyCheckedList = new List<string>();
            PreconditionDictionary = new Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>>();
            TableSchemaDictionary = new Dictionary<string, string>();
            MainDataGridView = new DataGridView();
            BackDataGridView = new DataGridView();
            DataTable = new DataTable();
        }

        /// <summary>
        /// データ戻し処理
        /// </summary>
        public void BackData()
        {
            if (null == BackDataGridView)
            {
                return;
            }

            int record = BackDataGridView.RowCount;
            int columns = BackDataGridView.ColumnCount;

            if (ONE > record || ZERO == columns)
            {
                return;
            }

            MainDataGridView.RowCount = record;
            MainDataGridView.ColumnCount = columns;

            int recordCnt = record - ONE;

            // ヘッダ
            for (int i = ZERO; i < columns; i++)
            {
                MainDataGridView.Columns[i].HeaderText = BackDataGridView.Columns[i].HeaderText;
            }

            // データ
            for (int i = ZERO; i < recordCnt; i++)
            {
                for (int j = ZERO; j < columns; j++)
                {
                    MainDataGridView[j, i].Value = BackDataGridView[j, i].Value;
                }
            }
        }

        /// <summary>
        /// データグリッドビューデータをコピーして返す
        /// プロパティ値はコピーしない
        /// </summary>
        /// <param name="baseDataGridView">データグリッドビュー</param>
        /// <returns>データグリッドビューデータのコピー</returns>
        public DataGridView CopyDataOfDataGridView(DataGridView baseDataGridView)
        {
            if (null == baseDataGridView)
            {
                return null;
            }

            int record = baseDataGridView.RowCount;
            int columns = baseDataGridView.ColumnCount;

            if (ONE > record || ZERO == columns)
            {
                return null;
            }

            DataGridView dataGridView = new DataGridView
            {
                RowCount = record,
                ColumnCount = columns
            };

            int recordCnt = record - ONE;

            // ヘッダ
            for (int i = ZERO; i < columns; i++)
            {
                dataGridView.Columns[i].HeaderText = baseDataGridView.Columns[i].HeaderText;
            }

            // データ
            for (int i = ZERO; i < recordCnt; i++)
            {
                for (int j = ZERO; j < columns; j++)
                {
                    dataGridView[j, i].Value = baseDataGridView[j, i].Value;
                }
            }

            return dataGridView;
        }

        /// <summary>
        /// マスクデータ処理
        /// </summary>
        /// <param name="checkedListBox">チェックリストボックス</param>
        /// <param name="maskString">マスク文字列</param>
        public void MaskData(CheckedListBox checkedListBox, string maskString = BASE_MASK_STRING)
        {
            List<bool> maskList = new List<bool>();

            int cnt = checkedListBox.Items.Count;

            for (int i = ZERO; i < cnt; i++)
            {
                maskList.Add(checkedListBox.GetItemChecked(i));
            }

            int rowCount = MainDataGridView.RowCount - ONE;
            int columnCount = MainDataGridView.ColumnCount;

            for (int i = ZERO; i < rowCount; i++)
            {
                for (int j = ZERO; j < columnCount; j++)
                {
                    if (maskList[j])
                    {
                        MainDataGridView[j, i].Value = maskString;
                    }
                }
            }
        }

        /// <summary>
        /// ファイル出力処理
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        public void OutPutFile(string filePath, string sheetName = BLANK)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            string exp = Path.GetExtension(filePath);

            switch (exp)
            {
                case EXCEL_EXP_NEW:
                case EXCEL_EXP_OLD:
                    this.OutPutExcelFile(filePath, sheetName);
                    break;
                case CSV_EXP:
                    this.OutPutTxtFile(filePath, COMMA);
                    break;
                case TSV_EXP:
                case TXT_EXP:
                    this.OutPutTxtFile(filePath, TAB);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// ネットワーク接続処理
        /// </summary>
        public void NetworkConnection()
        {
            if (!string.IsNullOrEmpty(User) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(DataSource))
            {
                string[] dataSources = DataSource.Split(new string[] { DIRECTORY_DELIMITER }, StringSplitOptions.RemoveEmptyEntries);

                string shareName = NETWORK_SP + dataSources[ZERO];

                // 接続情報設定 
                NETRESOURCE netResource = new NETRESOURCE
                {
                    dwScope = ZERO,
                    dwType = ONE,
                    dwDisplayType = ZERO,
                    dwUsage = ZERO,
                    lpLocalName = BLANK,
                    lpRemoteName = shareName
                };

                netResource.lpLocalName = BLANK;
                netResource.lpProvider = BLANK;

                KeyPasteDataNativeMethods.WNetCancelConnection2(shareName, ZERO, true);
                KeyPasteDataNativeMethods.WNetAddConnection2(ref netResource, Password, User, ZERO);
            }
        }

        /// <summary>
        /// 新規データ追加区切り文字列を返す
        /// </summary>
        /// <param name="dataList">データリスト</param>
        /// <param name="newData">新規データ</param>
        /// <returns>新規データ追加区切り文字列</returns>
        private string GetSeparatorString(List<string> dataList, string newData)
        {
            StringBuilder sb = new StringBuilder();

            int cnt = dataList.Count - ONE;

            if (ZERO <= cnt)
            {
                for (int i = ZERO; i < cnt; i++)
                {
                    sb.Append(dataList[i]);
                    sb.Append(COMMA);
                }

                sb.Append(dataList[cnt]);
            }

            if (!dataList.Contains(newData) && !string.IsNullOrEmpty(newData))
            {
                if (ZERO < dataList.Count)
                {
                    sb.Append(COMMA);
                }

                sb.Append(newData);
            }

            return sb.ToString();
        }

        /// <summary>
        /// CSV情報を返す
        /// </summary>
        /// <param name="dataList">データリスト</param>
        /// <param name="newData">新規データ</param>
        /// <returns>CSV情報</returns>
        public string GetDataCSV(List<string> dataList, string newData)
        {
            return GetSeparatorString(dataList, newData);
        }

        /// <summary>
        /// ポートのCSV情報を返す
        /// </summary>
        /// <param name="dataList">データリスト</param>
        /// <param name="newData">新規データ</param>
        /// <returns>ポートのCSV情報</returns>
        public string GetPortCSV(List<string> dataList, string newData)
        {
            StringBuilder sb = new StringBuilder();

            int cnt = dataList.Count - ONE;

            if (ZERO <= cnt)
            {
                for (int i = ZERO; i < cnt; i++)
                {
                    if (!string.IsNullOrEmpty(dataList[i]))
                    {
                        sb.Append(dataList[i]);
                    }
                    else
                    {
                        sb.Append(BLANK_JUDGMENT_VALUE);
                    }
                    sb.Append(COMMA);
                }

                sb.Append(dataList[cnt]);
            }

            if (!dataList.Contains(newData) && !string.IsNullOrEmpty(newData))
            {
                if (ZERO < dataList.Count)
                {
                    sb.Append(COMMA);
                }

                sb.Append(newData);
            }

            return sb.ToString();
        }

        /// <summary>
        /// データテーブルをロード
        /// <param name="tentativeHeaderCheck">仮ヘッダチェック</param>
        /// <param name="separator">セパレータ</param>
        /// <param name="sheetName">シート名</param>
        /// </summary>
        public void LoadDataTable(bool tentativeHeaderCheck, string sheetName = BLANK, string separator = BLANK)
        {
            List<string> columnsList = new List<string>();

            int record;
            int cnt;
            int start;
            string columnName;

            switch (DataType)
            {
                case DATA_TYPE_EXCEL:
                    DataTable = new DataTable(sheetName);

                    if (null == this.readBook)
                    {
                        this.LoadExcelBook();
                    }

                    ISheet sheet = this.readBook.GetSheet(sheetName);

                    if (null == sheet)
                    {
                        return;
                    }

                    record = sheet.LastRowNum;

                    if (ONE > record)
                    {
                        return;
                    }

                    IRow row = sheet.GetRow(ZERO);

                    if (null == row)
                    {
                        MessageBox.Show(INPUT_ERROR_EXCEL_MESSAGE, MESSAGE_BOX_HEADER_TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    cnt = row.LastCellNum;

                    if (tentativeHeaderCheck)
                    {
                        for (int i = ZERO; i < cnt; i++)
                        {
                            columnName = TENTATIVE_HEADER_PREFIX + (i + ONE);

                            DataTable.Columns.Add(columnName);
                            columnsList.Add(columnName);
                        }

                        start = ZERO;
                    }
                    else
                    {
                        for (int i = ZERO; i < cnt; i++)
                        {
                            columnName = this.GetStringFromCell(row.GetCell(i));

                            DataTable.Columns.Add(columnName);
                            columnsList.Add(columnName);
                        }

                        start = ONE;
                    }

                    for (int i = start; i < record; i++)
                    {
                        row = sheet.GetRow(i);

                        if (null == row)
                        {
                            continue;
                        }

                        cnt = row.LastCellNum;

                        DataRow dataRow = DataTable.NewRow();

                        for (int j = ZERO; j < cnt; j++)
                        {
                            columnName = columnsList[j];
                            string data = this.GetStringFromCell(row.GetCell(j));

                            dataRow[columnName] = data;
                        }

                        DataTable.Rows.Add(dataRow);
                    }
                    break;
                case DATA_TYPE_CSV:
                case DATA_TYPE_TSV:
                    List<string> resultList = new List<string>();
                    string line = BLANK;

                    using (StreamReader sr = new StreamReader(ConnectionString, Encoding.GetEncoding(FILE_ENCODE)))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            resultList.Add(line);
                        }
                    }

                    record = resultList.Count;

                    if (ONE > record)
                    {
                        return;
                    }

                    DataTable = new DataTable(sheetName);

                    string[] datas = resultList[ZERO].Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);

                    cnt = datas.Length;


                    if (tentativeHeaderCheck)
                    {
                        for (int i = ZERO; i < cnt; i++)
                        {
                            columnName = TENTATIVE_HEADER_PREFIX + (i + ONE);

                            DataTable.Columns.Add(columnName);
                            columnsList.Add(columnName);
                        }

                        start = ZERO;
                    }
                    else
                    {
                        for (int i = ZERO; i < cnt; i++)
                        {
                            columnName = datas[i];

                            DataTable.Columns.Add(columnName);
                            columnsList.Add(columnName);
                        }

                        start = ONE;
                    }

                    int k = ZERO;

                    for (int i = start; i < record; i++)
                    {
                        datas = resultList[i].Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);

                        DataRow dataRow = DataTable.NewRow();

                        foreach (string text in datas)
                        {
                            columnName = columnsList[k];

                            dataRow[columnName] = text;

                            k++;
                        }

                        DataTable.Rows.Add(dataRow);
                        k = ZERO;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// ファイルヘッダー情報を返す
        /// </summary>
        /// <param name="tentativeHeaderCheck">仮ヘッダチェック</param>
        /// <param name="separator">セパレータ</param>
        /// <returns>ファイルヘッダー情報</returns>
        public List<string> GetFileHeaderInfo(bool tentativeHeaderCheck, string separator)
        {
            List<string> resultList = new List<string>();
            List<string> lineList = new List<string>();

            string line = BLANK;

            using (StreamReader sr = new StreamReader(ConnectionString, Encoding.GetEncoding(FILE_ENCODE)))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    lineList.Add(line);
                }
            }

            int record = lineList.Count;

            if (ONE > record)
            {
                return resultList;
            }

            string[] datas = lineList[ZERO].Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);

            int cnt = datas.Length;

            if (tentativeHeaderCheck)
            {
                for (int i = ZERO; i < cnt; i++)
                {
                    resultList.Add(TENTATIVE_HEADER_PREFIX + (i + ONE));
                }
            }
            else
            {
                for (int i = ZERO; i < cnt; i++)
                {
                    resultList.Add(datas[i]);
                }
            }

            return resultList;
        }

        /// <summary>
        /// エクセル指定シートヘッダ情報を返す
        /// </summary>
        /// <param name="tentativeHeaderCheck">仮ヘッダチェック</param>
        /// <param name="sheetName">シート名</param>
        /// <returns>エクセル指定シートヘッダ情報</returns>
        public List<string> GetExcelHeaderInfo(bool tentativeHeaderCheck, string sheetName)
        {
            List<string> resultList = new List<string>();

            try
            {
                if (null == this.readBook)
                {
                    this.LoadExcelBook();
                }

                ISheet sheet = this.readBook.GetSheet(sheetName);

                if (null == sheet)
                {
                    return resultList;
                }

                IRow row = sheet.GetRow(ZERO);

                if (null == row)
                {
                    return resultList;
                }

                int cnt = row.LastCellNum;

                if (tentativeHeaderCheck)
                {
                    for (int i = ZERO; i < cnt; i++)
                    {
                        resultList.Add(TENTATIVE_HEADER_PREFIX + (i + ONE));
                    }
                }
                else
                {
                    for (int i = ZERO; i < cnt; i++)
                    {
                        resultList.Add(this.GetStringFromCell(row.GetCell(i)));
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.readBook.Close();
                this.readBook = null;
            }

            return resultList;
        }

        /// <summary>
        /// 前提条件を返す
        /// </summary>
        /// <param name="data">前提条件値</param>
        /// <param name="andOr">and or</param>
        /// <returns>前提条件</returns>
        public string GetPrecondition(string data, string andOr)
        {
            StringBuilder sb = new StringBuilder();

            if (PreconditionDictionary.ContainsKey(DataType)
                && PreconditionDictionary[DataType].ContainsKey(Catalog)
                && PreconditionDictionary[DataType][Catalog].ContainsKey(data))
            {
                foreach (KeyValuePair<string, string> keyValue in PreconditionDictionary[DataType][Catalog][data])
                {
                    if (string.IsNullOrEmpty(keyValue.Key))
                    {
                        continue;
                    }

                    sb.Append(keyValue.Key);

                    string value = keyValue.Value;

                    if (INPUT_IS_NULL_LOW == keyValue.Value || INPUT_IS_NULL_UP == keyValue.Value)
                    {
                        value = WHERE_IS_NULL;
                    }
                    else if (INPUT_IS_NOT_NULL_LOW == keyValue.Value || INPUT_IS_NOT_NULL_UP == keyValue.Value)
                    {
                        value = WHERE_IS_NOT_NULL;
                    }
                    else
                    {
                        sb.Append(HALF_SPACE_BLANK);
                        sb.Append(SYNBOL_EQUAL);
                        sb.Append(HALF_SPACE_BLANK);
                        sb.Append(SYMBOL_SINGLE_COAT);
                    }

                    sb.Append(value);

                    if (INPUT_IS_NULL_LOW != keyValue.Value && INPUT_IS_NULL_UP != keyValue.Value
                        && INPUT_IS_NOT_NULL_LOW != keyValue.Value && INPUT_IS_NOT_NULL_UP != keyValue.Value)
                    {
                        sb.Append(SYMBOL_SINGLE_COAT);
                    }

                    sb.Append(HALF_SPACE_BLANK);
                    sb.Append(andOr);
                    sb.Append(HALF_SPACE_BLANK);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// データテーブルをデータグリッドビューに設定して返す
        /// </summary>
        /// <param name="dataTable">データテーブル</param>
        /// <returns>データグリッドビュー</returns>
        public void ConvertDataGridView(DataTable dataTable)
        {
            if (null == dataTable || ZERO == dataTable.Rows.Count)
            {
                int check = MainDataGridView.Columns.Count;

                if (ZERO == check)
                {
                    return;
                }

                int cnt = KeyCheckedList.Count;

                for (int i = ZERO; i < cnt; i++)
                {
                    MainDataGridView.Columns[i].HeaderText = BLANK;
                }

                MainDataGridView.Rows.Clear();

                return;
            }

            int rowCount = dataTable.Rows.Count;
            int columnCount = KeyCheckedList.Count;

            MainDataGridView.Rows.Clear();
            MainDataGridView.RowCount = rowCount + ONE;
            MainDataGridView.ColumnCount = columnCount;

            int c = ZERO;
            int r = ZERO;

            // ヘッダ設定
            foreach (string column in KeyCheckedList)
            {
                MainDataGridView.Columns[c].HeaderText = column;

                c++;
            }

            c = ZERO;

            // データ設定
            for (int i = ZERO; i < rowCount; i++)
            {
                DataRowCollection dataRow = dataTable.Rows;

                foreach (string column in KeyCheckedList)
                {
                    MainDataGridView[c, r].Value = dataRow[i][column].ToString();

                    c++;
                }

                c = ZERO;
                r++;
            }
        }

        /// <summary>
        /// IN文字列形式を返す
        /// </summary>
        /// <param name="list">リスト</param>
        /// <returns>IN文字列</returns>
        public string GetInValue(string[] list)
        {
            if (null == list || ZERO == list.Length)
            {
                return BLANK;
            }

            StringBuilder sb = new StringBuilder();
            int num = list.Length - ONE;
            int index = ZERO;

            for (; index < num; index++)
            {
                sb.Append(SYMBOL_SINGLE_COAT);
                sb.Append(list[index]);
                sb.Append(SYMBOL_SINGLE_COAT);
                sb.Append(COMMA);
            }

            sb.Append(SYMBOL_SINGLE_COAT);
            sb.Append(list[index].ToString());
            sb.Append(SYMBOL_SINGLE_COAT);

            return sb.ToString();
        }

        /// <summary>
        /// 空白、改行コードを削除して返す
        /// </summary>
        /// <param name="datas">文字列配列</param>
        /// <returns>空白、改行コードを削除した文字列配列</returns>
        public string[] RemoveBlankAndNewLineData(string[] datas)
        {
            List<string> resultList = new List<string>();

            foreach (string data in datas)
            {
                if (BLANK != data)
                {
                    string temp = data.Replace(NEW_LINE_R, BLANK).Replace(NEW_LINE_N, BLANK);

                    resultList.Add(temp);
                }
            }

            return resultList.ToArray();
        }

        /// <summary>
        /// クエリに対するデータテーブルを返す
        /// </summary>
        /// <param name="query">クエリ</param>
        /// <returns>データテーブル</returns>
        public DataTable GetDataTableFromQuery(string query)
        {
            DataTable table = new DataTable();

            switch (DataType)
            {
                case DATA_TYPE_SQLSERVER:
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        try
                        {
                            // データベース接続開始
                            connection.Open();

                            // SQL設定
                            command.CommandText = @query;

                            // SQL実行
                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            adapter.Fill(table);
                        }
                        catch (SqlException)
                        {
                            throw;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    break;
                case DATA_TYPE_MYSQL:
                    using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                    {
                        try
                        {
                            // データベース接続開始
                            connection.Open();

                            // SQL実行
                            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                            adapter.Fill(table);
                        }
                        catch (SqlException)
                        {
                            throw;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    break;
                case DATA_TYPE_POSTGRESQL:
                    using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                    {
                        try
                        {
                            // データベース接続開始
                            connection.Open();

                            // SQL実行
                            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                            adapter.Fill(table);
                        }
                        catch (SqlException)
                        {
                            throw;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    break;
                case DATA_TYPE_ORACLE:
                    using (OracleConnection connection = new OracleConnection(ConnectionString))
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        try
                        {
                            // データベース接続開始
                            connection.Open();
                            // SQL設定
                            command.CommandText = @query;
                            // SQL実行
                            OracleDataAdapter adapter = new OracleDataAdapter(command);
                            adapter.Fill(table);
                        }
                        catch (SqlException)
                        {
                            throw;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    break;
                default:
                    break;
            }

            return table;
        }

        /// <summary>
        /// エクセルシート情報を返す
        /// </summary>
        /// <returns>エクセルシート情報</returns>
        public List<string> GetExcelSheetInfo()
        {
            List<string> resultList = new List<string>();

            try
            {
                if (null == this.readBook)
                {
                    this.LoadExcelBook();
                }

                int cnt = this.readBook.NumberOfSheets;

                for (int i = ZERO; i < cnt; i++)
                {
                    resultList.Add(this.readBook.GetSheetAt(i).SheetName);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.readBook.Close();
                this.readBook = null;
            }

            return resultList;
        }


        /// <summary>
        /// テーブル情報を返す
        /// </summary>
        /// <param name="query">クエリ</param>
        /// <param name="tableName">テーブル名</param>
        /// <param name="dbName">DB名</param>
        /// <returns>テーブル情報リスト</returns>
        public List<string> GetTableInfo(string query, string tableName = BLANK, string dbName = BLANK)
        {
            List<string> infoList = new List<string>();

            try
            {
                if (!string.IsNullOrEmpty(tableName))
                {
                    query = query.Replace(KEY_REPLACE_0, tableName);
                }

                if (!string.IsNullOrEmpty(dbName))
                {
                    query = query.Replace(KEY_REPLACE_1, dbName);
                }
                else
                {
                    if (TableSchemaDictionary.ContainsKey(tableName))
                    {
                        query = query.Replace(KEY_REPLACE_1, TableSchemaDictionary[tableName]);
                    }
                }

                    DataTable dataTable = this.GetDataTableFromQuery(query);
                int record = dataTable.Rows.Count;

                for (int i = ZERO; i < record; i++)
                {
                    DataRowCollection dataRow = dataTable.Rows;

                    if (dataTable.Columns.Contains(DB_TABLE_S_NAME_COLUMNS_ALIAS) && dataRow[i][DB_TABLE_S_NAME_COLUMNS_ALIAS] != null)
                    {
                        if (!TableSchemaDictionary.ContainsKey(dataRow[i][DB_TABLE_NAME_COLUMNS_ALIAS].ToString()))
                        {
                            TableSchemaDictionary.Add(dataRow[i][DB_TABLE_NAME_COLUMNS_ALIAS].ToString(), dataRow[i][DB_TABLE_S_NAME_COLUMNS_ALIAS].ToString());
                        }
                        else
                        {
                            TableSchemaDictionary[dataRow[i][DB_TABLE_NAME_COLUMNS_ALIAS].ToString()] = dataRow[i][DB_TABLE_S_NAME_COLUMNS_ALIAS].ToString();
                        }
                    }

                    infoList.Add(dataRow[i][DB_TABLE_NAME_COLUMNS_ALIAS].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return infoList;
        }

        /// <summary>
        /// データベース接続確認
        /// </summary>
        /// <returns>結果</returns>
        public bool IsDataBaseConnection()
        {
            bool isDataBaseConnection = false;

            switch (DataType)
            {
                case DATA_TYPE_SQLSERVER:
                    using (SqlConnection connection = new SqlConnection(ConnectionString))
                    {
                        try
                        {
                            // データベース接続開始
                            connection.Open();

                            if (ConnectionState.Open == connection.State)
                            {
                                isDataBaseConnection = true;
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    break;
                case DATA_TYPE_MYSQL:
                    using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                    {
                        try
                        {
                            // データベース接続開始
                            connection.Open();

                            if (ConnectionState.Open == connection.State)
                            {
                                isDataBaseConnection = true;
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    break;
                case DATA_TYPE_POSTGRESQL:
                    using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                    {
                        try
                        {
                            // データベース接続開始
                            connection.Open();
                            if (ConnectionState.Open == connection.State)
                            {
                                isDataBaseConnection = true;
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    break;
                case DATA_TYPE_ORACLE:
                    using (OracleConnection connection = new OracleConnection(ConnectionString))
                    {
                        try
                        {
                            // データベース接続開始
                            connection.Open();
                            if (ConnectionState.Open == connection.State)
                            {
                                isDataBaseConnection = true;
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    break;
                default:
                    break;
            }

            return isDataBaseConnection;
        }

        /// <summary>
        /// バージョンを返す
        /// </summary>
        /// <returns>バージョン</returns>
        public static Version GetVersion()
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();

            return asm.GetName().Version;
        }

        /// <summary>
        /// エクセルファイル出力
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="sheetName">シート名</param>
        private void OutPutExcelFile(string filePath, string sheetName)
        {
            int[] sheetPos = new int[] { ZERO };

            string[] sheetNames = new string[] { sheetName };
            int record = MainDataGridView.RowCount;
            int columns = MainDataGridView.ColumnCount;

            if (ONE > record || ZERO == columns)
            {
                MessageBox.Show(OUTPUT_ERROR_DATA_MESSAGE, MESSAGE_BOX_HEADER_TITLE_CONFIRM,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            int recordCnt = record - ONE;
            int cnt = ZERO;

            string[] dataS = new string[columns];
            string[][] dataSS = new string[record][];
            string[][][] dataSSS = new string[ONE][][];

            // ヘッダ
            for (int i = ZERO; i < columns; i++)
            {
                dataS[i] = MainDataGridView.Columns[i].HeaderText;
            }

            dataSS[cnt] = dataS;
            cnt++;

            // データ
            for (int i = ZERO; i < recordCnt; i++)
            {
                dataS = new string[columns];

                for (int j = ZERO; j < columns; j++)
                {
                    if (null != MainDataGridView[j, i].Value)
                    {
                        dataS[j] = MainDataGridView[j, i].Value.ToString();
                    }
                    else
                    {
                        dataS[j] = BLANK;
                    }
                }

                dataSS[cnt] = dataS;
                cnt++;
            }

            dataSSS[ZERO] = dataSS;

            this.OutPutExcelFile(filePath, sheetPos, sheetNames, dataSSS);
        }

        /// <summary>
        /// エクセルファイル出力
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="sheetPos">シート位置</param>
        /// <param name="sheetName">シート名</param>
        /// <param name="data">セルデータ</param>
        /// <param name="format">セル形式</param>
        private void OutPutExcelFile(string filePath, int[] sheetPos, string[] sheetName, string[][][] data, string[] format = null)
        {
            IWorkbook book = null;
            ISheet[] sheet;

            try
            {
                string extension = Path.GetExtension(filePath);

                if (EXCEL_EXP_OLD == extension)
                {
                    book = new HSSFWorkbook();
                }
                else if (EXCEL_EXP_NEW == extension)
                {
                    book = new XSSFWorkbook();
                }

                int sheetCnt = sheetPos.Length;
                int line = ZERO;
                int cnt = ZERO;
                int cell = ZERO;

                sheet = new ISheet[sheetCnt];

                for (int i = ZERO; i < sheetCnt; i++)
                {
                    book.CreateSheet(sheetName[i]);

                    sheet[i] = book.GetSheetAt(sheetPos[i]);

                    line = data[i].Length;

                    // 形式確認
                    if (null == format)
                    {
                        // 標準設定(各列毎)
                        cnt = data[i][ZERO].Length;
                        format = new string[cnt];

                        // 全て文字列型
                        for (int j = ZERO; j < cnt; j++)
                        {
                            format[j] = EXCEL_STRING_FORMAT;
                        }
                    }

                    // ヘッダは文字列で出力
                    for (int k = ZERO; k < ONE; k++)
                    {
                        cell = data[i][k].Length;

                        // セルに設定
                        for (int l = ZERO; l < cell; l++)
                        {
                            if (null != (data[i][k][l]))
                            {
                                this.WriteCell(sheet[i], l, k, (data[i][k][l]).ToString());
                            }
                            else
                            {
                                this.WriteCell(sheet[i], l, k, BLANK);
                            }
                        }
                    }

                    for (int k = ONE; k < line; k++)
                    {
                        cell = data[i][k].Length;

                        // セルに設定
                        for (int l = ZERO; l < cell; l++)
                        {
                            switch (format[l])
                            {
                                case EXCEL_STRING_FORMAT:
                                    if (null != (data[i][k][l]))
                                    {
                                        this.WriteCell(sheet[i], l, k, (data[i][k][l]).ToString());
                                    }
                                    else
                                    {
                                        this.WriteCell(sheet[i], l, k, BLANK);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

                // ブック保存
                using (FileStream fs = new FileStream(@filePath, FileMode.Create))
                {
                    book.Write(fs);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                book?.Close();
            }
        }

        /// <summary>
        /// ファイル出力処理
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="sp">区切り</param>
        private void OutPutTxtFile(string filePath, string sp)
        {
            int record = MainDataGridView.RowCount - ONE;
            int columns = MainDataGridView.ColumnCount;

            if (ONE > record || ZERO == columns)
            {
                MessageBox.Show(OUTPUT_ERROR_DATA_MESSAGE, MESSAGE_BOX_HEADER_TITLE_CONFIRM,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.GetEncoding(FILE_ENCODE)))
            {
                string data = BLANK;

                int cnt = columns - ONE;

                // ヘッダ
                for (int i = ZERO; i < cnt; i++)
                {
                    data = MainDataGridView.Columns[i].HeaderText;
                    sw.Write(data);
                    sw.Write(sp);
                }

                data = this.MainDataGridView.Columns[cnt].HeaderText;
                sw.Write(data);
                sw.Write(System.Environment.NewLine);

                // データ
                for (int i = ZERO; i < record; i++)
                {
                    for (int j = ZERO; j < cnt; j++)
                    {
                        if (null != MainDataGridView[j, i].Value)
                        {
                            data = MainDataGridView[j, i].Value.ToString();
                        }
                        else
                        {
                            data = BLANK;
                        }

                        sw.Write(data);
                        sw.Write(sp);
                    }

                    if (null != MainDataGridView[cnt, i].Value)
                    {
                        data = MainDataGridView[cnt, i].Value.ToString();
                    }
                    else
                    {
                        data = BLANK;
                    }

                    sw.Write(data);
                    sw.Write(System.Environment.NewLine);
                }
            }
        }

        /// <summary>
        /// セル設定(文字列用)
        /// </summary>
        /// <param name="sheet">シート</param>
        /// <param name="columnIndex">カラム指標</param>
        /// <param name="rowIndex">列指標</param>
        /// <param name="value">セル値</param>
        private void WriteCell(ISheet sheet, int columnIndex, int rowIndex, string value)
        {
            IRow row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            ICell cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

            cell.SetCellValue(value);
        }

        /// <summary>
        /// セル内データを文字列型で取得
        /// </summary>
        /// <param name="cell">セル</param>
        /// <returns>セルデータ文字列型</returns>
        private string GetStringFromCell(ICell cell)
        {
            string value = BLANK;

            if (null == cell)
            {
                return value;
            }

            switch (cell.CellType)
            {
                // 文字列型
                case CellType.String:
                    value = cell.StringCellValue;
                    break;
                // 数値型/日付型
                case CellType.Numeric:
                    if (DateUtil.IsCellDateFormatted(cell))
                    {
                        value = cell.DateCellValue?.ToString(DATE_TIME_FORMAT) ?? BLANK;
                    }
                    else
                    {
                        value = cell.NumericCellValue.ToString();
                    }
                    break;
                // bool型
                case CellType.Boolean:
                    value = cell.BooleanCellValue.ToString();
                    break;
                // 入力なし
                case CellType.Blank:
                    value = cell.ToString();
                    break;
                // 数式
                case CellType.Formula:
                    value = cell.CellFormula.ToString();
                    break;
                // エラー
                case CellType.Error:
                    value = cell.ErrorCellValue.ToString();
                    break;
                // 型不明なセル
                case CellType.Unknown:
                    break;
                default:
                    break;
            }

            return value;
        }

        /// <summary>
        /// エクセルブックをロード
        /// </summary>
        private void LoadExcelBook()
        {
            try
            {
                if (null != this.readBook)
                {
                    this.readBook.Close();
                    this.readBook = null;
                }

                using (FileStream fs = File.OpenRead(ConnectionString))
                {
                    this.readBook = WorkbookFactory.Create(fs);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// NativeMethods
    /// </summary>
    internal static class KeyPasteDataNativeMethods
    {
        /// <summary>
        /// 接続切断するWin32API
        /// </summary>
        [DllImport("mpr.dll", EntryPoint = "WNetCancelConnection2", CharSet = CharSet.Unicode)]
        internal static extern int WNetCancelConnection2(string lpName, Int32 dwFlags, bool fForce);

        /// <summary>
        /// 認証情報を使って接続するWin32API
        /// </summary>
        [DllImport("mpr.dll", EntryPoint = "WNetAddConnection2", CharSet = CharSet.Unicode)]
        internal static extern int WNetAddConnection2(ref NETRESOURCE lpNetResource, string lpPassword, string lpUsername, Int32 dwFlags);
    }
}
