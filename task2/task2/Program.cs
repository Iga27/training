using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RootLibrary;
using BinLibrary;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            double d = Root.Calculate(7, 3);
            Console.WriteLine(d);

            Console.WriteLine(Math.Pow(7.0, (1.0 / 3)));

            Console.WriteLine(Binary.ToBinaryString(10)); 
        }
    }
}
