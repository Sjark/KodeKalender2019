using System;
using System.Text;

namespace Dag05
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "tMlsioaplnKlflgiruKanliaebeLlkslikkpnerikTasatamkDpsdakeraBeIdaegptnuaKtmteorpuTaTtbtsesOHXxonibmksekaaoaKtrssegnveinRedlkkkroeekVtkekymmlooLnanoKtlstoepHrpeutdynfSneloietbol";

            for (int i = 0; i < input.Length / 6; i++)
            {
                var start = i * 3;
                var end = start + 3;

                var preString = input[..start];
                var postString = input[^start..];
                var swap1 = input[start..end];
                var swap2 = input[^end..^start];
                var midString = input[end..^end];

                input = preString + swap2 + midString + swap1 + postString;
            }

            for (int i = 0; i < input.Length / 2; i++)
            {
                var start = i * 2;
                var end = start + 1;
                var preString = input[..start];
                var postString = input[(end + 1)..];
                var swap1 = input[start];
                var swap2 = input[end];

                input = preString + swap2 + swap1 + postString;
            }

            input = input[(input.Length / 2)..] + input[0..(input.Length / 2)];

            Console.WriteLine(input);
        }
    }
}
