using System;

namespace Dag07
{
    class Program
    {
        static void Main(string[] args)
        {
            long x = 7;

            for (long y = 2; y <= 27644436; y++)
            {
                long b = y * x;
                long r = b % 27644437;

                if (r == 1)
                {
                    long z = 5897 * y;
                    long code = z % 27644437;

                    Console.WriteLine($"Day: {x} code: {code}");
                    break;
                }
            }
        }
    }
}
