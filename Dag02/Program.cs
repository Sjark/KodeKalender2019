using System;
using System.IO;

namespace Dag02
{
    class Program
    {
        static void Main(string[] args)
        {
            var world = File.ReadAllLines("Input\\world.txt");
            var water = 0;

            foreach (var line in world)
            {
                var firstRock = false;
                var air = 0;

                foreach (var spot in line)
                {
                    if (firstRock && spot == ' ')
                    {
                        air += 1;
                    }
                    else if (spot == '#')
                    {
                        firstRock = true;
                        water += air;
                        air = 0;
                    }
                }
            }

            Console.WriteLine(water);
        }
    }
}
