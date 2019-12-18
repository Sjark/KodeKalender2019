using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Dag18
{
    class Program
    {
        private static string[] _manNames;
        private static string[] _womanNames;
        private static string[] _firstSurnames;
        private static string[] _lastSurnames;

        static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();
            var input = File.ReadAllLines("Input\\names.txt");
            var currentIndex = Array.IndexOf(input, "---");
            _manNames = input[..currentIndex];
            var lastIndex = currentIndex + 1;
            currentIndex = Array.IndexOf(input, "---", lastIndex + 1);
            _womanNames = input[lastIndex..currentIndex];
            lastIndex = currentIndex + 1;
            currentIndex = Array.IndexOf(input, "---", lastIndex + 1);
            _firstSurnames = input[lastIndex..currentIndex];
            lastIndex = currentIndex + 1;
            currentIndex = Array.IndexOf(input, "---", lastIndex + 1);
            _lastSurnames = input[lastIndex..];

            Console.WriteLine(File.ReadAllLines("Input\\employees.csv")
                .Skip(1)
                .Select(a => a.Split(','))
                .Select(a => GetStarWarsName(a[0], a[1], a[2][0]))
                .GroupBy(a => a)
                .Select(a => (name: a.Key, count: a.Count()))
                .OrderByDescending(a => a.count)
                .Select(a => a.name)
                .First());

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        private static string GetStarWarsName(string firstName, string lastName, char gender)
        {
            var name = string.Empty;
            var asciiSum = firstName.Select(a => (int)a).Sum();

            if (gender == 'M')
            {
                name += _manNames[asciiSum % _manNames.Length];
            }
            else
            {
                name += _womanNames[asciiSum % _womanNames.Length];
            }

            var lastNameMiddle = (int)((lastName.Length / 2.0) + 0.5);
            var firstLastNameSum = lastName[0..lastNameMiddle]
                .Select(a => char.ToLowerInvariant(a) - 'a' + 1)
                .Where(a => a > 0 && a <= 26)
                .Sum();

            name += " " + _firstSurnames[firstLastNameSum % _firstSurnames.Length];

            var lastNameLastPartProduct = lastName[lastNameMiddle..]
                .Select(a => (long)a)
                .Aggregate((result, item) => result * item);

            if (gender == 'M')
            {
                lastNameLastPartProduct *= firstName.Length;
            }
            else
            {
                lastNameLastPartProduct *= (firstName.Length + lastName.Length);
            }

            name += _lastSurnames[long.Parse(new string(lastNameLastPartProduct
                .ToString()
                .OrderByDescending(a => a)
                .ToArray())) % _lastSurnames.Length];


            return name;
        }
    }
}
