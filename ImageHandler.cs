using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProc
{
    class ImageHandler
    {
        public static Bitmap ChangeImageColor(Bitmap originalImg)
        {
            var newImage = new Bitmap(originalImg.Width, originalImg.Height);
            for (int i = 0; i < originalImg.Width; i++)
            {
                for (int j = 0; j < originalImg.Height; j++)
                {
                    var origColor = originalImg.GetPixel(i, j);
                    var newColorValue = ((int)origColor.R + (int)origColor.G + (int)origColor.B) / 3;
                    var newColor = Color.FromArgb(newColorValue, newColorValue, newColorValue);
                    newImage.SetPixel(i, j, newColor);
                }
            }
            return newImage;
        }

        public static void SaveImage(Bitmap image, string path, string format)
        {
            string newPath = path.Remove(path.Length - 4) + "-result." + format;
            image.Save(newPath);
        }
    }
}
