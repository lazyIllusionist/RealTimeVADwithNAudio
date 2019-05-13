using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace RealTimeVAD.Detectors
{
    public class ShortTimeEnergyDetector : AbstractDetector
    {
        double barrier = 0.08; //Get by empiric
        int framesWithVoise;

        byte[][] _buffer;

        public bool Decoding()
        {
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
                    if (Decoder(i, barrier))
                        framesWithVoise++;

                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        bool Decoder(byte[] _buffer, double barrier)
        {
            double Sum2 = 0;
            bool Tr = false;

            for (int index = 0; index < _buffer.Length; index += 2)
            {
                double Tmp = (short)((_buffer[index + 1] << 8) | _buffer[index]);
                Tmp /= 32768.0;
                Sum2 += Tmp * Tmp;
                if (Tmp > barrier)
                    Tr = true; 
            }
            Sum2 /= _buffer.Length / 2;
            if (Tr || Sum2 > barrier)
                return true;
            else
                return false;
        }

        public new bool VoiceIsPresent
        {
            get
            {
                this.Decoding();
                this.AddResults(framesWithVoise);
                return result;
            }
        }
    }
}
