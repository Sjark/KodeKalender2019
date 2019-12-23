using System;
using System.Linq;
using System.Threading;

namespace Dag23
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfHarshadprimtall = 0;
            Enumerable.Range(1, 98765432).AsParallel()
                .ForAll(i =>
                {
                    var sumOfDigits = i.ToString().Select(a => a - '0').Sum();

                    if (i % sumOfDigits == 0 && IsPrime(sumOfDigits))
                    {
                        Interlocked.Increment(ref numberOfHarshadprimtall);
                    }
                });

            Console.WriteLine(numberOfHarshadprimtall);
        }

        static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
