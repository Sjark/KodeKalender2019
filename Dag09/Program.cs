using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Dag09
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var input = File.ReadAllLines("Input\\krampus.txt")
                .Select(a => long.Parse(a));

            var krampusNumbers = new List<long>();

            foreach (var num in input)
            {
                var numString = (num * num).ToString();

                for (int i = 1; i < numString.Length; i++)
                {
                    var num1 = long.Parse(numString[..i]);
                    var num2 = long.Parse(numString[i..]);

                    if (num1 != 0 && num2 != 0 && (num1 + num2) == num)
                    {
                        krampusNumbers.Add(num);
                        break;
                    }
                }
            }

            Console.WriteLine(krampusNumbers.Sum());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}
