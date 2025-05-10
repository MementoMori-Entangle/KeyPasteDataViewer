using System;
using System.Windows.Forms;

namespace KeyPasteDataViewer
{
    /// <summary>
    /// タブ
    /// </summary>
    public partial class Tab : Form
    {
        /// <summary>
        /// 追加タブ名 デフォルト値
        /// </summary>
        const string TAB_DEFAULT_NAME = "add new";

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        public Tab()
        {
            InitializeComponent();

            KPDV kpdv = new KPDV();
            TabPage tabPage = new TabPage(TAB_DEFAULT_NAME);

            tabPage.Controls.Add(kpdv);
            TabControl.TabPages.Add(tabPage);
        }

        /// <summary>
        /// タブ追加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabAddButton_Click(object sender, EventArgs e)
        {
            string tabName = TAB_DEFAULT_NAME;

            if (!string.IsNullOrEmpty(TabAddTextBox.Text))
            {
                tabName = TabAddTextBox.Text;
            }

            KPDV kpdv = new KPDV();
            TabPage tabPage = new TabPage(tabName);

            tabPage.Controls.Add(kpdv);
            TabControl.TabPages.Add(tabPage);
        }

        /// <summary>
        /// タブ削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabDelButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TabAddTextBox.Text))
            {
                return;
            }

            int cnt = TabControl.TabCount;

            for (int i = KeyPasteData.ZERO; i < cnt; i++)
            {
                TabPage tabPage = TabControl.TabPages[i];

                if (TabAddTextBox.Text == tabPage.Text)
                {
                    TabControl.TabPages.RemoveAt(i);

                    break;
                }
            }
        }

        /// <summary>
        /// 別枠表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeparateFrameButton_Click(object sender, EventArgs e)
        {
            KeyPasteDataViewer keyPasteDataViewer = new KeyPasteDataViewer();

            keyPasteDataViewer.Show();
        }

        /// <summary>
        /// タブ選択処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (KeyPasteData.MINUS < TabControl.SelectedIndex)
            {
                TabAddTextBox.Text = TabControl.TabPages[TabControl.SelectedIndex].Text;
            }
        }
    }
}
