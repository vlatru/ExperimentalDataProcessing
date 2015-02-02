using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WinFormsDragMove;

namespace WaveProcessing
{
    /// <remarks>Класс <c>MainForm</c></remarks>
    public partial class MainForm : Form
    {
        // ключ приложения в регистре Windows
        const string proj = "ExperimentalDataProcessing\\WaveProcessing";
        string path, fileName;              // полное и короткое имя текущего файла
        double dt;                          // шаг дискретизации
        int n,                              // число значений сигнала (с нулями)
            freq,                           // предельная частота сигнала
            realLength,                     // реальное число значений сигнала
            fileType;                       // тип файла (1-wav|riff, 2-dat)
        double[] powersOfTwo,               // степени двойки
            origWave1, origWave2,           // сигнал (левый и правый каналы)
            origWaveSpectre,                // спектр сигнала (по левому каналу)
            filter, filterSpectre,          // вейвлет-фильтр и его спектр
            filteredWave1, filteredWave2,   // преобр. сигнал (левый и правый каналы)
            filteredWaveSpectre;            // спектр преобр. сигнала (по левому каналу)
        MemoryStream fileMemStr,            // поток исходного файла
            newFileMemStr;                  // поток преобразованного файла
        bool twoChannels = false,           // стерео или нет
            prepFFT = false;                // подготовить данные к БПФ или нет
        int accuracy, sPos, shift;
        bool success = false;
        //ResizeableControl rCtrl;

        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            myChartWave.Series[0].Color = Color.DarkMagenta;
            myChartWave.Series[1].Color = Color.Red;
            myChartWave.Series[0].Name = "Сигнал";
            myChartWave.Series[1].Name = "Отфильтрованый сигнал";
            myChartWave.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            myChartFilter.Series[0].Color = Color.Yellow;
            myChartFilter.Series[0].Name = "Вейвлет-фильтр";
            //myChartFilter.Cursor = Cursors.Hand;
            myChartSpectre.Series[0].Color = Color.DarkMagenta;
            myChartSpectre.Series[1].Color = Color.Red;
            myChartSpectre.Series[0].Name = "Фурье-спектр сигнала";
            myChartSpectre.Series[1].Name = "Фурье-спектр отфильтрованого сигнала";
            myChartSpectre.Series[0].ChartType = SeriesChartType.Candlestick;
            myChartSpectre.Series[1].ChartType = SeriesChartType.Candlestick;
            //myChartSpectre.Cursor = Cursors.Hand;

            //rCtrl = new ResizeableControl(gbWaves);
            //rCtrl = new ResizeableControl(gbFilter);
            //rCtrl = new ResizeableControl(gbSpectre);
            //rCtrl = new ResizeableControl(gbParams);

            powersOfTwo = new double[25];
            for (int i = 1; i < powersOfTwo.Length; i++)
                powersOfTwo[i] = Math.Pow(2, i);
        }

        #region menu actions

