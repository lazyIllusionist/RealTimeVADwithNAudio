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

namespace Writer
{

    public partial class Form1 : Form
    {
        System.Threading.Timer timer;
        TimerCallback tm;

        int counter = 0;

        WaveIn waveIn;
        //Класс для записи в файл
        WaveFileWriter writer;
        //Имя файла для записи
        string outputFilename = "D:/Samples/Example1.wav";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler<WaveInEventArgs>(waveIn_DataAvailable), sender, e);
            }
            else
            {
                //Записываем данные из буфера в файл
                writer.WriteData(e.Buffer, 0, e.BytesRecorded);
            }
            progressBar1.Increment(1);
            if (counter++ == 98) button2.PerformClick();
        }
        //Завершаем запись
        void StopRecording()
        {
            waveIn.StopRecording();
        }
        //Окончание записи
        private void waveIn_RecordingStopped(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler(waveIn_RecordingStopped), sender, e);
            }
            else
            {
                waveIn.Dispose();
                waveIn = null;
                writer.Close();
                writer = null;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show("Start Recording");
                waveIn = new WaveIn();
                //Дефолтное устройство для записи (если оно имеется)
                //встроенный микрофон ноутбука имеет номер 0
                waveIn.DeviceNumber = 0;
                //Прикрепляем к событию DataAvailable обработчик, возникающий при наличии записываемых данных
                waveIn.DataAvailable += waveIn_DataAvailable;
                //Прикрепляем обработчик завершения записи
                waveIn.RecordingStopped += waveIn_RecordingStopped;
                //Формат wav-файла - принимает параметры - частоту дискретизации и количество каналов(здесь mono)
                waveIn.WaveFormat = new WaveFormat(8000, 1);
                //Инициализируем объект WaveFileWriter
                writer = new WaveFileWriter(outputFilename, waveIn.WaveFormat);

                //Начало записи
                tm = new TimerCallback(Stopper);
                waveIn.StartRecording();
                timer = new System.Threading.Timer(tm, null, 10000, Timeout.Infinite);
                panel1.BackColor = Color.Green;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (waveIn != null)
            {
                StopRecording();
            }
        }

        void Stopper(object obj)
        {
            //button2.PerformClick();
            panel1.BackColor = Color.Red;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            outputFilename = $"D:/Samples/{textBox1.Text}.wav";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(File.ReadAllBytes(outputFilename).Length.ToString());
        }
    }
}
