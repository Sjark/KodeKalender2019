using System;
using System.Linq;

namespace Dag17
{
    class Program
    {
        static void Main(string[] args)
        {
            var range = Enumerable.Range(0, 1000000)
                .Select(a => a * (a + 1) / 2)
                .ToArray();

            Console.WriteLine(range[5]);
        }
    }
}
