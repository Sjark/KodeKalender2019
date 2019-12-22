using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Dag22
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
                if (Solve() != 6537400) Console.WriteLine("Error");

            Console.WriteLine(timer.ElapsedMilliseconds);
        }

        private static int Solve()
        {
            var trees = File.ReadAllLines("Input\\forest.txt");

            var totalHeight = 0;

            for (int i = 0; i < trees[^1].Length; i++)
            {
                if (trees[^1][i] != '#')
                {
                    continue;
                }

                for (int y = 1; y <= trees.Length; y++)
                {
                    if (trees[^y][i] == ' ')
                    {
                        break;
                    }

                    totalHeight += 20;
                }
            }

            return (int)(totalHeight / 100.0 * 200);
        }
    }
}
