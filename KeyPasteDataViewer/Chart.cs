using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KeyPasteDataViewer
{
    /// <summary>
    /// チャート
    /// </summary>
    public partial class Chart : Form
    {
        /// <summary>
        /// チャートデータ
        /// </summary>
        public DataGridView ChartDataGridView { get; set; }

        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// X軸タイトル
        /// </summary>
        public string TitleX { get; set; }

        /// <summary>
        /// Y軸タイトル
        /// </summary>
        public string TitleY { get; set; }

        /// <summary>
        /// キー チャート種別
        /// </summary>
        const string KEY_CHART_TYPE = "chart_type";

        /// <summary>
        /// 基本カラー
        /// </summary>
        readonly List<Color> colorList;

        /// <summary>
        /// チャート種類
        /// </summary>
        readonly List<SeriesChartType> SERIES_CHART_TYPE_LIST = new List<SeriesChartType>
        {
            SeriesChartType.Area,
            SeriesChartType.Bar,
            SeriesChartType.BoxPlot,
            SeriesChartType.Bubble,
            SeriesChartType.Candlestick,
            SeriesChartType.Column,
            SeriesChartType.Doughnut,
            SeriesChartType.ErrorBar,
            SeriesChartType.FastLine,
            SeriesChartType.FastPoint,
            SeriesChartType.Funnel,
            //SeriesChartType.Kagi,
            SeriesChartType.Line,
            SeriesChartType.Pie,
            SeriesChartType.Point,
            //SeriesChartType.PointAndFigure,
            SeriesChartType.Polar,
            SeriesChartType.Pyramid,
            SeriesChartType.Radar,
            SeriesChartType.Range,
            SeriesChartType.RangeBar,
            SeriesChartType.RangeColumn,
            //SeriesChartType.Renko,
            SeriesChartType.Spline,
            SeriesChartType.SplineArea,
            SeriesChartType.StackedArea,
            SeriesChartType.StackedArea100,
            SeriesChartType.StackedBar,
            SeriesChartType.StackedBar100,
            SeriesChartType.StackedColumn,
            SeriesChartType.StackedColumn100,
            SeriesChartType.StepLine,
            SeriesChartType.Stock,
            //SeriesChartType.ThreeLineBreak
        };

        /// <summary>
        /// コンストラクタ処理
        /// </summary>
        public Chart()
        {
            InitializeComponent();

            this.colorList = new List<Color>
            {
                Color.Blue,
                Color.Red,
                Color.Yellow,
                Color.Orange,
                Color.Violet,
                Color.Black,
                Color.DeepPink,
                Color.Gray,
                Color.Green
            };
        }

        /// <summary>
        /// チャート生成
        /// </summary>
        public void ChartCreator()
        {
            int record = ChartDataGridView.RowCount;
            int columns = ChartDataGridView.ColumnCount;

            if (1 > record || 0 == columns)
            {
                return;
            }

            MainChart.Series.Clear();
            MainChart.ChartAreas.Clear();
            MainChart.Titles.Clear();

            Title title = new Title(Title);

            int recordCnt = record - 1;
            int colorCnt = this.colorList.Count;

            if (colorCnt < columns)
            {
                this.AddChartColor(columns - colorCnt);
            }

            Series[] header = new Series[columns];

            // ヘッダ
            for (int i = 0; i < columns; i++)
            {
                header[i] = new Series
                {
                    ChartType = SeriesChartType.Line,
                    LegendText = ChartDataGridView.Columns[i].HeaderText,
                    BorderWidth = 2,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 10,
                    Color = this.colorList[i]
                };
            }

            // データ
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < recordCnt; j++)
                {
                    string text;

                    if (null != ChartDataGridView[i, j].Value)
                    {
                        text = ChartDataGridView[i, j].Value.ToString();
                    }
                    else
                    {
                        text = "0";
                    }

                    double.TryParse(text, out double data);

                    header[i].Points.Add(new DataPoint(j, data));
                }
            }

            ChartArea area = new ChartArea();
            area.AxisX.Title = TitleX;
            area.AxisY.Title = TitleY;

            MainChart.Titles.Add(title);
            MainChart.ChartAreas.Add(area);

            for (int i = 0; i < columns; i++)
            {
                MainChart.Series.Add(header[i]);
            }

            TypeComboBox.DataSource = SERIES_CHART_TYPE_LIST;
            TypeComboBox.SelectedIndex = (int)Properties.Settings.Default[KEY_CHART_TYPE];
        }

        /// <summary>
        /// チャートカラー追加
        /// </summary>
        /// <param name="addNum">追加数</param>
        private void AddChartColor(int addNum)
        {
            MethodInfo[] methods = typeof(Color).GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.GetProperty);

            int baseColorCnt = methods.Length;
            int cnt = 1;

            for (int i = 0; i < addNum; i++)
            {
                Color color = (Color)methods[cnt].Invoke(methods[cnt], null);

                this.colorList.Add(color);

                cnt++;

                if (baseColorCnt == cnt)
                {
                    cnt = 1;
                }
            }
        }

        /// <summary>
        /// チャート種別変更処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != TypeComboBox.SelectedItem)
            {
                int columns = ChartDataGridView.ColumnCount;

                for (int i = 0; i < columns; i++)
                {
                    MainChart.Series[i].ChartType = (SeriesChartType)TypeComboBox.SelectedItem;
                }
            }
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
        /// チャート印刷ボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintButton_Click(object sender, EventArgs e)
        {
            MainChart.Printing.Print(true);
        }

        /// <summary>
        /// チャートプレビューボタン押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewButton_Click(object sender, EventArgs e)
        {
            MainChart.Printing.PrintPreview();
        }

        /// <summary>
        /// 印刷設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintSettingButton_Click(object sender, EventArgs e)
        {
            MainChart.Printing.PageSetup();
        }
    }
}
