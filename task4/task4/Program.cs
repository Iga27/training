using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointLibrary;
using TriangleLibrary;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(1, 1);

            Console.WriteLine(p1.X + " " + p1.Y);

            //Triangle rec = new Triangle(new Point(0, 0), new Point(0, 0), new Point(0, 0));
            Triangle rec = new Triangle(new Point(1, 1), new Point(-2, 4), new Point(-2, -2));
            try
            {
                Console.WriteLine(rec.Perimeter());
                Console.WriteLine(rec.Square());
            }
            catch (InvalidTriangleException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
