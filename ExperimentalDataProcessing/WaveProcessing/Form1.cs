using System;
using System.Threading;
using System.Windows.Forms;

namespace WaveProcessing
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            button1.Text = backgroundWorker1.ToString();
        }

        double DblRND()
        { return (double)rnd.Next(-100, 100); }

        void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 3; j++)
                    customChart1.chart1.Series[j].Points.AddY(DblRND());
        }

        void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1_DoWork(null, null);
        }
    }
}
