using System;
using System.Collections.Generic;
using System.Linq;

namespace Dag14
{
    class Program
    {
        static void Main(string[] args)
        {
            var alphabet = new List<int>
            {
                2, 3, 5, 7, 11
            };

            var sequenceLength = 217532235;
            var sequence = new int[217532235];

            for (int y = 0; y < alphabet[0]; y++)
            {
                sequence[y] = alphabet[0];
            }

            var i = 1;
            var pos = 1;

            while (pos < sequenceLength)
            {
                var currentCharacter = alphabet[i % alphabet.Count];

                for (int y = 0; y < sequence[i]; y++)
                {
                    sequence[pos] = currentCharacter;

                    pos += 1;

                    if (pos == sequenceLength)
                    {
                        break;
                    }
                }

                i++;
            }

            Console.WriteLine(sequence.Where(a => a == 7).Sum());
        }
    }
}
