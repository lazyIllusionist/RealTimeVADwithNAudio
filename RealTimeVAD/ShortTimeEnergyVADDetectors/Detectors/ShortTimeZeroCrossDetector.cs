using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace RealTimeVAD.Detectors
{
    class ShortTimeZeroCrossDetector : AbstractDetector
    {
        
        bool ZeroCrossDecoder(WaveInEventArgs e)
        {
            int necessaryZeroCrossCount = 96 * 2; //96 : 81

            int sum = 0;

            short first = (short)((e.Buffer[1] << 8) | e.Buffer[0]);
            for (int index = 2; index < e.Buffer.Length; index += 4)
            {
                short Tmp = (short)((e.Buffer[index + 1] << 8) | e.Buffer[index]);
                sum += Math.Abs(CountByZero(Tmp) - CountByZero(first));
                first = Tmp;
            }

            Console.WriteLine(sum);

            result = sum >= necessaryZeroCrossCount;

            return sum >= necessaryZeroCrossCount;
        }

        private int CountByZero(short tmp)
        {
            if (tmp >= 1)
                return 1;
            else
                return -1;
        }

        public override bool VoiceIsPresent
        {
            get
            {
                ZeroCrossDecoder(fraim);
                return result;
            }
        }
    }
}
