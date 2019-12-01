using System;
using System.IO;
using System.Linq;

namespace Dag01
{
    class Program
    {
        static void Main(string[] args)
        {
            var sheeps = File.ReadAllText("Input\\sau.txt").Split(',')
                .Select(a => int.Parse(a.Trim()))
                .ToList();

            var dragonSize = 50;
            var day = 0;
            var extraSheeps = 0;
            var daysInRowWithoutFood = 0;

            while (daysInRowWithoutFood != 5)
            {
                var sheepsAvailable = sheeps[day] + extraSheeps;
                extraSheeps = sheepsAvailable - dragonSize;

                if (extraSheeps >= 0)
                {
                    dragonSize += 1;
                    daysInRowWithoutFood = 0;
                }
                else
                {
                    dragonSize -= 1;
                    daysInRowWithoutFood++;
                    extraSheeps = 0;

                    if (daysInRowWithoutFood == 5)
                    {
                        break;
                    }
                }

                day++;
            }

            Console.WriteLine($"Day: {day}");
        }
    }
}
