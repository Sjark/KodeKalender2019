using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Dag24
{
    class Program
    {
        static void Main(string[] args)
        {
            var trips = File.ReadAllText("Input\\turer.txt")
                .Split("---\n")
                .Select(a => a.Split("\n").Where(b => !string.IsNullOrWhiteSpace(b)).Select(b => b.Split(',').Select(c => int.Parse(c)).ToArray()).ToArray())
                .ToArray();

            for (int i = 0; i < trips.Length; i++)
            {
                var trip = trips[i];
                var xMax = trip.Max(a => a[0]);
                var yMax = trip.Max(a => a[1]);
                var sb = new StringBuilder();

                for (int y = yMax; y >= 0; y--)
                {
                    for (int x = 0; x <= xMax; x++)
                    {
                        if (trip.Any(a => a[0] == x && a[1] == y))
                        {
                            sb.Append("x");
                        }
                        else
                        {
                            sb.Append(".");
                        }
                    }

                    sb.AppendLine();
                }

                File.WriteAllText($"{i}.txt", sb.ToString());
            }
        }
    }
}
