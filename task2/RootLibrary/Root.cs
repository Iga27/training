using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootLibrary
{
    public class Root
    {
        static double MyPow(double x, int power)
        {
            double result = 1;
            for (int i = 0; i < power; i++) result *= x;
            return result;
        }

        public static double Calculate(double A, int n, double eps = 0.00001)
        {
            double x1 = 1;
            double x2 = 1.0 / n * ((n - 1) * x1 + A / MyPow(x1, (n - 1)));
            while (Math.Abs(x2 - x1) > eps)
            {
                x1 = x2;
                x2 = 1.0 / n * ((n - 1) * x1 + A / MyPow(x1, (n - 1)));
            }
            return x2;
        }
    }
}
