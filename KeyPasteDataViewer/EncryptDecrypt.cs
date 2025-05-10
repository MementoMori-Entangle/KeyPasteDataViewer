using System;
using System.Windows.Forms;

namespace KeyPasteDataViewer
{
    /// <summary>
    /// 暗号・復号
    /// </summary>
    public partial class EncryptDecrypt : Form
    {
        /// <summary>
        /// 種別 AES
        /// </summary>
        public const int TYPE_AES = 0;

        /// <summary>
        /// 種別 RSA
        /// </summary>
        public const int TYPE_RSA = 1;

        /// <summary>
        /// キー AES IV
        /// </summary>
        public const string KEY_AES_IV = "aes_iv";

        /// <summary>
        /// キー AES キー
        /// </summary>
        public const string KEY_AES_KEY = "aes_key";

        /// <summary>
        /// キー AES キーサイズ
        /// </summary>
        public const string KEY_AES_KEY_SIZE = "aes_key_size";

        /// <summary>
        /// キー AES ブロックサイズ
        /// </summary>
        public const string KEY_AES_BLOCK_SIZE = "aes_block_size";

        /// <summary>
        /// キー AES モード
        /// </summary>
        public const string KEY_AES_MODE = "aes_mode";

        /// <summary>
        /// キー RSA キーサイズ
        /// </summary>
        public const string KEY_RSA_KEY_SIZE = "rsa_key_size";

        /// <summary>
        /// キー RSA 秘密キー
        /// </summary>
        public const string KEY_RSA_PRIVATE_KEY = "rsa_private_key";

        /// <summary>
        /// キー RSA 公開キー
        /// </summary>
        public const string KEY_RSA_PUBLIC_KEY = "rsa_public_key";

        /// <summary>
        /// キー 暗号種別
        /// </summary>
        public const string KEY_ENCRYPT_TYPE = "encrypt_type";

        /// <summary>
        /// AES IV
        /// </summary>
        public string IvAES { get; set; }

        /// <summary>
        /// AES KEY
        /// </summary>
        public string KeyAES { get; set; }

        /// <summary>
        /// AES Key Size
        /// </summary>
        public int KeySizeAES { get; set; }

        /// <summary>
        /// AES Block Size
        /// </summary>
        public int BlockSizeAES { get; set; }

        /// <summary>
        /// AES Mode
        /// </summary>
        public string ModeAES { get; set; }

        /// <summary>
        /// RSA Key Size
        /// </summary>
        public int KeySizeRSA { get; set; }

        /// <summary>
        /// 秘密鍵
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        /// 公開鍵
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// 暗号種別
        /// </summary>
        public int EncryptType { get; set; }

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        public EncryptDecrypt()
        {
            InitializeComponent();

            this.LoadSettings();
        }

        /// <summary>
        /// クリアボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            AESIVTextBox.Text = string.Empty;
            AESKeyTextBox.Text = string.Empty;
            AESKeySizeComboBox.SelectedIndex = -1;
            AESBlockSizeComboBox.SelectedIndex = -1;
            AESModeComboBox.SelectedIndex = -1;
            RSAKeySizeComboBox.SelectedIndex = -1;
            PrivateKeyRichTextBox.Text = string.Empty;
            PublicKeyRichTextBox.Text = string.Empty;
            AESRadioButton.Checked = true;
            RSARadioButton.Checked = false;
        }

        /// <summary>
        /// 保存ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            IvAES = AESIVTextBox.Text;
            KeyAES = AESKeyTextBox.Text;
            ModeAES = AESModeComboBox.Text;
            PrivateKey = PrivateKeyRichTextBox.Text;
            PublicKey = PublicKeyRichTextBox.Text;

            int encryptType = 0;

            int.TryParse(AESKeySizeComboBox.Text, out int size);
            KeySizeAES = size;
            int.TryParse(AESBlockSizeComboBox.Text, out size);
            BlockSizeAES = size;
            int.TryParse(RSAKeySizeComboBox.Text, out size);
            KeySizeRSA = size;

            if (AESRadioButton.Checked)
            {
                encryptType = TYPE_AES;
            }
            else if (RSARadioButton.Checked)
            {
                encryptType = TYPE_RSA;
            }

            Properties.Settings.Default[KEY_AES_IV] = AESIVTextBox.Text;
            Properties.Settings.Default[KEY_AES_KEY] = AESKeyTextBox.Text;
            Properties.Settings.Default[KEY_AES_MODE] = AESModeComboBox.Text;
            Properties.Settings.Default[KEY_RSA_PRIVATE_KEY] = PrivateKeyRichTextBox.Text;
            Properties.Settings.Default[KEY_RSA_PUBLIC_KEY] = PublicKeyRichTextBox.Text;

            int.TryParse(AESKeySizeComboBox.Text, out size);
            Properties.Settings.Default[KEY_AES_KEY_SIZE] = size;
            int.TryParse(AESBlockSizeComboBox.Text, out size);
            Properties.Settings.Default[KEY_AES_BLOCK_SIZE] = size;
            int.TryParse(RSAKeySizeComboBox.Text, out size);
            Properties.Settings.Default[KEY_RSA_KEY_SIZE] = size;
            Properties.Settings.Default[KEY_ENCRYPT_TYPE] = encryptType;

            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// 閉じるボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 再読み込みボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reloadbutton_Click(object sender, EventArgs e)
        {
            this.LoadSettings();
        }

        /// <summary>
        /// 設定情報ロード
        /// </summary>
        private void LoadSettings()
        {
            AESIVTextBox.Text = (string)Properties.Settings.Default[KEY_AES_IV];
            AESKeyTextBox.Text = (string)Properties.Settings.Default[KEY_AES_KEY];
            AESKeySizeComboBox.Text = Properties.Settings.Default[KEY_AES_KEY_SIZE].ToString();
            AESBlockSizeComboBox.Text = Properties.Settings.Default[KEY_AES_BLOCK_SIZE].ToString();
            AESModeComboBox.Text = (string)Properties.Settings.Default[KEY_AES_MODE];
            RSAKeySizeComboBox.Text = Properties.Settings.Default[KEY_RSA_KEY_SIZE].ToString();
            PrivateKeyRichTextBox.Text = (string)Properties.Settings.Default[KEY_RSA_PRIVATE_KEY];
            PublicKeyRichTextBox.Text = (string)Properties.Settings.Default[KEY_RSA_PUBLIC_KEY];

            IvAES = AESIVTextBox.Text;
            KeyAES = AESKeyTextBox.Text;
            ModeAES = AESModeComboBox.Text;
            PrivateKey = PrivateKeyRichTextBox.Text;
            PublicKey = PublicKeyRichTextBox.Text;

            int.TryParse(AESKeySizeComboBox.Text, out int size);
            KeySizeAES = size;
            int.TryParse(AESBlockSizeComboBox.Text, out size);
            BlockSizeAES = size;
            int.TryParse(RSAKeySizeComboBox.Text, out size);
            KeySizeRSA = size;
            int.TryParse(Properties.Settings.Default[KEY_ENCRYPT_TYPE].ToString(), out size);
            EncryptType = size;

            switch (EncryptType)
            {
                case TYPE_AES:
                    AESRadioButton.Checked = true;
                    RSARadioButton.Checked = false;
                    break;
                case TYPE_RSA:
                    AESRadioButton.Checked = false;
                    RSARadioButton.Checked = true;
                    break;
                default:
                    AESRadioButton.Checked = false;
                    RSARadioButton.Checked = false;
                    break;
            }
        }
    }
}
