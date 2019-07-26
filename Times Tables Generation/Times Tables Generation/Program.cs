/*
 * This program will create a folder of visualized times-tables within your debug folder when
 * this program is run.  Please be sure that you have enough storage for these .jpgs to save.
 * 
 * Play around with the values and see what kind of images you can make.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Times_Tables_Generation
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists(@"timesTables") && !File.Exists("timesTables"))
            {
                Directory.CreateDirectory(@"timesTables");
            }

            CreateTable();
        }

        static void CreateTable()
        {
            List<int> primes = GenerateFibonnaci(); //GeneratePrimes(); /* Generate Primes is much larger than the fibonacci times tables */

            for (int n = 0; n < primes.Count; n++)
            {
                int width = 600;
                int height = 600;
                Bitmap b = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(b);
                g.FillRectangle(Brushes.DimGray, 0, 0, width, height);

                g.TranslateTransform(width / 2, height / 2);

                int points = 360;
                float times = primes[n];
                float inc = 360 / points;
                Console.WriteLine(inc.ToString());
                float angle = 0;
                float radius = height / 2.3f;
                int i = 0;

                while (angle <= 360)
                {
                    float x = -(float)Math.Cos(angle * (Math.PI / 180)) * radius;
                    Console.WriteLine("X " + x);
                    float y = -(float)Math.Sin(angle * (Math.PI / 180)) * radius;
                    Console.WriteLine("Y:" + y);

                    float num = (float)Math.Floor(i * times);

                    float nextX = (float)Math.Cos(inc * num * (Math.PI / 180)) * radius;
                    float nextY = (float)Math.Sin(inc * num * (Math.PI / 180)) * radius;

                    //Pen matrix = new Pen(Color.FromArgb(54, 186, 1));
                    g.DrawLine(Pens.White, new Point((int)x, (int)y), new Point((int)nextX, (int)nextY));
                    angle += inc;
                    i++;
                }

                b.Save(@"timesTables\TableGen" + primes[n] +".jpg");
            }
        }

        static List<int> GenerateFibonnaci()
        {
            List<int> newList = new List<int>();
            newList.Add(1);

            int working = 1;
            for (int i = 2; i < 40; i++)
            {
                newList.Add(working);
                working = newList[i - 2] + newList[i - 1];
                Console.WriteLine(working);
            }

            return newList;
        }

        static List<int> GeneratePrimes()
        {
            List<int> newList = new List<int>();

            int total = 0;
            int num = 0;

            while (total <= 1000)
            {
                if(isPrime(num))
                {
                    newList.Add(num);

                    total++;
                }

                num++;
            }

            return newList;
        }

        static bool isPrime(int n)
        {
            if (n == 1 || n == 0)
                return false;

            for(int i = n - 1; i >= 2; i--)
                if(n % i == 0)
                    return false;

            return true;
        }
    }
}
