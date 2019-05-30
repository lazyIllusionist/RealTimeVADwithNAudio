using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace RealTimeVAD.Detectors
{
    public class ShortTimeZeroCrossDetector : AbstractDetector
    {
        int barrier = 30;
        int framesWithVoise;

        public List<ZeroCrossCount> arr;

        byte[][] _buffer;

        public bool Decoding()
        {
            arr = new List<ZeroCrossCount>();

            framesWithVoise = 0;
            try
            {
                int counter = 0;
                /*
                 * Break 100ms frame to ten 10ms frames
                 * Multiply by 2 because information about 1 sempl writes in 2 byte
                 */
                _buffer = fraim.Buffer.GroupBy(_ => counter++ / (fraimSampleRate / 100 * 2)).Select(elem => elem.ToArray()).ToArray();

                foreach (var i in _buffer)
                    if (ZeroCrossDecoder(i, barrier))
                        framesWithVoise++;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

       /* bool ZeroCrossDecoder(WaveInEventArgs e)
        {
            int necessaryZeroCrossCount = 150 * 2; //96 : 81

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
        }*/

        bool ZeroCrossDecoder(byte[] _buffer, int crossBarrier)
        {
            bool _result = false;

            int sum = 0;

            short first = (short)((_buffer[1] << 8) | _buffer[0]);

            for (int index = 2; index < _buffer.Length; index += 2)
            {
                short Tmp = (short)((_buffer[index + 1] << 8) | _buffer[index]);
                sum += Math.Abs(CountByZero(Tmp) - CountByZero(first));
                first = Tmp;
            }
            if (sum/2 >= crossBarrier) _result = true;
            arr.Add(new ZeroCrossCount { count = sum/2, result = _result });

            return _result;
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
                this.Decoding();
                this.AddResults(framesWithVoise);
                return result;
            }
        }
    }

    public struct ZeroCrossCount
    {
        public int count;
        public bool result;
    }
}
