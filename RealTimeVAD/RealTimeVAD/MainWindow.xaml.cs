using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NAudio;
using NAudio.Wave;

namespace RealTimeVAD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool ind = false;
        WaveIn waveIn;

        public MainWindow()
        {
            InitializeComponent();
            Initialize();
            StartButton.Content = "Press to start";
            StartButton.Click += Click;
        }

        bool Initialize()
        {
            try
            {
                Detectors.ShortTimeEnergyDetector sted = new Detectors.ShortTimeEnergyDetector
                {
                    fraimSampleRate = 8000,
                    percentOfSucsess = 30
                };

                waveIn = new WaveIn();
                waveIn.DeviceNumber = 0;
                waveIn.DataAvailable += (object sender, WaveInEventArgs e) => 
                {
                    sted.fraim = e;
                    if (sted.VoiceIsPresent)
                    {
                        StartButton.Background = Brushes.Green;
                        StartButton.Foreground = Brushes.Black;
                    }
                    else
                    {
                        StartButton.Background = Brushes.Red;
                        StartButton.Foreground = Brushes.White;
                    }
                };
                waveIn.RecordingStopped += waveIn_RecordingStopped;
                waveIn.WaveFormat = new WaveFormat(8000, 1);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        void Click(object obj, RoutedEventArgs e)
        {
            try
            {
                if (ind)
                {
                    waveIn.StopRecording();
                    StartButton.Background = Brushes.White;
                    StartButton.Foreground = Brushes.Black;
                    StartButton.Content = "Press to start";
                    ind = false;
                }
                else
                {
                    waveIn.StartRecording();
                    StartButton.Content = "If this button:\ngreen - something is speaking\nred - no voice outthere";
                    ind = true;
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private void waveIn_RecordingStopped(object sender, EventArgs e)
        {
                waveIn.Dispose();
                waveIn = null;
        }
    }

}
