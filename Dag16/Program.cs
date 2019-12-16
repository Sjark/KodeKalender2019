using System;
using System.IO;

namespace Dag16
{
    class Program
    {
        static void Main(string[] args)
        {
            var fjord = File.ReadAllLines("Input\\fjord.txt");

            var goingNorth = true;
            var bloc = (x: -1, y: -1);
            var crossings = 1;

            for (int y = 0; y < fjord.Length; y++)
            {
                for (int x = 0; x < fjord[y].Length; x++)
                {
                    if (fjord[y][x] == 'B')
                    {
                        bloc.x = x;
                        bloc.y = y;

                        break;
                    }
                }

                if (bloc.x != -1)
                {
                    break;
                }
            }

            while (bloc.x != fjord[0].Length)
            {
                if (goingNorth && bloc.y - 3 > 0 && fjord[bloc.y - 3][bloc.x] != '#')
                {
                    bloc.x += 1;
                    bloc.y -= 1;
                }
                else if (!goingNorth && bloc.y + 3 < fjord.Length - 1 && fjord[bloc.y + 3][bloc.x] != '#')
                {
                    bloc.x += 1;
                    bloc.y += 1;
                }
                else
                {
                    crossings += 1;
                    goingNorth = !goingNorth;
                    bloc.x += 1;
                }
            }

            Console.WriteLine(crossings);
        }
    }
}
