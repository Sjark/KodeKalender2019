using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dag21
{
    class Program
    {
        static void Main(string[] args)
        {
            var generations = File.ReadAllLines("Input\\generations.txt")
                .Select((a, i) => 
                    a.Split(';')
                        .Select((b, j) => i == 0 && j % 2 == 1 ? new HashSet<int> { j } : new HashSet<int>())
                        .ToList()
                ).ToList();

            var elves = File.ReadAllLines("Input\\generations.txt")
                .Select(a => a.Split(';').Select(b => b.Split(',').Select(c => int.Parse(c)).ToArray()).ToArray()).ToArray();

            var numOddElfs = generations[0].Count / 2;

            for (int i = 0; i < elves[0].Length - 1; i++)
            {
                for (int j = 0; j < elves[i].Length; j++)
                {
                    var parents = elves[i][j];
                    generations[i + 1][parents[0]].UnionWith(generations[i][j]);
                    generations[i + 1][parents[1]].UnionWith(generations[i][j]);
                }

                for (int j = 0; j < generations[i + 1].Count; j++)
                {
                    if (generations[i + 1][j].Count == numOddElfs)
                    {
                        Console.WriteLine($"{i + 1}:{j}");
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}
