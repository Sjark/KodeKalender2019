using System;
using System.IO;

namespace Dag11
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("Input\\terreng.txt");

            var mountain = 1;
            var ice = 1;
            var speed = 10703437;
            var km = 0;

            foreach (var terrain in input)
            {
                km += 1;
                switch (terrain)
                {
                    case 'G':
                        speed -= 27;
                        break;
                    case 'I':
                        speed += (12 * ice);
                        ice += 1;
                        break;
                    case 'A':
                        speed -= 59;
                        break;
                    case 'S':
                        speed -= 212;
                        break;
                    case 'F':
                        if (mountain == 1)
                        {
                            speed -= 70;
                            mountain += 1;
                        }
                        else
                        {
                            speed += 35;
                            mountain = 1;
                        }
                        break;
                }

                if (terrain != 'I')
                {
                    ice = 1;
                }

                if (speed <= 0)
                {
                    break;
                }
            }

            Console.WriteLine(km);
        }
    }
}
