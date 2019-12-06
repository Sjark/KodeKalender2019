using System;
using System.Drawing;
using System.IO;

namespace Dag06
{
    class Program
    {
        static void Main(string[] args)
        {
            using var image = new Bitmap("Input//mush.png");

            var pixel = image.GetPixel(0, 0);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (x == 0 && y == 0)
                    {
                        break;
                    }

                    var newPixel = image.GetPixel(x, y);
                    var newR = pixel.R ^ newPixel.R;
                    var newG = pixel.G ^ newPixel.G;
                    var newB = pixel.B ^ newPixel.B;

                    image.SetPixel(x, y, Color.FromArgb(newR, newG, newB));

                    pixel = newPixel;
                }
            }

            image.Save("output.png");
        }
    }
}
