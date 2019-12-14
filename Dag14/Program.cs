using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Dag14
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();
            var alphabet = new byte[]
            {
                2, 3, 5, 7, 11
            };

            var sequenceLength = 217532235;
            var sequence = new byte[sequenceLength];

            for (int y = 0; y < alphabet[0]; y++)
            {
                sequence[y] = alphabet[0];
            }

            int i = 1;
            int pos = 1;
            int sumOf7 = 0;
            byte curChar = 1;

            while (pos < sequenceLength)
            {
                var currentCharacter = alphabet[curChar];

                if (curChar == 4)
                {
                    curChar = 0;
                }
                else
                {
                    curChar += 1;
                }


                for (int y = 0; y < sequence[i] && pos < sequenceLength; y++)
                {
                    sequence[pos] = currentCharacter;

                    if (currentCharacter == 7)
                    {
                        sumOf7 += 7;
                    }

                    pos += 1;
                }

                i++;
            }

            stopwatch.Stop();
            Console.WriteLine(sumOf7);
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}
