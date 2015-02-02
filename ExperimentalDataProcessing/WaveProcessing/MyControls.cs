using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WaveProcessing
{
    // Классы будут отображаться на панели элементов
    // ВАЖНО:
    // перед добавлением элемента посредством панели элементов
    // раскомментируйте все //Init_* методы
    // после добавления - закомментируйте
    // другого способа не нашел...

    /// <summary>
    /// Красивая черная кнопка :)
    /// </summary>
    public class MyButton : Button
    {    
        public MyButton()
            : base()
        {
            //Init_Btn();

            MouseHover += MyButton_MouseHover;
            MouseEnter += MyButton_MouseEnter;
            MouseLeave += MyButton_MouseLeave;
        }

        void Init_Btn()
        {
            BackColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            FlatAppearance.MouseDownBackColor = Color.Red;
            FlatAppearance.MouseOverBackColor = Color.Maroon;
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Font = new Font("Consolas", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            ForeColor = Color.Chartreuse;
            Location = new Point(0, 0);
            Name = "btn";
            Size = new Size(100, 40);
            TabIndex = 0;
            Text = "Click";
            UseCompatibleTextRendering = true;
            UseVisualStyleBackColor = false;

            //// receive resource stream
            //MemoryStream fontStream = new MemoryStream(CustomResources.neuropol);
            //// create an unsafe memory block for the font data
            //System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
            //// create a buffer to read in to
            //byte[] fontdata = new byte[fontStream.Length];
            //// read the font data from the resource
            //fontStream.Read(fontdata, 0, (int)fontStream.Length);
            //// copy the bytes to the unsafe memory block
            //Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
            //// pass the font to the font collection
            //PrivateFontCollection private_fonts = new PrivateFontCollection();
            //private_fonts.AddMemoryFont(data, (int)fontStream.Length);
            //// close the resource stream
            //fontStream.Close();
            //// free up the unsafe memory
            //Marshal.FreeCoTaskMem(data);

            /////////////////////////////////////////////////

            //GCHandle pinnedArray = GCHandle.Alloc(CustomResources.neuropol, GCHandleType.Pinned);
            //IntPtr pointer = pinnedArray.AddrOfPinnedObject();
            ////do your stuff
            //PrivateFontCollection private_fonts = new PrivateFontCollection();
            //private_fonts.AddMemoryFont(pointer, CustomResources.neuropol.Length);
            //btn.Font = new Font(private_fonts.Families[0], 13, FontStyle.Bold);
            //pinnedArray.Free();

            /////////////////////////////////////////////////

            //if (!File.Exists(@"neuropol.ttf"))
            //    File.WriteAllBytes(@"neuropol.ttf", CustomResources.neuropol);
            //PrivateFontCollection pfc = new PrivateFontCollection();
            //pfc.AddFontFile(@"neuropol.ttf");
            //btn.Font = new Font(pfc.Families[0], 9, FontStyle.Bold);            
        }

        void MyButton_MouseHover(object sender, System.EventArgs e)
        {
            ToolTip tt = new ToolTip();
            string str = "";

            if (AccessibleDescription != null)
                str += AccessibleDescription + "\n\n";
            else str += Text + "\n\n";

            tt.UseAnimation = true;
            tt.InitialDelay = 5000;
            tt.AutoPopDelay = 30000;
            tt.SetToolTip(this, str);
        }
        void MyButton_MouseLeave(object sender, System.EventArgs e)
        { FlatAppearance.BorderColor = Color.Chartreuse; }
        void MyButton_MouseEnter(object sender, System.EventArgs e)
        { FlatAppearance.BorderColor = Color.Red; }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }

    /// <summary>
    /// Красивая черная область для графиков
    /// </summary>
    public class MyChart : Chart
    {
        private int maxPoints = 1500;
        public int MaxPoints {
            get
            { return maxPoints;}
            set { maxPoints = value; }
        }

        public MyChart()
        {
            //Init_Chart();
            //Init_BorderSkin();
            //Init_ChartArea();
            //Init_Legend();
            //Init_Series();
            
            MouseClick += MyChart_MouseClick;
            MouseEnter += chart_MouseEnter;
            MouseLeave += chart_MouseLeave;
        }

        void Init_Chart()
        {
            Name = "chart";
            Text = "chart1";
            BackColor = Color.Fuchsia;
            BackGradientStyle = GradientStyle.Center;
            BackSecondaryColor = Color.MidnightBlue;
            BorderlineColor = Color.MediumVioletRed;
            BorderlineDashStyle = ChartDashStyle.Solid;
            Cursor = System.Windows.Forms.Cursors.Cross;
            Location = new Point(0, 0);
            MinimumSize = new Size(200, 150);
            Palette = ChartColorPalette.Excel;
            Size = new Size(400, 300);
            SuppressExceptions = true;
        }
        void Init_BorderSkin()
        {
            BorderSkin.BackColor = Color.Empty;
            BorderSkin.BackImageTransparentColor = Color.Transparent;
            BorderSkin.BorderColor = Color.Empty;
            BorderSkin.PageColor = Color.Transparent;
            BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
        }
        void Init_ChartArea()
        {
            ChartArea chartArea1 = new ChartArea();

            chartArea1.Name = "ChartArea1";
            chartArea1.BackColor = Color.Black;
            chartArea1.BackHatchStyle = ChartHatchStyle.DiagonalCross;
            chartArea1.BackSecondaryColor = Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            chartArea1.BorderColor = Color.Empty;
            chartArea1.BorderWidth = 0;

            chartArea1.AxisX.ArrowStyle = chartArea1.AxisY.ArrowStyle = AxisArrowStyle.Triangle;
            chartArea1.AxisX.IsLabelAutoFit = chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisX.IsMarginVisible = chartArea1.AxisY.IsMarginVisible = false;
            chartArea1.AxisX.IsStartedFromZero = chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.Font = chartArea1.AxisY.LabelStyle.Font =
                new Font("Consolas", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisX.LabelStyle.ForeColor = chartArea1.AxisY.LabelStyle.ForeColor = Color.Chartreuse;
            chartArea1.AxisX.LineColor = chartArea1.AxisY.LineColor = Color.DarkViolet;
            chartArea1.AxisX.MajorTickMark.LineColor = chartArea1.AxisY.MajorTickMark.LineColor = Color.Cyan;
            chartArea1.AxisX.TitleFont = chartArea1.AxisY.TitleFont = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisX.TitleForeColor = chartArea1.AxisY.TitleForeColor = Color.Chartreuse;

            chartArea1.CursorX.IsUserEnabled = chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.CursorX.LineColor = chartArea1.CursorY.LineColor = Color.Lavender;
            chartArea1.CursorX.LineDashStyle = chartArea1.CursorY.LineDashStyle = ChartDashStyle.Dot;
            chartArea1.CursorX.SelectionColor = chartArea1.CursorY.SelectionColor = Color.Maroon;

            //////////
            chartArea1.AxisY.LabelStyle.Format = "0.###";

            ChartAreas.Add(chartArea1);
        }
        void Init_Legend()
        {
            Legend legend1 = new Legend();

            legend1.Alignment = StringAlignment.Far;
            legend1.BackColor = Color.Transparent;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = Docking.Top;
            legend1.Enabled = false;
            legend1.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            legend1.ForeColor = Color.Chartreuse;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.TitleFont = new Font("Consolas", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            legend1.TitleForeColor = Color.Yellow;

            Legends.Add(legend1);
        }
        void Init_Series()
        {
            for (int i = 0; i < 5; i++)
            {
                Series tmp = NewSeries();
                tmp.Name = "Series" + (i + 1);
                Series.Add(tmp);
            }
        }
        Series NewSeries()
        {
            Series tmp = new Series();

            tmp.BorderColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            tmp.ChartArea = "ChartArea1";
            tmp.ChartType = SeriesChartType.FastLine;
            tmp.EmptyPointStyle.LabelForeColor = Color.Yellow;
            tmp.Font = new Font("Consolas", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            tmp.LabelBackColor = Color.Transparent;
            tmp.LabelForeColor = Color.Yellow;
            tmp.Legend = "Legend1";
            tmp.ShadowOffset = 2;
            tmp.YValuesPerPoint = 2;

            return tmp;
        }

        void MyChart_MouseClick(object sender, MouseEventArgs e)
        {
            MyChart chart = (MyChart)sender;
            if (e.Button == MouseButtons.XButton2)
            {
                if (chart.ChartAreas[0].AxisX.ScaleView.IsZoomed)
                    chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                if (chart.ChartAreas[0].AxisY.ScaleView.IsZoomed)
                    chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
            }
        }
        void chart_MouseEnter(object sender, EventArgs e)
        { BorderlineColor = Color.Red; }
        void chart_MouseLeave(object sender, EventArgs e)
        { BorderlineColor = Color.MediumVioletRed; }
    }

}
