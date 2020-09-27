using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProc
{
    class Program
    {
        static void Main(string[] args)
        {
            string path, format;
            if (args.Length == 0)
            {
                Console.WriteLine("Введите путь к файлу:");
                path = Console.ReadLine();
            }
            else path = args[0];

            try
            {
                var inputImg = new Bitmap(Image.FromFile(path));
                format = path.Substring(path.Length - 3);
                if (!(format == "jpg" || format == "png" || format == "bmp"))
                {
                    throw new Exception("неверный формат файла");
                }
                var outputImg = ImageHandler.ChangeImageColor(inputImg);
                ImageHandler.SaveImage(outputImg, path, format);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Ошибка: неверный путь к файлу\n" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }
    }
}
