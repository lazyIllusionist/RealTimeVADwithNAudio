using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using System.Numerics;

namespace RealTimeVAD.Detectors.FFTDetector
{
    class FFTAdapter : AbstractDetector
    {
        Complex[] _

        public FFTAdapter()
        {
        }

        public FFTAdapter(WaveInEventArgs fraim) : base(fraim)
        {
        }

        public FFTAdapter(WaveInEventArgs fraim, int percentOfSucsess) : base(fraim, percentOfSucsess)
        {
        }

        public FFTAdapter(WaveInEventArgs fraim, int fraimSampleRate, int percentOfSucsess) : base(fraim, fraimSampleRate, percentOfSucsess)
        {
        }

        private Complex[] Adapt(short[] _frameEnergyArray)
        {
            Complex[] frameSpectrumArray;

        }
    }
}