        /// <summary>
        /// Выбор нового файла
        /// </summary>
        void openWaveMenuItem_Click(object sender, EventArgs e)
        {
            ClearUI();

            RegistryKey key = Registry.CurrentUser.OpenSubKey(proj);
            string tmp;
            if (key != null && (tmp = (string)key.GetValue("InitialDirectory")) != null && Directory.Exists(tmp))
                openWaveFile.InitialDirectory = tmp;
            else openWaveFile.InitialDirectory = Environment.CurrentDirectory; //Directory.GetCurrentDirectory();

            if (openWaveFile.ShowDialog() == DialogResult.OK)
            {
                path = openWaveFile.FileNames[0];

                key = Registry.CurrentUser.CreateSubKey(proj);
                key.OpenSubKey(proj, true);
                if (Path.GetDirectoryName(path) != openWaveFile.InitialDirectory)
                    key.SetValue("InitialDirectory", Path.GetDirectoryName(path));

                if (!bgOpenWave.IsBusy)
                    bgOpenWave.RunWorkerAsync();
            }
        }
        void ClearUI()
        {
            Text = "WaveProcessing";
            ClearCharts();
            btnPlayOrig.Visible = btnPlayRes.Visible = false;
            gbWaves.Visible = gbParams.Visible = false;
            gbFilter.Visible = gbSpectre.Visible = false;
            if (bgFilterProcess.IsBusy) bgFilterProcess.CancelAsync();
            if (bgCalculateSpectre.IsBusy) bgCalculateSpectre.CancelAsync();
        }
        /// <summary>
        /// Чтение данных файла
        /// </summary>
        void bgOpenWave_DoWork(object sender, DoWorkEventArgs e)
        {
            fileName = Path.GetFileName(path);
            string ext = Path.GetExtension(path).ToLower();
            fileType = (ext == ".wav" || ext == ".wave" || ext == ".riff") ? 1 :
                (ext == ".dat") ? 2 : -1;
            if (fileType == -1)
            {
                MessageBox.Show("Некорректный формат", "Ошибка");
                success = false; return;
            }

            SaveFileProperties();

            origWaveSpectre = filteredWave1 = filteredWave2 = null;
            filter = filteredWaveSpectre = filterSpectre = null;

            fileMemStr = new MemoryStream(File.ReadAllBytes(path));

            if (fileType == 1) success = OpenWave();
            else if (fileType == 2) success = OpenDat();
            if (!success) return;

            DeleteShift();
            success = true;
        }
        /// <summary>
        /// Сохраняет параметры текущего файла в реестр
        /// </summary>        
        void SaveFileProperties()
        {
            if (fileName != null)
            {
                string fileProp = proj + "\\" + fileName;
                RegistryKey key_file = Registry.CurrentUser.CreateSubKey(fileProp);
                key_file.OpenSubKey(fileName, true);

                if (tBoxFC1.Text != "") key_file.SetValue("fc1", tBoxFC1.Text);
                if (tBoxFC2.Text != "") key_file.SetValue("fc2", tBoxFC2.Text);
                if (tBoxM.Text != "") key_file.SetValue("m", tBoxM.Text);
            }
        }
        bool OpenWave()
        {
            // использован класс Wave, взятый в Интернете (см. Wave.cs)
            Wave wave = new Wave(new MemoryStream(File.ReadAllBytes(path)));

            freq = wave.SampleRate;
            dt = 1 / (double)freq;
            realLength = wave.Frames;

            sPos = wave.StartPosition;
            accuracy = wave.SignificantBitsPerSample;

            statusLabel1.Text = "Файл: " + fileName +
                "    Частота: " + freq + "Гц; " +
                "Каналы: " + wave.NumberOfChannels + "; " +
                "Бит/сек: " + wave.AverageBytesPerSecond + "; " +
                "Время: " + Math.Round(wave.TimeLength, 2) + " сек.";
            if (twoChannels = wave.NumberOfChannels == 2)
                statusLabel1.Text += " Показан левый канал";

            if (prepFFT)
            {
                for (int i = 0; i < powersOfTwo.Length; i++)
                    if (powersOfTwo[i] > realLength)
                    { n = (int)powersOfTwo[i]; break; }
            }
            else n = realLength;

            origWave1 = new double[n];
            origWave2 = new double[n];
            for (int i = 0; i < realLength; i++)
                origWave1[i] = wave.DataSamples[0][i];
            if (twoChannels)
                for (int i = 0; i < realLength; i++)
                    origWave2[i] = wave.DataSamples[1][i];
            for (int i = realLength; i < n; i++)
                origWave1[i] = 0;
            if (twoChannels)
                for (int i = realLength; i < n; i++)
                    origWave2[i] = 0;

            return true;
        }
        bool OpenDat()
        {
            double[] tmp = ReadDatFileToDouble(fileMemStr);

            //f = 22050;
            //dt = 1 / (double)f;
            // TODO: Автоматически определять частоту сигнала
            freq = 1000;
            dt = 0.001;
            realLength = tmp.Length;

            statusLabel1.Text = "Файл: " + fileName +
                "    Частота: " + freq + "Гц; " +
                "Время: " + Math.Round(realLength * dt, 2) + " сек.";

            if (prepFFT)
            {
                for (int i = 0; i < powersOfTwo.Length; i++)
                    if (powersOfTwo[i] > realLength)
                    { n = (int)powersOfTwo[i]; break; }
            }
            else n = realLength;

            origWave1 = new double[n];
            for (int i = 0; i < realLength; i++)
                origWave1[i] = tmp[i];
            for (int i = realLength; i < n; i++)
                origWave1[i] = 0;

            return true;
        }
        /// <summary>
        /// Считывает 16-битные значения сигнала из заданного .dat файла
        /// </summary>
        /// <param name="fileMemStream">Массив данных .dat</param>
        /// <returns>Массив со значениями сигнала</returns>
        double[] ReadDatFileToDouble(MemoryStream fileMemStream)
        {
            double[] res = new double[fileMemStream.Length / sizeof(Int16)];
            BinaryReader br = new BinaryReader(fileMemStream);
            for (int i = 0; i < res.Length; i++)
                res[i] = (double)br.ReadInt16();
            br.Close();
            return res;
        }
        void DeleteShift()
        {
            int chkStep = realLength > 1000 ? realLength / 1000 : 1;
            double avg = 0;
            for (int k = 0; k < realLength; k += chkStep)
                avg += origWave1[k];
            avg /= realLength > 1000 ? 1000 : realLength;
            shift = (int)avg;
            for (int i = 0; i < realLength; i++)
                origWave1[i] -= shift;
            if (twoChannels)
                for (int i = 0; i < realLength; i++)
                    origWave2[i] -= shift;

        }
        /// <summary>
        /// Инициализация элементов UI после успешного прочтения файла
        /// </summary>
        void bgOpenWave_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!success) return;

            Text = fileName + " - WaveProcessing";

            RegistryKey key = Registry.CurrentUser.CreateSubKey(proj);
            key.OpenSubKey(proj, true);
            key.SetValue("LastFile", path);

            LoadFileProperties();
            Draw(myChartWave.Series[0], origWave1, dt, !prepFFT);
            AxesLimits(myChartWave);

            if (showWaveSpectreMenuItem.Checked)
                bgCalculateSpectre.RunWorkerAsync();

            if (fileType == 1)
                btnPlayOrig.Visible = true;
            gbWaves.Visible = true;
            chkDrawFilter.Visible = showFilterMenuItem.Checked;

        }

        /// <summary>
        /// Инициализирует текстбоксы значениями из реестра,
        /// если они были сохранены ранее (для определенного файла),
        /// иначе - значениями по умолчанию
        /// </summary>
        void LoadFileProperties()
        {
            string fileProp = proj + "\\" + fileName;
            RegistryKey key_file = Registry.CurrentUser.OpenSubKey(fileProp);
            string value;

            if (key_file != null)
            {
                if ((value = (string)key_file.GetValue("fc1")) != null)
                    tBoxFC1.Text = value;
                if ((value = (string)key_file.GetValue("fc2")) != null)
                    tBoxFC2.Text = value;
                if ((value = (string)key_file.GetValue("m")) != null)
                    tBoxM.Text = value;
            }
            else
            {
                if (freq / 25 > 0) tBoxFC1.Text = (freq / 25).ToString();
                else tBoxFC1.Text = "";
                if (freq / 5 > 0) tBoxFC2.Text = (freq / 5).ToString();
                else tBoxFC2.Text = "";
                tBoxM.Text = "64";
            }
        }

        void saveAsWaveMenuItem_Click(object sender, EventArgs e)
        {
            if (filteredWave1 == null)
            { MessageBox.Show("Нет отфильтрованного сигнала", "Ошибка"); return; }

            RegistryKey key = Registry.CurrentUser.OpenSubKey(proj);
            string tmp;
            if (key != null && (tmp = (string)key.GetValue("InitialDirectory")) != null && Directory.Exists(tmp))
                saveAsWave.InitialDirectory = tmp;
            else saveAsWave.InitialDirectory = Environment.CurrentDirectory;

            if (saveAsWave.ShowDialog() == DialogResult.OK)
            {
                FileStream file = new FileStream(saveAsWave.FileName, FileMode.Create);
                PrepareNewFile();
                newFileMemStr.WriteTo(file);
                file.Close();
            }
        }
        /// <summary>
        /// Формирует новый файл (в памяти)
        /// из значений отфильтрованного сигнала
        /// </summary>
        void PrepareNewFile()
        {
            if (filteredWave1 == null || newFileMemStr != null) return;

            newFileMemStr = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(newFileMemStr);
            if (fileType == 1)
            {
                NormalizeAndAddShift(1);

                // copy header
                byte[] bytes = new byte[sPos];
                fileMemStr.Position = 0;
                fileMemStr.Read(bytes, 0, sPos);
                bw.Write(bytes);

                // write new frames
                if (accuracy == 16)
                {
                    for (int i = 0; i < realLength; i++)
                        bw.Write((Int16)filteredWave1[i]);
                    if (twoChannels)
                        for (int i = 0; i < realLength; i++)
                            bw.Write((Int16)filteredWave2[i]);
                }
                else if (accuracy == 8)
                {
                    for (int i = 0; i < realLength; i++)
                        bw.Write((byte)filteredWave1[i]);
                    if (twoChannels)
                        for (int i = 0; i < realLength; i++)
                            bw.Write((byte)filteredWave2[i]);
                }
                else MessageBox.Show("Не удалось сохранить файл", "Ошибка");

            }
            else if (fileType == 2)
            {
                for (int i = 0; i < realLength; i++)
                    bw.Write((Int16)filteredWave1[i]);
            }
        }
        /// <summary>
        /// Получает байт массив из преобразованного сигнала
        /// для воспроизведения или сохранения в файл
        /// </summary>
        void NormalizeAndAddShift(double k)
        {
            double normFactor = (origWave1.Max() * k) / filteredWave1.Max();
            for (int i = 0; i < realLength; i++)
                filteredWave1[i] = filteredWave1[i] * normFactor + shift;
            if (twoChannels)
                for (int i = 0; i < realLength; i++)
                    filteredWave2[i] = filteredWave2[i] * normFactor + shift;
        }

        void openLastFileMenuItem_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(proj);
            string tmp;
            if (key != null && (tmp = (string)key.GetValue("LastFile")) != null && File.Exists(tmp))
            {
                path = tmp;
                if (!bgOpenWave.IsBusy)
                    bgOpenWave.RunWorkerAsync();
            }
            else MessageBox.Show("Файл не найден", "Ошибка");
        }

        void exitMenuItem_Click(object sender, EventArgs e) { Close(); }

        void filterChoiceMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == null)
            { MessageBox.Show("Выберите файл", "Ошибка"); return; }

            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            btnRefresh.Text = "Обновить (" + menuItem.Text + ")";
            btnRefresh.AccessibleName = menuItem.Text;
            btnRefresh_Click(sender, null);
        }
        /// <summary>
        /// Фильтрация сигнала, выбранным фильтром
        /// </summary>
        void bgFilterProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            string mtd = btnRefresh.AccessibleName;

            if (!VerifyTBVal(tBoxFC1, freq / 2 - 1) ||
                !VerifyTBVal(tBoxM, 300, 2))
            { success = false; return; }
            if (mtd == "BPF" || mtd == "BRF")
            {
                if (!VerifyTBVal(tBoxFC2, freq / 2 - 1))
                { success = false; return; }

                int tmp1, tmp2;
                if (tBoxFC1.Text != "" && int.TryParse(tBoxFC1.Text, out tmp1) &&
                    tBoxFC2.Text != "" && int.TryParse(tBoxFC2.Text, out tmp2))
                    if (tmp1 > tmp2)
                    {
                        MessageBox.Show("'" + tBoxFC1.AccessibleName +
                        "' должна быть меньше '" + tBoxFC2.AccessibleName + "'.", "Ошибка");
                        success = false; return;
                    }
            }

            filteredWaveSpectre = null;
            newFileMemStr = null;

            int fc1 = int.Parse(tBoxFC1.Text),
                fc2 = int.Parse(tBoxFC2.Text),
                m = int.Parse(tBoxM.Text);

            switch (mtd)
            {
                case "LPF": filter = FreqFiltering.LPF(fc1, m, dt); break;
                case "HPF": filter = FreqFiltering.HPF(fc1, m, dt); break;
                case "BPF": filter = FreqFiltering.BPF(fc1, fc2, m, dt); break;
                case "BRF": filter = FreqFiltering.BRF(fc1, fc2, m, dt); break;
            }

            filteredWave1 = FreqFiltering.Convolution(origWave1, filter);
            if (fileType == 1 && twoChannels)
                filteredWave2 = FreqFiltering.Convolution(origWave2, filter);
            success = true;
        }
        // TODO: MaskedTextBox
        /// <summary>
        /// Проверяет вхождение значения текстбокса в заданный диапазон
        /// </summary>
        /// <param name="tb">текстбокс</param>
        /// <param name="limit2">Верхняя граница параметра</param>
        /// <param name="limit1">Необязательно: Нижняя граница параметра</param>
        /// <returns>boolean</returns>
        bool VerifyTBVal(TextBox tb, int limit2, int limit1 = 1)
        {
            int tmp = 0;
            if (tb.Text != "" && int.TryParse(tb.Text, out tmp)
                && tmp >= limit1 && tmp <= limit2) return true;
            else
            {
                string str = "Допустимые зачения: целые числа от " +
                    limit1 + " до " + limit2;
                if (tb == tBoxFC1)
                    if (freq / 5 > 0) str += "\n\nНапример: " + (freq / 25);
                if (tb == tBoxFC2)
                    if (freq / 25 > 0) str += "\n\nНапример: " + (freq / 5);
                if (tb == tBoxM) str += "\n\nНапример: 64";
                MessageBox.Show(str,
                    "Некорректное значение: '" + tb.AccessibleName + "'");
                return false;
            }
        }
        void bgFilterProcess_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            int fc1 = int.Parse(tBoxFC1.Text),
                fc2 = int.Parse(tBoxFC2.Text),
                m = int.Parse(tBoxM.Text);
            string mtd = btnRefresh.AccessibleName;
            saveAsWave.FileName = Path.GetFileNameWithoutExtension(path) + "_" + mtd + "(" + fc1 + ",";
            lblFC1.Text = "Частота среза";
            switch (mtd)
            {
                case "LPF": tBoxFC2.Visible = lblFC2.Visible = false; break;
                case "HPF": tBoxFC2.Visible = lblFC2.Visible = false; break;
                case "BPF":
                    {
                        saveAsWave.FileName += fc2 + ",";
                        lblFC1.Text += " (слева)";
                        tBoxFC2.Visible = lblFC2.Visible = true;
                        break;
                    }
                case "BRF":
                    {
                        saveAsWave.FileName += fc2 + ",";
                        lblFC1.Text += " (слева)";
                        tBoxFC2.Visible = lblFC2.Visible = true;
                        break;
                    }
            }
            saveAsWave.FileName += m + ")" + Path.GetExtension(path);

            if (fileType == 1)
                btnPlayRes.Visible = true;
            gbParams.Visible = true;

            if (!success) return;

            Draw(myChartWave.Series[1], filteredWave1, dt, !prepFFT);
            chkDrawFilter_Changed(null, null);
        }
        
        void showWaveSpectreMenuItem_Click(object sender, EventArgs e)
        {
            if (!bgCalculateSpectre.IsBusy)
            {
                showWaveSpectreMenuItem.Checked = !showWaveSpectreMenuItem.Checked;
                if (showWaveSpectreMenuItem.Checked)
                    bgCalculateSpectre.RunWorkerAsync();
            }
        }
        /// <summary>
        /// Отрисовка спектров сигналов 
        /// </summary>
        void bgCalculateSpectre_DoWork(object sender, DoWorkEventArgs e)
        {
            if (origWave1 == null) { success = false; return; }

            if (showWaveSpectreMenuItem.Checked)
            {
                if (realLength > 30000)
                {
                    DialogResult dlgResult = MessageBox.Show("Файл слишком большой.\n" +
                        "Построение спектра может занять много времени,\n" +
                        "т.к. используется обычный алгоритм ППФ\n\n" +
                        "Все равно продолжить?", "Предупреждение",
                        MessageBoxButtons.YesNo);
                    if (dlgResult != DialogResult.Yes)
                    { success = false; return; }
                }

                if (origWaveSpectre == null)
                    origWaveSpectre = FreqFiltering.DirectFourierDouble(origWave1, freq);

                if (filteredWave1 != null && filteredWaveSpectre == null)
                    filteredWaveSpectre = FreqFiltering.DirectFourierDouble(filteredWave1, freq);
            }
            success = true;
        }
        void bgCalculateSpectre_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!success) { showWaveSpectreMenuItem.Checked = false; return; }

            Draw(myChartSpectre.Series[0], origWaveSpectre);

            if (filteredWave1 != null)
                Draw(myChartSpectre.Series[1], filteredWaveSpectre);

            gbSpectre.Visible = showWaveSpectreMenuItem.Checked;

            AxesLimits(myChartSpectre, false);
        }

        void showFilterMenuItem_Click(object sender, EventArgs e)
        {
            showFilterMenuItem.Checked = !showFilterMenuItem.Checked;
            gbFilter.Visible = showFilterMenuItem.Checked;
        }

        void autoLoadLastFileMenuItem_Click(object sender, EventArgs e)
        { autoLoadLastFileMenuItem.Checked = !autoLoadLastFileMenuItem.Checked; }

        void allParamsMenuItem_Click(object sender, EventArgs e) { }

        #endregion

        #region control actions

        void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!bgFilterProcess.IsBusy)
                bgFilterProcess.RunWorkerAsync();

            if (!bgCalculateSpectre.IsBusy && showWaveSpectreMenuItem.Checked)
                bgCalculateSpectre.RunWorkerAsync(); ;
        }
        void chkDrawFilter_Changed(object sender, EventArgs e)
        {
            if (!(gbFilter.Visible = chkDrawFilter.Visible = showFilterMenuItem.Checked) ||
                    filter == null) return;
            if (chkDrawFilter.Checked)
            {
                filterSpectre = FreqFiltering.DirectFourierDouble(filter, freq);
                myChartFilter.Series[0].Name = "Спектр вейвлет-фильтра";
                myChartFilter.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
                Draw(myChartFilter.Series[0], filterSpectre);
            }
            else
            {
                myChartFilter.Series[0].Name = "Вейвлет-фильтр";
                myChartFilter.ChartAreas[0].AxisY.Enabled = AxisEnabled.Auto;
                Draw(myChartFilter.Series[0], filter);
            }
            AxesLimits(myChartFilter);
        }
        void btnPlayOrig_Click(object sender, EventArgs e)
        {
            fileMemStr.Position = 0;
            SoundPlayer playerOrig = new SoundPlayer(fileMemStr);
            playerOrig.Play();
        }
        void btnPlayRes_Click(object sender, EventArgs e)
        {
            PrepareNewFile();
            newFileMemStr.Position = 0;
            SoundPlayer playerResult = new SoundPlayer(newFileMemStr);
            playerResult.Play();
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(proj);
            bool autoLoad = false;
            //myChartFilter.Series[0].ChartType
            if (key != null && bool.TryParse((string)key.GetValue("AutoLoad"), out autoLoad))
                if (autoLoadLastFileMenuItem.Checked = autoLoad)
                    openLastFileMenuItem_Click(null, null);
        }
        void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(proj);
            key.OpenSubKey(proj, true);
            key.SetValue("AutoLoad", autoLoadLastFileMenuItem.Checked);
            //SaveFileProperties();
        }

        #region charts all about

        void ClearCharts()
        {
            ClearChart(myChartWave);
            ClearChart(myChartFilter);
            ClearChart(myChartSpectre);
        }
        void ClearChart(MyChart ch)
        {
            for (int i = 0; i < ch.Series.Count; i++)
                ch.Series[i].Points.Clear();
        }
        void Draw(Series ser, double[] y, double dt = 1, bool withZeros = true)
        {
            int cnt = withZeros ? y.Length : realLength,
                step = cnt > 500 ? cnt / 500 : 1;
            if (ser.Points.Count > 0) ser.Points.Clear();
            for (int k = 0; k < cnt; k += step)
                ser.Points.AddXY(k * dt, y[k]);
        }
        void AxesLimits(MyChart ch, bool bottom = true, bool top = true)
        {
            // for x
            double min = double.MaxValue, max = double.MinValue;
            for (int i = 0; i < ch.Series.Count; i++)
                if (ch.Series[i].Points.Count > 0)
                {
                    double tmp1, tmp2;
                    tmp1 = ch.Series[i].Points[0].XValue;
                    tmp2 = ch.Series[i].Points[ch.Series[i].Points.Count - 1].XValue;
                    if (tmp1 < min) min = tmp1;
                    if (tmp2 > max) max = tmp2;
                }
            if (min != double.MaxValue)
            {
                if (min == max) { min--; max++; }
                double difX = Math.Abs(max - min);
                ch.ChartAreas[0].AxisX.Minimum = min - 0.005 * difX;
                ch.ChartAreas[0].AxisX.Maximum = max + 0.005 * difX;

                // for y                
                min = double.MaxValue; max = double.MinValue;
                for (int i = 0; i < ch.Series.Count; i++)
                    if (ch.Series[i].Points.Count > 0)
                    {
                        double tmp1, tmp2;
                        tmp1 = ch.Series[i].Points.FindMinByValue().YValues[0];
                        tmp2 = ch.Series[i].Points.FindMaxByValue().YValues[0];
                        if (tmp1 < min) min = tmp1;
                        if (tmp2 > max) max = tmp2;
                    }
                if (min == max) { min--; max++; }
                double difY = Math.Abs(max - min);
                if (bottom) ch.ChartAreas[0].AxisY.Minimum = min - 0.1 * difY;
                if (top) ch.ChartAreas[0].AxisY.Maximum = max + 0.1 * difY;

                //format values
                ch.ChartAreas[0].AxisX.LabelStyle.Format = "0.00";
                if (Math.Truncate(difX * 10) == 0)
                    for (int i = 1; i < 6; i++)
                    {
                        if (Math.Truncate(difX * Math.Pow(10, i)) == 0)
                            ch.ChartAreas[0].AxisX.LabelStyle.Format += "0";
                        else break;
                    }

                ch.ChartAreas[0].AxisY.LabelStyle.Format = "0.00";
                if (Math.Truncate(difY * 10) == 0)

                    for (int i = 1; i < 6; i++)
                    {
                        if (Math.Truncate(difY * Math.Pow(10, i)) == 0)
                            ch.ChartAreas[0].AxisY.LabelStyle.Format += "0";
                        else break;
                    }

                //selection area
                ch.ChartAreas[0].CursorX.Interval = ch.ChartAreas[0].AxisX.Interval;
                ch.ChartAreas[0].CursorY.Interval = ch.ChartAreas[0].AxisY.Interval;
            }
        }

        #region chart context menu

        void chartContextMenu_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip cMenu = (ContextMenuStrip)sender;
            cMenu.Tag = cMenu.SourceControl;
            MyChart ch = (MyChart)cMenu.SourceControl;

            for (int i = 0; i < cMenu.Items.Count; i++)
                cMenu.Items[i].Visible = true;

            List<string> serNames = new List<string>();
            for (int i = 0; i < ch.Series.Count; i++)
                if (ch.Series[i].Points.Count > 0)
                    serNames.Add(ch.Series[i].Name);
            ToolStripMenuItem serMenu =
                (ToolStripMenuItem)cMenu.Items.Find("seriesMenuItem", false)[0];
            if (serNames.Count > 0) GetSeriesMenuItems(ch, serNames, serMenu);
            else
            {
                serMenu.Visible = false;
                cMenu.Items.Find("saveAsChartImgMenuItem", false)[0].Visible = false;
            }

            ToolStripMenuItem fScr =
                (ToolStripMenuItem)cMenu.Items.Find("chartFullScreenMenuItem", false)[0];
            if (ch.Parent == this) fScr.Checked = true;
            else fScr.Checked = false;

            if (!ch.ChartAreas[0].AxisX.ScaleView.IsZoomed &&
                !ch.ChartAreas[0].AxisY.ScaleView.IsZoomed)
                cMenu.Items.Find("unzoomMenuItem", false)[0].Visible = false;

            //cMenu.Enabled = false;
        }
        void GetSeriesMenuItems(MyChart ch, List<string> serNames, ToolStripMenuItem serMenu)
        {
            //SeriesChartType if yVals > 0 : Radar,... 
            string[] chartTypes = { "Line", "Candlestick", "Spline", "SplineArea" };
            ToolStripMenuItem[] serMenuItems = new ToolStripMenuItem[serNames.Count];
            for (int i = 0; i < serMenuItems.Length; i++)
            {
                serMenuItems[i] = new ToolStripMenuItem(serNames[i]);
                Series ser = ch.Series.FindByName(serNames[i]);
                serMenuItems[i].Checked = ser.Enabled;

                ToolStripMenuItem chartTypeMenuItem = new ToolStripMenuItem("Тип графика");
                ToolStripMenuItem[] typesMenuItems = new ToolStripMenuItem[chartTypes.Length];
                for (int k = 0; k < typesMenuItems.Length; k++)
                {
                    typesMenuItems[k] = new ToolStripMenuItem(chartTypes[k]);
                    if (ser.ChartType == (SeriesChartType)Enum.Parse(typeof(SeriesChartType), typesMenuItems[k].Text, true))
                    { typesMenuItems[k].Checked = true; continue; }
                    typesMenuItems[k].Click += anyParamMenuItem_Click;
                }
                chartTypeMenuItem.DropDownItems.AddRange(typesMenuItems);
                serMenuItems[i].DropDownItems.Add(chartTypeMenuItem);

                ToolStripMenuItem borderWidthMenuItem = new ToolStripMenuItem("Толщина линии");
                ToolStripMenuItem[] widthsMenuItems = new ToolStripMenuItem[5];
                for (int k = 0; k < widthsMenuItems.Length; k++)
                {
                    widthsMenuItems[k] = new ToolStripMenuItem((k + 1).ToString());
                    if (ser.BorderWidth == k + 1)
                    { widthsMenuItems[k].Checked = true; continue; }
                    widthsMenuItems[k].Click += anyParamMenuItem_Click;
                }
                borderWidthMenuItem.DropDownItems.AddRange(widthsMenuItems);
                serMenuItems[i].DropDownItems.Add(borderWidthMenuItem);

                ToolStripMenuItem showPointsMenuItem = new ToolStripMenuItem("Показать точки");
                showPointsMenuItem.Checked = ser.MarkerStyle != MarkerStyle.None;
                showPointsMenuItem.Click += anyParamMenuItem2_Click;
                serMenuItems[i].DropDownItems.Add(showPointsMenuItem);

                ToolStripMenuItem showLabelsMenuItem = new ToolStripMenuItem("Показать подписи точек");
                showLabelsMenuItem.Checked = ser.Label != "";
                showLabelsMenuItem.Click += anyParamMenuItem2_Click;
                serMenuItems[i].DropDownItems.Add(showLabelsMenuItem);

                serMenuItems[i].Click += seriesMenuItem_Click;
            }
            serMenu.DropDownItems.Clear();
            serMenu.DropDownItems.AddRange(serMenuItems);
        }
        Control GetParentControlFromMenuItem(object sender)
        {
            ContextMenuStrip cMenu;
            if (sender as ContextMenuStrip != null)
                cMenu = (ContextMenuStrip)sender;
            else
            {
                ToolStripItem item = (ToolStripItem)sender;
                while (item.OwnerItem != null)
                    item = item.OwnerItem;
                cMenu = (ContextMenuStrip)item.Owner;
            }
            return (Control)cMenu.Tag;
        }
        void seriesMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            menuItem.Checked = !menuItem.Checked;
            MyChart ch = (MyChart)GetParentControlFromMenuItem(sender);
            ch.Series.FindByName(menuItem.Text).Enabled = menuItem.Checked;
        }
        void anyParamMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            menuItem.Checked = !menuItem.Checked;
            MyChart chart = (MyChart)GetParentControlFromMenuItem(sender);
            string paramName = ((ToolStripMenuItem)menuItem.OwnerItem).Text;
            string serName = ((ToolStripMenuItem)menuItem.OwnerItem.OwnerItem).Text;
            Series series = chart.Series.FindByName(serName);
            if (paramName == "Тип графика")
                series.ChartType = (SeriesChartType)Enum.Parse(
                    typeof(SeriesChartType), menuItem.Text, true);
            else if (paramName == "Толщина линии")
            {
                series.BorderWidth = int.Parse(menuItem.Text);
                if (series.MarkerStyle != MarkerStyle.None)
                    series.MarkerSize = series.BorderWidth + 1;
            }
        }
        void anyParamMenuItem2_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            menuItem.Checked = !menuItem.Checked;
            MyChart chart = (MyChart)GetParentControlFromMenuItem(sender);
            string serName = ((ToolStripMenuItem)menuItem.OwnerItem).Text;
            Series series = chart.Series.FindByName(serName);
            if (menuItem.Text == "Показать точки")
                if (series.MarkerStyle == MarkerStyle.None)
                {
                    series.MarkerStyle = MarkerStyle.Cross;
                    Color clr = Color.FromArgb(
                        series.Color.R + 125 > 255 ? series.Color.R - 125 : series.Color.R + 125,
                        series.Color.G + 125 > 255 ? series.Color.G - 125 : series.Color.G + 125,
                        series.Color.B + 125 > 255 ? series.Color.B - 125 : series.Color.B + 125);
                    series.MarkerColor = clr;
                    series.MarkerSize = series.BorderWidth + 3;
                    //series.MarkerStep = series.Points.Count > 200?
                    //    series.Points.Count /200: 1;
                }
                else series.MarkerStyle = MarkerStyle.None;
            else if (menuItem.Text == "Показать подписи точек")
            {
                if (series.Label == "")
                {
                    series.Label = "{#VALX;#VALY}";
                    //series.LabelFormat = chart.ChartAreas[0].AxisX.LabelStyle.Format
                    //    + ";" + chart.ChartAreas[0].AxisY.LabelStyle.Format;
                }
                else series.Label = "";
            }
        }
        void unzoomMenuItem_Click(object sender, EventArgs e)
        {
            MyChart ch = (MyChart)GetParentControlFromMenuItem(sender);
            while (ch.ChartAreas[0].AxisX.ScaleView.IsZoomed ||
                ch.ChartAreas[0].AxisY.ScaleView.IsZoomed)
            {
                ch.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                ch.ChartAreas[0].AxisY.ScaleView.ZoomReset();
            }
        }
        void saveAsChartImgMenuItem_Click(object sender, EventArgs e)
        {
            saveAsChartImg.InitialDirectory = Path.GetDirectoryName(path);
            saveAsChartImg.FileName = Path.GetFileNameWithoutExtension(path) +
                "_" + tBoxFC1.Text + ";" + tBoxFC2.Text + ";" + tBoxM.Text + ".png";
            if (saveAsChartImg.ShowDialog() == DialogResult.OK)
            {
                ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
                MyChart ch = (MyChart)GetParentControlFromMenuItem(sender);
                if (!saveAsChartImg.FileName.EndsWith(".png"))
                    saveAsChartImg.FileName += ".png";
                ch.SaveImage(saveAsChartImg.FileName, ChartImageFormat.Png);
            }
        }
        void chartFullScreenMenuItem_Click(object sender, EventArgs e)
        {
            MyChart ch = (MyChart)GetParentControlFromMenuItem(sender);

            if (ch.Parent != this)
            {
                ch.Tag = ch.Parent;
                Control ctrl = (Control)ch.Tag;
                while (ctrl != this) ctrl = ctrl.Parent;
                Form frm = (Form)ctrl;
                mainMenu.Visible = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.WindowState = FormWindowState.Maximized;
                frm.Controls.Add(ch);
                ch.BringToFront();
                ch.Focus();
                ch.KeyUp += _KeyUp;
            }
            else
            {
                Form frm = (Form)ch.Parent;
                try { frm.Controls.Find("mainMenu", false)[0].Visible = true; }
                catch { }
                frm.FormBorderStyle = FormBorderStyle.Sizable;
                frm.WindowState = FormWindowState.Normal;
                ((Control)ch.Tag).Controls.Add(ch);
                ch.KeyUp -= _KeyUp;
            }
        }
        void _KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape && sender is MyChart)
            {
                MyChart ch = (MyChart)sender;
                Form frm = (Form)ch.Parent;
                try { frm.Controls.Find("mainMenu", false)[0].Visible = true; }
                catch { }
                frm.FormBorderStyle = FormBorderStyle.Sizable;
                frm.WindowState = FormWindowState.Normal;
                ((Control)ch.Tag).Controls.Add(ch);
                ch.KeyUp -= _KeyUp;
            }
        }

        #endregion

        #endregion

        #endregion


    }
}
