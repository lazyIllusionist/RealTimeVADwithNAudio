using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using RealTimeVAD;
using RealTimeVAD.Detectors;

namespace WindowsFormsVAD
{
    public partial class Form1 : Form
    {
        List<Label> labels;
        bool ind = false;
        WaveIn waveIn;
        WaveFileWriter writer;
        string filePath;//;"D:/Samples/Example1.wav";

        byte[][] bytes_arr;
        Dictionary<string, byte[]> framesDictionary;

        RealTimeVAD.Detectors.ShortTimeEnergyDetector sted;
        RealTimeVAD.Detectors.ShortTimeZeroCrossDetector stzcd;

        List<EnergyArray> stedArrays;

        public Form1()
        {
            InitializeComponent();
            Initialize();
            labels = new List<Label> { zeroCounterLabel1, zeroCounterLabel2, zeroCounterLabel3, zeroCounterLabel4,
            zeroCounterLabel5, zeroCounterLabel6, zeroCounterLabel7, zeroCounterLabel8, zeroCounterLabel9, zeroCounterLabel10};
           // StartButton.PerformClick();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        bool Initialize()
        {
            try
            {
                InitDetector();
                InitWriter();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        void InitDetector()
        {
            stzcd = new RealTimeVAD.Detectors.ShortTimeZeroCrossDetector
            {
                fraimSampleRate = 8000,
                percentOfSucsess = 60
            };

            sted = new RealTimeVAD.Detectors.ShortTimeEnergyDetector
            {
                fraimSampleRate = 8000,
                percentOfSucsess = 40
            };
        }

        void InitWriter()
        {
           

            waveIn = new WaveIn();
            waveIn.WaveFormat = new WaveFormat(8000, 1);

            writer = new WaveFileWriter(filePath, waveIn.WaveFormat);

            waveIn.DeviceNumber = 0;//0;
            waveIn.DataAvailable += Data_Avaible;
            waveIn.RecordingStopped += waveIn_RecordingStopped;
            waveIn.WaveFormat = new WaveFormat(8000, 1);

        }

        [Obsolete]
        void Data_Avaible(object sender, WaveInEventArgs e)
        {
            sted.fraim = e;
            stzcd.fraim = e;

            bool enVoice = sted.VoiceIsPresent;
            bool stVoice = stzcd.VoiceIsPresent;

            if (enVoice || stVoice) boolPanel.BackColor = Color.Green;
            else boolPanel.BackColor = Color.Red;

            stedArrays = sted.energyArraysList;

            for(int i = 0; i < 10; i++)
            {
                labels[i].Text = stzcd.arr[i].count.ToString();
                if (stzcd.arr[i].result) labels[i].BackColor = Color.Green;
                else labels[i].BackColor = Color.Red;
            }

            Panel.Refresh();

            //if (this.InvokeRequired)
            //{
            //    this.BeginInvoke(new EventHandler<WaveInEventArgs>(Data_Avaible), sender, e);
            //}
            //else
            //{
            //    //Записываем данные из буфера в файл
            //    writer.WriteData(e.Buffer, 0, e.BytesRecorded);
            //}
        }

        private void waveIn_RecordingStopped(object sender, EventArgs e)
        {
            waveIn.Dispose();
            waveIn = null;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {

            if (waveIn == null)
                InitWriter();
            try
            {
                if (ind)
                {
                    waveIn.StopRecording();
                    Panel.Paint -= Paint;
                    ind = false;
                }
                else
                {
                    waveIn.StartRecording();
                    Panel.Paint += Paint;
                    ind = true;

                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private void Paint(object sender, PaintEventArgs e)
        {
            PointF p1, p2;

            int max_y = 32768;
            int min_y = 0;
            float max_x = 800 - 1 ;

            e.Graphics.ScaleTransform(1.0f, -1.0f);
            e.Graphics.TranslateTransform(0.0f, -1.0f * Panel.Height);

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            float y;
            float x;

            path.AddLine(new PointF(50, Panel.Height * ((float)(max_y * 0.08)) / (max_y - min_y)), new PointF(0, Panel.Height * ((float)(max_y * 0.08)) / (max_y - min_y)));
            e.Graphics.DrawPath(Pens.Green, path);

            p1 = new Point(0, 0);

            foreach (var arr in stedArrays)
            {
                max_y = 32768;
                min_y = 0;

                foreach(var f in arr._energyList)
                {
                    
                    if (f < min_y) min_y = f;
                }

                for (x = 1; x <= max_x / 10; x++)
                {
                    y = arr._energyList[(int)x];
                    p2 = new PointF((x / (max_x/10)) * Panel.Width, Panel.Height * (y - min_y) / (max_y - min_y));
                    path.AddLine(p1, p2);
                    p1 = p2;
                }
                e.Graphics.DrawPath(Pens.Black, path);
            }

        }

        private void WaveformPainter1_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        void WAVOutput(string filePath)
        {
            WaveStream mainOutputStream = new WaveFileReader(filePath);
            WaveChannel32 volumeStream = new WaveChannel32(mainOutputStream);

            WaveOutEvent player = new WaveOutEvent();

            player.Init(volumeStream);

            player.Play();
        }

        private void FolderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() == DialogResult.OK)
            {
                filePath = opf.FileName;

                byte[] bytes = File.ReadAllBytes(filePath);
                var b = bytes.ToList();
                b.RemoveRange(0, 44);
                bytes = b.ToArray();

                int counter = 0;
                bytes_arr = bytes.GroupBy(_ => counter++ / 1600).Select(elem => elem.ToArray()).ToArray();

                framesDictionary = new Dictionary<string, byte[]>();
                counter = 0; 
                foreach(var i in bytes_arr)
                {
                    framesComboBox.Items.Add($"Frame{counter}");
                    framesDictionary.Add($"Frame{counter++}", i);
                }

                //framesComboBox.Items.AddRange = framesDictionary.Select(elem => elem.Key).ToList<string>();
            }

        }

        private void Play_Click(object sender, EventArgs e)
        {
            System.Threading.Timer timer;
            TimerCallback tc;

            if (filePath != null)
            {
                tc = new TimerCallback(TimersCaller);
                WAVOutput(filePath);
                timer = new System.Threading.Timer(tc, bytes_arr, 0, 100);

                Panel.Paint += Paint;
            }
            else return;
        }

        int timerCounter = 0;
        void TimersCaller(object obj)
        {
            var arr = ((byte[][])obj)[timerCounter++];
            ///end here
        }

        private void FramesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            WaveInEventArgs ev = new WaveInEventArgs(framesDictionary[framesComboBox.SelectedItem.ToString()], 1600);
            Panel.Paint += Paint;
            Data_Avaible(null, ev);
            Panel.Paint -= Paint;
        }
    }
}
