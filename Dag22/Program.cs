using System;
using System.IO;
using System.Linq;

namespace Dag22
{
    class Program
    {
        static void Main(string[] args)
        {
            var trees = File.ReadAllLines("Input\\forest.txt");

            var treeIndexes = trees[^1].Select((a, i) => a == '#' ? i : -1).Where(a => a != -1).ToArray();

            var totalHeight = 0;

            foreach (var index in treeIndexes)
            {
                var currentPart = 1;
                var treeHeight = 0;

                while (true && currentPart <= trees.Length)
                {
                    var currentTreePart = trees[^currentPart][index];

                    if (currentTreePart == '#')
                    {
                        treeHeight += 20;
                    }
                    else
                    {
                        break;
                    }

                    currentPart += 1;
                }

                totalHeight += treeHeight;
            }

            Console.WriteLine(totalHeight / 100.0 * 200);
        }
    }
}
