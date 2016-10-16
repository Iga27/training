using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EuclidLibrary
{
    public class Euclid
    {
        private TimeSpan interval;
       public override string ToString()
       {
           return String.Format("{0:00} {1}",interval.Milliseconds,
           interval.Ticks);
       }
   
        public int gcd(int x, int y)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (x < 0 || y < 0)
            {
                throw new NegativeValueException("negative value");
            }

            int tmp;
            while (y != 0)
            {
                tmp = x % y;
                x = y;
                y = tmp;
            }
            stopWatch.Stop();
            interval = stopWatch.Elapsed;
            return Math.Abs(x);
        }

        public  int gcd(int x,int y,int z)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (x < 0 || y < 0 || z<0)
            {
                throw new NegativeValueException("negative value");
            }
            int buf = gcd(x, y);
            int tmp;
            while (z != 0)
            {
                tmp = buf % z;
                buf = z;
                z = tmp;
            }
            stopWatch.Stop();
            interval = stopWatch.Elapsed;
            return Math.Abs(buf);
        }

       public int gcdBin(int x, int y)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            if (x == 0 || y == 0)
                return x == 0 ? y : x;

            int k = 1;
            while ((x != 0) && (y != 0))
            {
                while ((x % 2 == 0) && (y % 2 == 0))
                {
                    x /= 2;
                    y /= 2;
                    k *= 2;
                }
                while (x % 2 == 0) x /= 2;
                while (y % 2 == 0) y /= 2;
                if (x >= y) x -= y; else y -= x;
            }
            stopWatch.Stop();
            interval = stopWatch.Elapsed;
            return y * k;
        }
    }
       

         
         
     
}
