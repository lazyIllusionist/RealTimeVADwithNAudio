﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace RealTimeVAD.Detectors
{
    abstract class AbstractDetector : IDetector
    {
        WaveInEventArgs _fraim;
        public WaveInEventArgs fraim //100ms .wav sound freim
        {
            get { return _fraim; }
            set
            {
                result = false;
                _fraim = value ?? throw new ArgumentNullException();
            }
        }
        int _fraimSampleRate;
        public int fraimSampleRate
        {
            get { return _fraimSampleRate; }
            set
            {
                result = false;
                _fraimSampleRate = value;
            }
        }
        int _percentOfSucsess;
        public int percentOfSucsess
        {
            get { return _percentOfSucsess; }
            set
            {
                result = false;
                _percentOfSucsess = value;
            }
        }

        //protected bool ind = false;
        protected bool result;

        public AbstractDetector(WaveInEventArgs fraim, int fraimSampleRate, int percentOfSucsess)
        {
            if (fraimSampleRate <= 0)
                throw new ArgumentOutOfRangeException();
            if (percentOfSucsess < 0 || percentOfSucsess > 100)
                throw new ArgumentOutOfRangeException();

            this.fraim = fraim ?? throw new ArgumentNullException();
            this.fraimSampleRate = fraimSampleRate;
            this.percentOfSucsess = percentOfSucsess;
        }
        public AbstractDetector(WaveInEventArgs fraim, int percentOfSucsess) : this(fraim, 8000, percentOfSucsess) { }
        public AbstractDetector(WaveInEventArgs fraim) : this(fraim, 8000, 30) { }
        public AbstractDetector()
        {
            fraimSampleRate = 8000;
            percentOfSucsess = 30;
        }

        protected void AddResults(int count)
        {
            if (count >= percentOfSucsess / 10)
                result = true;
        }

        public bool VoiceIsPresent => result;
    }
}
