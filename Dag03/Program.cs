using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace Dag03
{
    class Program
    {
        static void Main(string[] args)
        {
            var imgText = File.ReadAllText("Input\\img.txt");
            for (int i = 1; i < 2000; i++)
            {
                for (int y = 2000; y > 0; y--)
                {
                    if (y * i == imgText.Length)
                    {
                        CreateImage(imgText, i, y, $"image{i}x{y}");
                    }
                }
            }
        }

        private static void CreateImage(string imgText, int imgSizeX, int imgSizeY, string imgName)
        {
            var image = new Bitmap(imgSizeX, imgSizeY);

            var posX = 0;
            var posY = 0;

            foreach (var color in imgText)
            {
                if (color == '0')
                {
                    image.SetPixel(posX, posY, Color.Black);
                }
                else
                {
                    image.SetPixel(posX, posY, Color.White);
                }

                posX += 1;

                if (posX == imgSizeX)
                {
                    posX = 0;
                    posY += 1;
                }
            }

            var outputPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            image.Save($"{outputPath}\\{imgName}.jpg", ImageFormat.Jpeg);
        }
    }
}
