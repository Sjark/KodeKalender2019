using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dag08
{
    class Program
    {
        static void Main(string[] args)
        {
            var wheels = File.ReadAllLines("Input\\wheels.txt")
                .Select(a => a.Split(':')
                    .Last()
                    .Split(',')
                    .Select(a => a.Trim())
                    .ToList()
                ).ToList();

            for (int y = 1; y <= 10; y++)
            {
                var rotations = Enumerable.Repeat(0, 10)
                    .ToList();
                var pot = y;
                var machineOn = true;

                while (machineOn)
                {
                    var currentWheel = Math.Abs(pot % 10);
                    var rotation = rotations[currentWheel] % wheels[currentWheel].Count;
                    var currentOperation = wheels[currentWheel][rotation];
                    rotations[currentWheel] += 1;

                    switch (currentOperation)
                    {
                        case "PLUSS4":
                            pot += 4;
                            break;
                        case "PLUSS101":
                            pot += 101;
                            break;
                        case "MINUS9":
                            pot -= 9;
                            break;
                        case "MINUS1":
                            pot -= 1;
                            break;
                        case "REVERSERSIFFER":
                            var potArray = pot.ToString().ToCharArray();

                            if (potArray[0] == '-')
                            {
                                var potArray2 = potArray[1..];
                                Array.Reverse(potArray2);
                                pot = int.Parse("-" + new string(potArray2));
                            }
                            else
                            {
                                Array.Reverse(potArray);
                                pot = int.Parse(new string(potArray));
                            }
                            break;
                        case "OPP7":
                            while (Math.Abs(pot % 10) != 7)
                            {
                                pot += 1;
                            }
                            break;
                        case "GANGEMSD":
                            var gange = Math.Abs(pot);

                            while (gange >= 10)
                            {
                                gange /= 10;
                            }

                            pot *= gange;
                            break;
                        case "DELEMSD":
                            var dele = Math.Abs(pot);

                            while (dele >= 10)
                            {
                                dele /= 10;
                            }

                            pot = (int)Math.Floor(pot / (double)dele);
                            break;
                        case "PLUSS1TILPAR":
                            pot = int.Parse(new string(pot
                                .ToString()
                                .ToCharArray()
                                .Select(a =>
                                {
                                    if (a == '-' || (a - '0') % 2 == 1)
                                    {
                                        return a;
                                    }
                                    else
                                    {
                                        return (char)(a - '0' + 49);
                                    }
                                }).ToArray()));
                            break;
                        case "TREKK1FRAODDE":
                            pot = int.Parse(new string(pot
                                .ToString()
                                .ToCharArray()
                                .Select(a =>
                                {
                                    if (a == '-' || (a - '0') % 2 == 0)
                                    {
                                        return a;
                                    }
                                    else
                                    {
                                        return (char)(a - '0' + 47);
                                    }
                                }).ToArray()));
                            break;
                        case "ROTERPAR":
                            for (int i = 0; i < rotations.Count; i += 2)
                            {
                                rotations[i] += 1;
                            }
                            break;
                        case "ROTERODDE":
                            for (int i = 1; i < rotations.Count; i += 2)
                            {
                                rotations[i] += 1;
                            }
                            break;
                        case "ROTERALLE":
                            for (int i = 0; i < rotations.Count; i++)
                            {
                                rotations[i] += 1;
                            }
                            break;
                        case "STOPP":
                            machineOn = false;
                            break;
                        default:
                            break;
                    }
                }

                Console.WriteLine($"Mynt: {y} Pot: {pot}"); 
            }
        }
    }
}
