using System;
using System.Collections.Generic;
using System.Linq;

namespace Dag12
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;
            for (int i = 1000; i < 10000; i++)
            {
                var iterations = 0;
                if (i % 1111 == 0)
                {
                    continue;
                }

                var number = i;
                while (number != 6174)
                {
                    var numberString = number.ToString();
                    while (numberString.Length < 4)
                    {
                        numberString = "0" + numberString;
                    }
                    var num1 = int.Parse(new string(numberString.OrderBy(a => a).ToArray()));
                    var num2 = int.Parse(new string(numberString.OrderByDescending(a => a).ToArray()));

                    if (num2 > num1)
                    {
                        number = num2 - num1;
                    }
                    else
                    {
                        number = num1 - num2;
                    }

                    iterations += 1;
                }

                if (iterations == 7)
                {
                    count += 1;
                }
            }

            Console.WriteLine(count);
        }
    }
}
