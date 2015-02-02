using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace WaveProcessing
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bgOpenWave = new System.ComponentModel.BackgroundWorker();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsWaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openLastFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWaveSpectreMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFilterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lpfMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hpfMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bpfMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brfMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paramsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoLoadLastFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.allParamsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWaveFile = new System.Windows.Forms.OpenFileDialog();
            this.gbWaves = new System.Windows.Forms.GroupBox();
            this.myChartWave = new WaveProcessing.MyChart();
            this.chartContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.seriesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsChartImgMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartFullScreenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unzoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.myChartFilter = new WaveProcessing.MyChart();
            this.gbSpectre = new System.Windows.Forms.GroupBox();
            this.myChartSpectre = new WaveProcessing.MyChart();
            this.gbParams = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new WaveProcessing.MyButton();
            this.btnPlayRes = new WaveProcessing.MyButton();
            this.chkDrawFilter = new System.Windows.Forms.CheckBox();
            this.lblM = new System.Windows.Forms.Label();
            this.lblFC2 = new System.Windows.Forms.Label();
            this.lblFC1 = new System.Windows.Forms.Label();
            this.tBoxM = new System.Windows.Forms.TextBox();
            this.tBoxFC2 = new System.Windows.Forms.TextBox();
            this.tBoxFC1 = new System.Windows.Forms.TextBox();
            this.btnPlayOrig = new WaveProcessing.MyButton();
            this.bgFilterProcess = new System.ComponentModel.BackgroundWorker();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgCalculateSpectre = new System.ComponentModel.BackgroundWorker();
            this.saveAsWave = new System.Windows.Forms.SaveFileDialog();
            this.saveAsChartImg = new System.Windows.Forms.SaveFileDialog();
            this.dragMoveProvider1 = new WinFormsDragMove.DragMoveProvider(this.components);
            this.mainMenu.SuspendLayout();
            this.gbWaves.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myChartWave)).BeginInit();
            this.chartContextMenu.SuspendLayout();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myChartFilter)).BeginInit();
            this.gbSpectre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myChartSpectre)).BeginInit();
            this.gbParams.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgOpenWave
            // 
            this.bgOpenWave.WorkerSupportsCancellation = true;
            this.bgOpenWave.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgOpenWave_DoWork);
            this.bgOpenWave.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgOpenWave_Completed);
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.Color.Transparent;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.viewMenuItem,
            this.toolsMenuItem,
            this.paramsMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(905, 24);
            this.mainMenu.TabIndex = 3;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openWaveMenuItem,
            this.saveAsWaveMenuItem,
            this.toolStripSeparator1,
            this.openLastFileMenuItem,
            this.toolStripSeparator2,
            this.exitMenuItem});
            this.fileMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileMenuItem.Text = "&Файл";
            // 
            // openWaveMenuItem
            // 
            this.openWaveMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.openWaveMenuItem.Name = "openWaveMenuItem";
            this.openWaveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openWaveMenuItem.Size = new System.Drawing.Size(208, 22);
            this.openWaveMenuItem.Text = "&Открыть...";
            this.openWaveMenuItem.Click += new System.EventHandler(this.openWaveMenuItem_Click);
            // 
            // saveAsWaveMenuItem
            // 
            this.saveAsWaveMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.saveAsWaveMenuItem.Name = "saveAsWaveMenuItem";
            this.saveAsWaveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsWaveMenuItem.Size = new System.Drawing.Size(208, 22);
            this.saveAsWaveMenuItem.Text = "&Сохранить как...";
            this.saveAsWaveMenuItem.Click += new System.EventHandler(this.saveAsWaveMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
            // 
            // openLastFileMenuItem
            // 
            this.openLastFileMenuItem.Name = "openLastFileMenuItem";
            this.openLastFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.openLastFileMenuItem.Size = new System.Drawing.Size(208, 22);
            this.openLastFileMenuItem.Text = "Последний файл";
            this.openLastFileMenuItem.Click += new System.EventHandler(this.openLastFileMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitMenuItem.Size = new System.Drawing.Size(208, 22);
            this.exitMenuItem.Text = "&Выход";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // viewMenuItem
            // 
            this.viewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showWaveSpectreMenuItem,
            this.showFilterMenuItem});
            this.viewMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewMenuItem.Name = "viewMenuItem";
            this.viewMenuItem.Size = new System.Drawing.Size(39, 20);
            this.viewMenuItem.Text = "&Вид";
            // 
            // showWaveSpectreMenuItem
            // 
            this.showWaveSpectreMenuItem.Name = "showWaveSpectreMenuItem";
            this.showWaveSpectreMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.showWaveSpectreMenuItem.Size = new System.Drawing.Size(314, 22);
            this.showWaveSpectreMenuItem.Text = "&Спектры сигналов (медленно)";
            this.showWaveSpectreMenuItem.Click += new System.EventHandler(this.showWaveSpectreMenuItem_Click);
            // 
            // showFilterMenuItem
            // 
            this.showFilterMenuItem.Checked = true;
            this.showFilterMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showFilterMenuItem.Name = "showFilterMenuItem";
            this.showFilterMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F)));
            this.showFilterMenuItem.Size = new System.Drawing.Size(314, 22);
            this.showFilterMenuItem.Text = "&График фильтра";
            this.showFilterMenuItem.Click += new System.EventHandler(this.showFilterMenuItem_Click);
            // 
            // toolsMenuItem
            // 
            this.toolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filtersMenuItem});
            this.toolsMenuItem.ForeColor = System.Drawing.Color.White;
            this.toolsMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolsMenuItem.Name = "toolsMenuItem";
            this.toolsMenuItem.Size = new System.Drawing.Size(79, 20);
            this.toolsMenuItem.Text = "&Обработка";
            // 
            // filtersMenuItem
            // 
            this.filtersMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.filtersMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lpfMenuItem,
            this.hpfMenuItem,
            this.bpfMenuItem,
            this.brfMenuItem});
            this.filtersMenuItem.Name = "filtersMenuItem";
            this.filtersMenuItem.Size = new System.Drawing.Size(124, 22);
            this.filtersMenuItem.Text = "&Фильтры";
            // 
            // lpfMenuItem
            // 
            this.lpfMenuItem.Name = "lpfMenuItem";
            this.lpfMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.lpfMenuItem.Size = new System.Drawing.Size(136, 22);
            this.lpfMenuItem.Text = "LPF";
            this.lpfMenuItem.Click += new System.EventHandler(this.filterChoiceMenuItem_Click);
            // 
            // hpfMenuItem
            // 
            this.hpfMenuItem.Name = "hpfMenuItem";
            this.hpfMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.hpfMenuItem.Size = new System.Drawing.Size(136, 22);
            this.hpfMenuItem.Text = "HPF";
            this.hpfMenuItem.Click += new System.EventHandler(this.filterChoiceMenuItem_Click);
            // 
            // bpfMenuItem
            // 
            this.bpfMenuItem.Name = "bpfMenuItem";
            this.bpfMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.bpfMenuItem.Size = new System.Drawing.Size(136, 22);
            this.bpfMenuItem.Text = "BPF";
            this.bpfMenuItem.Click += new System.EventHandler(this.filterChoiceMenuItem_Click);
            // 
            // brfMenuItem
            // 
            this.brfMenuItem.Name = "brfMenuItem";
            this.brfMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.brfMenuItem.Size = new System.Drawing.Size(136, 22);
            this.brfMenuItem.Text = "BRF";
            this.brfMenuItem.Click += new System.EventHandler(this.filterChoiceMenuItem_Click);
            // 
            // paramsMenuItem
            // 
            this.paramsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoLoadLastFileMenuItem,
            this.toolStripSeparator3,
            this.allParamsMenuItem});
            this.paramsMenuItem.ForeColor = System.Drawing.Color.White;
            this.paramsMenuItem.Name = "paramsMenuItem";
            this.paramsMenuItem.Size = new System.Drawing.Size(83, 20);
            this.paramsMenuItem.Text = "&Параметры";
            // 
            // autoLoadLastFileMenuItem
            // 
            this.autoLoadLastFileMenuItem.Name = "autoLoadLastFileMenuItem";
            this.autoLoadLastFileMenuItem.Size = new System.Drawing.Size(291, 22);
            this.autoLoadLastFileMenuItem.Text = "&Открывать последний файл при запуке";
            this.autoLoadLastFileMenuItem.Click += new System.EventHandler(this.autoLoadLastFileMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(288, 6);
            // 
            // allParamsMenuItem
            // 
            this.allParamsMenuItem.Name = "allParamsMenuItem";
            this.allParamsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.allParamsMenuItem.Size = new System.Drawing.Size(291, 22);
            this.allParamsMenuItem.Text = "&Больше...";
            this.allParamsMenuItem.Click += new System.EventHandler(this.allParamsMenuItem_Click);
            // 
            // openWaveFile
            // 
            this.openWaveFile.Filter = "Wave files (*.wav, *.dat)|*.wav;*.dat|All Files (*.*)|*.*";
            this.openWaveFile.Title = "Открыть звуковой файл...";
            // 
            // gbWaves
            // 
            this.gbWaves.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbWaves.BackColor = System.Drawing.Color.Transparent;
            this.gbWaves.Controls.Add(this.myChartWave);
            this.gbWaves.ForeColor = System.Drawing.Color.Chartreuse;
            this.gbWaves.Location = new System.Drawing.Point(12, 29);
            this.gbWaves.Name = "gbWaves";
            this.gbWaves.Size = new System.Drawing.Size(616, 370);
            this.gbWaves.TabIndex = 0;
            this.gbWaves.TabStop = false;
            this.gbWaves.Text = "Полигармонические [звуковые] сигналы";
            this.gbWaves.Visible = false;
            // 
            // myChartWave
            // 
            this.myChartWave.BackColor = System.Drawing.Color.Fuchsia;
            this.myChartWave.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            this.myChartWave.BackSecondaryColor = System.Drawing.Color.MidnightBlue;
            this.myChartWave.BorderlineColor = System.Drawing.Color.MediumVioletRed;
            this.myChartWave.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.myChartWave.BorderSkin.BackColor = System.Drawing.Color.Empty;
            this.myChartWave.BorderSkin.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.myChartWave.BorderSkin.BorderColor = System.Drawing.Color.Empty;
            this.myChartWave.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.myChartWave.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Chartreuse;
            chartArea1.AxisX.LineColor = System.Drawing.Color.DarkViolet;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Cyan;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.Chartreuse;
            chartArea1.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.IsMarginVisible = false;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Chartreuse;
            chartArea1.AxisY.LabelStyle.Format = "0.###";
            chartArea1.AxisY.LineColor = System.Drawing.Color.DarkViolet;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Cyan;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.Chartreuse;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DiagonalCross;
            chartArea1.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            chartArea1.BorderColor = System.Drawing.Color.Empty;
            chartArea1.BorderWidth = 0;
            chartArea1.CursorX.Interval = 0.0001D;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorX.LineColor = System.Drawing.Color.Lavender;
            chartArea1.CursorX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.CursorX.SelectionColor = System.Drawing.Color.Maroon;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.CursorY.LineColor = System.Drawing.Color.Lavender;
            chartArea1.CursorY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.CursorY.SelectionColor = System.Drawing.Color.Maroon;
            chartArea1.Name = "ChartArea1";
            this.myChartWave.ChartAreas.Add(chartArea1);
            this.myChartWave.ContextMenuStrip = this.chartContextMenu;
            this.myChartWave.Cursor = System.Windows.Forms.Cursors.Cross;
            this.myChartWave.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend1.ForeColor = System.Drawing.Color.Chartreuse;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.TitleFont = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend1.TitleForeColor = System.Drawing.Color.Yellow;
            this.myChartWave.Legends.Add(legend1);
            this.myChartWave.Location = new System.Drawing.Point(3, 19);
            this.myChartWave.MaxPoints = 500;
            this.myChartWave.Name = "myChartWave";
            this.myChartWave.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Yellow;
            series1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.LabelBackColor = System.Drawing.Color.Transparent;
            series1.LabelForeColor = System.Drawing.Color.Yellow;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.ShadowOffset = 2;
            series2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Yellow;
            series2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series2.LabelBackColor = System.Drawing.Color.Transparent;
            series2.LabelForeColor = System.Drawing.Color.Yellow;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series2.ShadowOffset = 2;
            series3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Yellow;
            series3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series3.LabelBackColor = System.Drawing.Color.Transparent;
            series3.LabelForeColor = System.Drawing.Color.Yellow;
            series3.Legend = "Legend1";
            series3.Name = "Series3";
            series3.ShadowOffset = 2;
            series3.YValuesPerPoint = 2;
            series4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Yellow;
            series4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series4.LabelBackColor = System.Drawing.Color.Transparent;
            series4.LabelForeColor = System.Drawing.Color.Yellow;
            series4.Legend = "Legend1";
            series4.Name = "Series4";
            series4.ShadowOffset = 2;
            series4.YValuesPerPoint = 2;
            series5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Yellow;
            series5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series5.LabelBackColor = System.Drawing.Color.Transparent;
            series5.LabelForeColor = System.Drawing.Color.Yellow;
            series5.Legend = "Legend1";
            series5.Name = "Series5";
            series5.ShadowOffset = 2;
            series5.YValuesPerPoint = 2;
            this.myChartWave.Series.Add(series1);
            this.myChartWave.Series.Add(series2);
            this.myChartWave.Series.Add(series3);
            this.myChartWave.Series.Add(series4);
            this.myChartWave.Series.Add(series5);
            this.myChartWave.Size = new System.Drawing.Size(610, 348);
            this.myChartWave.SuppressExceptions = true;
            this.myChartWave.TabIndex = 0;
            this.myChartWave.Text = "Звуковая волна";
            // 
            // chartContextMenu
            // 
            this.chartContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seriesMenuItem,
            this.saveAsChartImgMenuItem,
            this.chartFullScreenMenuItem,
            this.unzoomMenuItem});
            this.chartContextMenu.Name = "contextMenu1";
            this.chartContextMenu.Size = new System.Drawing.Size(163, 92);
            this.chartContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.chartContextMenu_Opening);
            // 
            // seriesMenuItem
            // 
            this.seriesMenuItem.Name = "seriesMenuItem";
            this.seriesMenuItem.Size = new System.Drawing.Size(162, 22);
            this.seriesMenuItem.Text = "&Графики";
            // 
            // saveAsChartImgMenuItem
            // 
            this.saveAsChartImgMenuItem.Name = "saveAsChartImgMenuItem";
            this.saveAsChartImgMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveAsChartImgMenuItem.Text = "&Сохранить как...";
            this.saveAsChartImgMenuItem.Click += new System.EventHandler(this.saveAsChartImgMenuItem_Click);
            // 
            // chartFullScreenMenuItem
            // 
            this.chartFullScreenMenuItem.Name = "chartFullScreenMenuItem";
            this.chartFullScreenMenuItem.Size = new System.Drawing.Size(162, 22);
            this.chartFullScreenMenuItem.Text = "&На весь экран";
            this.chartFullScreenMenuItem.Click += new System.EventHandler(this.chartFullScreenMenuItem_Click);
            // 
            // unzoomMenuItem
            // 
            this.unzoomMenuItem.Name = "unzoomMenuItem";
            this.unzoomMenuItem.Size = new System.Drawing.Size(162, 22);
            this.unzoomMenuItem.Text = "&Обнулить зум";
            this.unzoomMenuItem.Click += new System.EventHandler(this.unzoomMenuItem_Click);
            // 
            // gbFilter
            // 
            this.gbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbFilter.BackColor = System.Drawing.Color.Transparent;
            this.gbFilter.Controls.Add(this.myChartFilter);
            this.gbFilter.ForeColor = System.Drawing.Color.Chartreuse;
            this.gbFilter.Location = new System.Drawing.Point(12, 405);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(305, 222);
            this.gbFilter.TabIndex = 0;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Вейвлет-фильтр / cпектр вейвлета";
            this.gbFilter.Visible = false;
            // 
            // myChartFilter
            // 
            this.myChartFilter.BackColor = System.Drawing.Color.Fuchsia;
            this.myChartFilter.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            this.myChartFilter.BackSecondaryColor = System.Drawing.Color.MidnightBlue;
            this.myChartFilter.BorderlineColor = System.Drawing.Color.MediumVioletRed;
            this.myChartFilter.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.myChartFilter.BorderSkin.BackColor = System.Drawing.Color.Empty;
            this.myChartFilter.BorderSkin.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.myChartFilter.BorderSkin.BorderColor = System.Drawing.Color.Empty;
            this.myChartFilter.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.myChartFilter.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea2.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.IsMarginVisible = false;
            chartArea2.AxisX.IsStartedFromZero = false;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Chartreuse;
            chartArea2.AxisX.LineColor = System.Drawing.Color.DarkViolet;
            chartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Cyan;
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.Chartreuse;
            chartArea2.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.IsMarginVisible = false;
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Chartreuse;
            chartArea2.AxisY.LabelStyle.Format = "0.###";
            chartArea2.AxisY.LineColor = System.Drawing.Color.DarkViolet;
            chartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Cyan;
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea2.AxisY.TitleForeColor = System.Drawing.Color.Chartreuse;
            chartArea2.BackColor = System.Drawing.Color.Black;
            chartArea2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DiagonalCross;
            chartArea2.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            chartArea2.BorderColor = System.Drawing.Color.Empty;
            chartArea2.BorderWidth = 0;
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorX.LineColor = System.Drawing.Color.Lavender;
            chartArea2.CursorX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.CursorX.SelectionColor = System.Drawing.Color.Maroon;
            chartArea2.CursorY.IsUserEnabled = true;
            chartArea2.CursorY.IsUserSelectionEnabled = true;
            chartArea2.CursorY.LineColor = System.Drawing.Color.Lavender;
            chartArea2.CursorY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.CursorY.SelectionColor = System.Drawing.Color.Maroon;
            chartArea2.Name = "ChartArea1";
            this.myChartFilter.ChartAreas.Add(chartArea2);
            this.myChartFilter.ContextMenuStrip = this.chartContextMenu;
            this.myChartFilter.Cursor = System.Windows.Forms.Cursors.Cross;
            this.myChartFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Alignment = System.Drawing.StringAlignment.Far;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.DockedToChartArea = "ChartArea1";
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Enabled = false;
            legend2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend2.ForeColor = System.Drawing.Color.Chartreuse;
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            legend2.TitleFont = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend2.TitleForeColor = System.Drawing.Color.Yellow;
            this.myChartFilter.Legends.Add(legend2);
            this.myChartFilter.Location = new System.Drawing.Point(3, 19);
            this.myChartFilter.MaxPoints = 1500;
            this.myChartFilter.Name = "myChartFilter";
            this.myChartFilter.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Yellow;
            series6.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series6.LabelBackColor = System.Drawing.Color.Transparent;
            series6.LabelForeColor = System.Drawing.Color.Yellow;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            series6.ShadowOffset = 2;
            series6.YValuesPerPoint = 2;
            series7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Yellow;
            series7.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series7.LabelBackColor = System.Drawing.Color.Transparent;
            series7.LabelForeColor = System.Drawing.Color.Yellow;
            series7.Legend = "Legend1";
            series7.Name = "Series2";
            series7.ShadowOffset = 2;
            series7.YValuesPerPoint = 2;
            series8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Yellow;
            series8.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series8.LabelBackColor = System.Drawing.Color.Transparent;
            series8.LabelForeColor = System.Drawing.Color.Yellow;
            series8.Legend = "Legend1";
            series8.Name = "Series3";
            series8.ShadowOffset = 2;
            series8.YValuesPerPoint = 2;
            series9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Yellow;
            series9.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series9.LabelBackColor = System.Drawing.Color.Transparent;
            series9.LabelForeColor = System.Drawing.Color.Yellow;
            series9.Legend = "Legend1";
            series9.Name = "Series4";
            series9.ShadowOffset = 2;
            series9.YValuesPerPoint = 2;
            series10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Yellow;
            series10.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series10.LabelBackColor = System.Drawing.Color.Transparent;
            series10.LabelForeColor = System.Drawing.Color.Yellow;
            series10.Legend = "Legend1";
            series10.Name = "Series5";
            series10.ShadowOffset = 2;
            series10.YValuesPerPoint = 2;
            this.myChartFilter.Series.Add(series6);
            this.myChartFilter.Series.Add(series7);
            this.myChartFilter.Series.Add(series8);
            this.myChartFilter.Series.Add(series9);
            this.myChartFilter.Series.Add(series10);
            this.myChartFilter.Size = new System.Drawing.Size(299, 200);
            this.myChartFilter.SuppressExceptions = true;
            this.myChartFilter.TabIndex = 0;
            this.myChartFilter.Text = "Фильтр";
            // 
            // gbSpectre
            // 
            this.gbSpectre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbSpectre.BackColor = System.Drawing.Color.Transparent;
            this.gbSpectre.Controls.Add(this.myChartSpectre);
            this.gbSpectre.ForeColor = System.Drawing.Color.Chartreuse;
            this.gbSpectre.Location = new System.Drawing.Point(323, 405);
            this.gbSpectre.Name = "gbSpectre";
            this.gbSpectre.Size = new System.Drawing.Size(305, 222);
            this.gbSpectre.TabIndex = 0;
            this.gbSpectre.TabStop = false;
            this.gbSpectre.Text = "Спектры сигналов";
            this.gbSpectre.Visible = false;
            // 
            // myChartSpectre
            // 
            this.myChartSpectre.BackColor = System.Drawing.Color.Fuchsia;
            this.myChartSpectre.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            this.myChartSpectre.BackSecondaryColor = System.Drawing.Color.MidnightBlue;
            this.myChartSpectre.BorderlineColor = System.Drawing.Color.MediumVioletRed;
            this.myChartSpectre.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.myChartSpectre.BorderSkin.BackColor = System.Drawing.Color.Empty;
            this.myChartSpectre.BorderSkin.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.myChartSpectre.BorderSkin.BorderColor = System.Drawing.Color.Empty;
            this.myChartSpectre.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.myChartSpectre.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea3.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.IsMarginVisible = false;
            chartArea3.AxisX.IsStartedFromZero = false;
            chartArea3.AxisX.LabelStyle.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Chartreuse;
            chartArea3.AxisX.LineColor = System.Drawing.Color.DarkViolet;
            chartArea3.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Cyan;
            chartArea3.AxisX.TitleFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea3.AxisX.TitleForeColor = System.Drawing.Color.Chartreuse;
            chartArea3.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea3.AxisY.IsLabelAutoFit = false;
            chartArea3.AxisY.IsMarginVisible = false;
            chartArea3.AxisY.IsStartedFromZero = false;
            chartArea3.AxisY.LabelStyle.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Chartreuse;
            chartArea3.AxisY.LabelStyle.Format = "0.###";
            chartArea3.AxisY.LineColor = System.Drawing.Color.DarkViolet;
            chartArea3.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Cyan;
            chartArea3.AxisY.TitleFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea3.AxisY.TitleForeColor = System.Drawing.Color.Chartreuse;
            chartArea3.BackColor = System.Drawing.Color.Black;
            chartArea3.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DiagonalCross;
            chartArea3.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            chartArea3.BorderColor = System.Drawing.Color.Empty;
            chartArea3.BorderWidth = 0;
            chartArea3.CursorX.IsUserEnabled = true;
            chartArea3.CursorX.IsUserSelectionEnabled = true;
            chartArea3.CursorX.LineColor = System.Drawing.Color.Lavender;
            chartArea3.CursorX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea3.CursorX.SelectionColor = System.Drawing.Color.Maroon;
            chartArea3.CursorY.IsUserEnabled = true;
            chartArea3.CursorY.IsUserSelectionEnabled = true;
            chartArea3.CursorY.LineColor = System.Drawing.Color.Lavender;
            chartArea3.CursorY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea3.CursorY.SelectionColor = System.Drawing.Color.Maroon;
            chartArea3.Name = "ChartArea1";
            this.myChartSpectre.ChartAreas.Add(chartArea3);
            this.myChartSpectre.ContextMenuStrip = this.chartContextMenu;
            this.myChartSpectre.Cursor = System.Windows.Forms.Cursors.Cross;
            this.myChartSpectre.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Alignment = System.Drawing.StringAlignment.Far;
            legend3.BackColor = System.Drawing.Color.Transparent;
            legend3.DockedToChartArea = "ChartArea1";
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend3.Enabled = false;
            legend3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend3.ForeColor = System.Drawing.Color.Chartreuse;
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            legend3.TitleFont = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend3.TitleForeColor = System.Drawing.Color.Yellow;
            this.myChartSpectre.Legends.Add(legend3);
            this.myChartSpectre.Location = new System.Drawing.Point(3, 19);
            this.myChartSpectre.MaxPoints = 1500;
            this.myChartSpectre.Name = "myChartSpectre";
            this.myChartSpectre.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Yellow;
            series11.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series11.LabelBackColor = System.Drawing.Color.Transparent;
            series11.LabelForeColor = System.Drawing.Color.Yellow;
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            series11.ShadowOffset = 2;
            series11.YValuesPerPoint = 2;
            series12.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Yellow;
            series12.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series12.LabelBackColor = System.Drawing.Color.Transparent;
            series12.LabelForeColor = System.Drawing.Color.Yellow;
            series12.Legend = "Legend1";
            series12.Name = "Series2";
            series12.ShadowOffset = 2;
            series12.YValuesPerPoint = 2;
            series13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Yellow;
            series13.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series13.LabelBackColor = System.Drawing.Color.Transparent;
            series13.LabelForeColor = System.Drawing.Color.Yellow;
            series13.Legend = "Legend1";
            series13.Name = "Series3";
            series13.ShadowOffset = 2;
            series13.YValuesPerPoint = 2;
            series14.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series14.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Yellow;
            series14.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series14.LabelBackColor = System.Drawing.Color.Transparent;
            series14.LabelForeColor = System.Drawing.Color.Yellow;
            series14.Legend = "Legend1";
            series14.Name = "Series4";
            series14.ShadowOffset = 2;
            series14.YValuesPerPoint = 2;
            series15.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series15.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Yellow;
            series15.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series15.LabelBackColor = System.Drawing.Color.Transparent;
            series15.LabelForeColor = System.Drawing.Color.Yellow;
            series15.Legend = "Legend1";
            series15.Name = "Series5";
            series15.ShadowOffset = 2;
            series15.YValuesPerPoint = 2;
            this.myChartSpectre.Series.Add(series11);
            this.myChartSpectre.Series.Add(series12);
            this.myChartSpectre.Series.Add(series13);
            this.myChartSpectre.Series.Add(series14);
            this.myChartSpectre.Series.Add(series15);
            this.myChartSpectre.Size = new System.Drawing.Size(299, 200);
            this.myChartSpectre.SuppressExceptions = true;
            this.myChartSpectre.TabIndex = 0;
            this.myChartSpectre.Text = "Спектр";
            // 
            // gbParams
            // 
            this.gbParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbParams.BackColor = System.Drawing.Color.Transparent;
            this.gbParams.Controls.Add(this.btnRefresh);
            this.gbParams.Controls.Add(this.btnPlayRes);
            this.gbParams.Controls.Add(this.chkDrawFilter);
            this.gbParams.Controls.Add(this.lblM);
            this.gbParams.Controls.Add(this.lblFC2);
            this.gbParams.Controls.Add(this.lblFC1);
            this.gbParams.Controls.Add(this.tBoxM);
            this.gbParams.Controls.Add(this.tBoxFC2);
            this.gbParams.Controls.Add(this.tBoxFC1);
            this.gbParams.Controls.Add(this.btnPlayOrig);
            this.gbParams.ForeColor = System.Drawing.Color.Chartreuse;
            this.gbParams.Location = new System.Drawing.Point(634, 29);
            this.gbParams.MinimumSize = new System.Drawing.Size(259, 367);
            this.gbParams.Name = "gbParams";
            this.gbParams.Size = new System.Drawing.Size(259, 367);
            this.gbParams.TabIndex = 2;
            this.gbParams.TabStop = false;
            this.gbParams.Text = "Параметры";
            this.gbParams.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.Black;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnRefresh.ForeColor = System.Drawing.Color.Chartreuse;
            this.btnRefresh.Location = new System.Drawing.Point(6, 333);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(247, 28);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "&Применить";
            this.btnRefresh.UseCompatibleTextRendering = true;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPlayRes
            // 
            this.btnPlayRes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlayRes.BackColor = System.Drawing.Color.Black;
            this.btnPlayRes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnPlayRes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnPlayRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayRes.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnPlayRes.ForeColor = System.Drawing.Color.Chartreuse;
            this.btnPlayRes.Location = new System.Drawing.Point(6, 279);
            this.btnPlayRes.Name = "btnPlayRes";
            this.btnPlayRes.Size = new System.Drawing.Size(247, 28);
            this.btnPlayRes.TabIndex = 2;
            this.btnPlayRes.Text = "Воспроизвести результат";
            this.btnPlayRes.UseCompatibleTextRendering = true;
            this.btnPlayRes.UseVisualStyleBackColor = false;
            this.btnPlayRes.Visible = false;
            this.btnPlayRes.Click += new System.EventHandler(this.btnPlayRes_Click);
            // 
            // chkDrawFilter
            // 
            this.chkDrawFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDrawFilter.AutoSize = true;
            this.chkDrawFilter.Checked = true;
            this.chkDrawFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDrawFilter.ForeColor = System.Drawing.Color.Chartreuse;
            this.chkDrawFilter.Location = new System.Drawing.Point(21, 109);
            this.chkDrawFilter.Name = "chkDrawFilter";
            this.chkDrawFilter.Size = new System.Drawing.Size(163, 19);
            this.chkDrawFilter.TabIndex = 1;
            this.chkDrawFilter.Text = "Спектр фильтра / фильтр";
            this.chkDrawFilter.UseVisualStyleBackColor = true;
            this.chkDrawFilter.CheckedChanged += new System.EventHandler(this.chkDrawFilter_Changed);
            // 
            // lblM
            // 
            this.lblM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblM.AutoSize = true;
            this.lblM.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblM.Location = new System.Drawing.Point(105, 83);
            this.lblM.Name = "lblM";
            this.lblM.Size = new System.Drawing.Size(102, 15);
            this.lblM.TabIndex = 6;
            this.lblM.Text = "Размер вейвлета";
            // 
            // lblFC2
            // 
            this.lblFC2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFC2.AutoSize = true;
            this.lblFC2.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblFC2.Location = new System.Drawing.Point(105, 54);
            this.lblFC2.Name = "lblFC2";
            this.lblFC2.Size = new System.Drawing.Size(137, 15);
            this.lblFC2.TabIndex = 5;
            this.lblFC2.Text = "Частота среза (справа)";
            // 
            // lblFC1
            // 
            this.lblFC1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFC1.AutoSize = true;
            this.lblFC1.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblFC1.Location = new System.Drawing.Point(105, 25);
            this.lblFC1.Name = "lblFC1";
            this.lblFC1.Size = new System.Drawing.Size(129, 15);
            this.lblFC1.TabIndex = 4;
            this.lblFC1.Text = "Частота среза (слева)";
            // 
            // tBoxM
            // 
            this.tBoxM.AccessibleName = "Детализация";
            this.tBoxM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxM.Location = new System.Drawing.Point(21, 80);
            this.tBoxM.Name = "tBoxM";
            this.tBoxM.Size = new System.Drawing.Size(78, 23);
            this.tBoxM.TabIndex = 0;
            // 
            // tBoxFC2
            // 
            this.tBoxFC2.AccessibleName = "Частота среза (справа)";
            this.tBoxFC2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxFC2.Location = new System.Drawing.Point(21, 51);
            this.tBoxFC2.Name = "tBoxFC2";
            this.tBoxFC2.Size = new System.Drawing.Size(78, 23);
            this.tBoxFC2.TabIndex = 0;
            // 
            // tBoxFC1
            // 
            this.tBoxFC1.AccessibleName = "Частота среза (слева)";
            this.tBoxFC1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxFC1.Location = new System.Drawing.Point(21, 22);
            this.tBoxFC1.Name = "tBoxFC1";
            this.tBoxFC1.Size = new System.Drawing.Size(78, 23);
            this.tBoxFC1.TabIndex = 0;
            // 
            // btnPlayOrig
            // 
            this.btnPlayOrig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlayOrig.BackColor = System.Drawing.Color.Black;
            this.btnPlayOrig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnPlayOrig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnPlayOrig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayOrig.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.btnPlayOrig.ForeColor = System.Drawing.Color.Chartreuse;
            this.btnPlayOrig.Location = new System.Drawing.Point(6, 245);
            this.btnPlayOrig.Name = "btnPlayOrig";
            this.btnPlayOrig.Size = new System.Drawing.Size(247, 28);
            this.btnPlayOrig.TabIndex = 2;
            this.btnPlayOrig.Text = "Воспроизвести оригинал";
            this.btnPlayOrig.UseCompatibleTextRendering = true;
            this.btnPlayOrig.UseVisualStyleBackColor = false;
            this.btnPlayOrig.Visible = false;
            this.btnPlayOrig.Click += new System.EventHandler(this.btnPlayOrig_Click);
            // 
            // bgFilterProcess
            // 
            this.bgFilterProcess.WorkerSupportsCancellation = true;
            this.bgFilterProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgFilterProcess_DoWork);
            this.bgFilterProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgFilterProcess_Completed);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 630);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(905, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel1
            // 
            this.statusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.statusLabel1.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.statusLabel1.ForeColor = System.Drawing.Color.White;
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(44, 17);
            this.statusLabel1.Text = "Готово";
            // 
            // bgCalculateSpectre
            // 
            this.bgCalculateSpectre.WorkerSupportsCancellation = true;
            this.bgCalculateSpectre.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgCalculateSpectre_DoWork);
            this.bgCalculateSpectre.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgCalculateSpectre_RunWorkerCompleted);
            // 
            // saveAsWave
            // 
            this.saveAsWave.Filter = "Wave files (*.wav, *.dat)|*.wav;*.dat|All Files (*.*)|*.*";
            // 
            // saveAsChartImg
            // 
            this.saveAsChartImg.Filter = "PNG Images (*.png)|*.png|All Files (*.*)|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::WaveProcessing.Properties.Resources.back;
            this.ClientSize = new System.Drawing.Size(905, 652);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.gbParams);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.gbSpectre);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.gbWaves);
            this.DoubleBuffered = true;
            this.dragMoveProvider1.SetEnableDragMove(this, true);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(921, 690);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WaveProcessing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.gbWaves.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myChartWave)).EndInit();
            this.chartContextMenu.ResumeLayout(false);
            this.gbFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myChartFilter)).EndInit();
            this.gbSpectre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myChartSpectre)).EndInit();
            this.gbParams.ResumeLayout(false);
            this.gbParams.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgOpenWave;
        private WaveProcessing.MyButton btnPlayOrig;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lpfMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hpfMenuItem;
        private OpenFileDialog openWaveFile;
        private WaveProcessing.MyChart myChartWave;
        private WaveProcessing.MyChart myChartFilter;
        private WaveProcessing.MyChart myChartSpectre;
        private GroupBox gbWaves;
        private GroupBox gbFilter;
        private GroupBox gbSpectre;
        private System.ComponentModel.BackgroundWorker bgFilterProcess;
        private StatusStrip statusStrip;
        private GroupBox gbParams;
        private Label lblM;
        private Label lblFC2;
        private Label lblFC1;
        private TextBox tBoxM;
        private TextBox tBoxFC2;
        private TextBox tBoxFC1;
        private ToolStripStatusLabel statusLabel1;
        private ToolStripMenuItem bpfMenuItem;
        private ToolStripMenuItem brfMenuItem;
        private CheckBox chkDrawFilter;
        private MyButton btnPlayRes;
        private System.ComponentModel.BackgroundWorker bgCalculateSpectre;
        private ToolStripMenuItem openWaveMenuItem;
        private ToolStripMenuItem saveAsWaveMenuItem;
        private SaveFileDialog saveAsWave;
        private ContextMenuStrip chartContextMenu;
        private ToolStripMenuItem seriesMenuItem;
        private ToolStripMenuItem unzoomMenuItem;
        private ToolStripMenuItem saveAsChartImgMenuItem;
        private SaveFileDialog saveAsChartImg;
        private ToolStripMenuItem chartFullScreenMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem openLastFileMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private WinFormsDragMove.DragMoveProvider dragMoveProvider1;
        private MyButton btnRefresh;
        private ToolStripMenuItem viewMenuItem;
        private ToolStripMenuItem showWaveSpectreMenuItem;
        private ToolStripMenuItem showFilterMenuItem;
        private ToolStripMenuItem paramsMenuItem;
        private ToolStripMenuItem autoLoadLastFileMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem allParamsMenuItem;

    }
}

