using System;
using System.Linq;

namespace Dag17
{
    class Program
    {
        static void Main(string[] args)
        {
            var squareNumbers = 0;

            foreach (var triangularNumber in Enumerable.Range(0, 1000000).Select(a => (long)a * (a + 1) / 2))
            {
                if (Math.Abs(Math.Sqrt(triangularNumber) % 1) <= (double.Epsilon * 100))
                {
                    squareNumbers += 1;
                    continue;
                }

                var numberString = triangularNumber.ToString();

                for (int i = 0; i < numberString.Length; i++)
                {
                    numberString = new string(numberString[^1] + numberString[..^1]);
                    if (Math.Abs(Math.Sqrt(long.Parse(numberString)) % 1) <= (double.Epsilon * 100))
                    {
                        squareNumbers += 1;
                        break;
                    }
                }
            }

            Console.WriteLine(squareNumbers);
        }
    }
}
