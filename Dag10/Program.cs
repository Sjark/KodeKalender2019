using System;
using System.IO;

namespace Dag10
{
    class Program
    {
        private static DateTime _startDate = DateTime.Parse("2017-12-31");

        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Input\\logg.txt");

            var tannkrem = 0;
            var sjampo = 0;
            var toalettpapir = 0;
            var sjampoSondag = 0;
            var toalettpapirOnsdag = 0;
            var day = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 4 == 0)
                {
                    day += 1;
                }
                else
                {
                    var logg = input[i].Trim().Substring(2).Split(' ');
                    var num = int.Parse(logg[0]);
                    var type = logg[^1];

                    if (type == "tannkrem")
                    {
                        tannkrem += num;
                    }
                    else if (type == "sjampo")
                    {
                        sjampo += num;

                        if (IsDayOfWeek(day, DayOfWeek.Sunday)) {
                            sjampoSondag += num;
                        }
                    }
                    else
                    {
                        toalettpapir += num;

                        if (IsDayOfWeek(day, DayOfWeek.Wednesday))
                        {
                            toalettpapirOnsdag += num;
                        }
                    }
                }
            }

            var tannkremFlasker = tannkrem / 125;
            var sjampoFlasker = sjampo / 300;
            var toalettpapirRuller = toalettpapir / 25;


            Console.WriteLine(sjampoSondag * toalettpapirOnsdag * tannkremFlasker * sjampoFlasker * toalettpapirRuller);
        }

        private static bool IsDayOfWeek(int dayNumber, DayOfWeek day)
        {
            var date = _startDate.AddDays(dayNumber);

            return date.DayOfWeek == day;
        }
    }
}
