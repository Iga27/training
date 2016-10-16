using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuclidLibrary;
using System.Diagnostics;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Euclid e = new Euclid();
               
                Console.WriteLine(e.gcd(1054356346, 453545413));
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.gcd(1054356346, 453545413, 500000));
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.gcdBin(56346, 453545413));
                Console.WriteLine(e.ToString());
            }
            catch (NegativeValueException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
