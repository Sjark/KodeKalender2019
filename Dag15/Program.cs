using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Dag15
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();
            var input = File.ReadAllLines("Input\\MODEL.CSV");

            var mesh = new List<Triangle>();

            foreach (var line in input)
            {
                var cords = line.Split(',')
                    .Select(a => decimal.Parse(a, NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign))
                    .ToArray();

                mesh.Add(new Triangle(new Vector3(cords[0], cords[1], cords[2]), new Vector3(cords[3], cords[4], cords[5]), new Vector3(cords[6], cords[7], cords[8])));
            }

            Console.WriteLine(Math.Round(VolumeOfMesh(mesh) / 1000, 3));
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        public static decimal SignedVolumeOfTriangle(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            var v321 = p3.X * p2.Y * p1.Z;
            var v231 = p2.X * p3.Y * p1.Z;
            var v312 = p3.X * p1.Y * p2.Z;
            var v132 = p1.X * p3.Y * p2.Z;
            var v213 = p2.X * p1.Y * p3.Z;
            var v123 = p1.X * p2.Y * p3.Z;
            return (1.0m / 6.0m) * (-v321 + v231 + v312 - v132 - v213 + v123);
        }

        public static decimal VolumeOfMesh(List<Triangle> mesh)
        {
            return Math.Abs(mesh.Select(a => SignedVolumeOfTriangle(a.P1, a.P2, a.P3)).Sum());
        }
    }

    public class Triangle
    {
        public Triangle(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }

        public Vector3 P1 { get; set; }
        public Vector3 P2 { get; set; }
        public Vector3 P3 { get; set; }
    }


    public class Vector3
    {
        public Vector3(decimal x, decimal y, decimal z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
    }
}
