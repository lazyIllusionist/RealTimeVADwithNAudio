﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeVAD.Detectors
{
    interface IDetector
    {
        bool VoiceIsPresent { get; }
    }
}
