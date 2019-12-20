using System;
using System.Diagnostics;
using System.Linq;

namespace Dag20
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();
            var elves = new int[5];
            var clockwiseDirection = true;
            var currentElf = 0;

            for (int i = 1; i <= 1000740; i++)
            {
                elves[currentElf] += 1;

                var nextStep = i + 1;
                if (IsPrime(nextStep))
                {
                    var minValue = elves.Min();

                    if (elves.Where(a => a == minValue).Count() == 1)
                    {
                        currentElf = Array.IndexOf(elves, elves.Min());
                        continue;
                    }
                }

                if (nextStep % 28 == 0)
                {
                    clockwiseDirection = !clockwiseDirection;

                    if (clockwiseDirection)
                    {
                        currentElf += 1;
                    }
                    else
                    {
                        currentElf -= 1;
                    }

                    if (currentElf > 4)
                    {
                        currentElf = 0;
                    }

                    if (currentElf < 0)
                    {
                        currentElf = 4;
                    }

                    continue;
                }
                
                if (nextStep % 2 == 0)
                {
                    var nextElf = clockwiseDirection ? currentElf + 1 : currentElf - 1;

                    if (nextElf > 4)
                    {
                        nextElf = 0;
                    }
                    else if (nextElf < 0)
                    {
                        nextElf = 4;
                    }

                    if (elves[nextElf] == elves.Max() && elves.Where(a => a == elves.Max()).Count() == 1)
                    {
                        nextElf = clockwiseDirection ? nextElf + 1 : nextElf - 1;

                        if (nextElf > 4)
                        {
                            nextElf = 0;
                        }
                        else if (nextElf < 0)
                        {
                            nextElf = 4;
                        }

                        currentElf = nextElf;
                        continue;
                    }
                }

                if (nextStep % 7 == 0)
                {
                    currentElf = 4;
                    continue;
                }

                if (clockwiseDirection)
                {
                    currentElf += 1;
                }
                else
                {
                    currentElf -= 1;
                }

                if (currentElf > 4)
                {
                    currentElf = 0;
                }

                if (currentElf < 0)
                {
                    currentElf = 4;
                }
            }

            Console.WriteLine(elves.Max() - elves.Min());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
