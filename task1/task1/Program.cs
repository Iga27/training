using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoordinatesLibrary;
 

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "input.txt";

            Coordinates c = new Coordinates();
            c.FormatInput(path);
            Console.WriteLine(c.ToString());
        }
    }
}
