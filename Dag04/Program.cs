using System;
using System.IO;
using System.Linq;

namespace Dag04
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input\\coords.csv");

            var coords = input.Skip(1)
                .Select(a =>
                {
                    var coord = a.Split(',');

                    return (x: int.Parse(coord[0]), y: int.Parse(coord[1]));
                }).ToList();

            var pos = (x: 0, y: 0);
            var kvadratahara = new int[1000, 1000];
            var totalMin = 0;

            foreach (var coord in coords)
            {
                var xMovement = coord.x - pos.x;
                var yMovement = coord.y - pos.y;

                if (xMovement > 0)
                {
                    for (int i = 0; i < xMovement; i++)
                    {
                        pos.x += 1;
                        kvadratahara[pos.x, pos.y] += 1;
                        totalMin += kvadratahara[pos.x, pos.y];
                    }
                }
                else if (xMovement < 0)
                {
                    for (int i = 0; i > xMovement; i--)
                    {
                        pos.x -= 1;
                        kvadratahara[pos.x, pos.y] += 1;
                        totalMin += kvadratahara[pos.x, pos.y];
                    }
                }

                if (yMovement > 0)
                {
                    for (int i = 0; i < yMovement; i++)
                    {
                        pos.y += 1;
                        kvadratahara[pos.x, pos.y] += 1;
                        totalMin += kvadratahara[pos.x, pos.y];
                    }
                }
                else if (yMovement < 0)
                {
                    for (int i = 0; i > yMovement; i--)
                    {
                        pos.y -= 1;
                        kvadratahara[pos.x, pos.y] += 1;
                        totalMin += kvadratahara[pos.x, pos.y];
                    }
                }
            }

            Console.WriteLine(totalMin);
        }
    }
}
