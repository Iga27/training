using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PointLibrary;

namespace TriangleLibrary
{
    public class Triangle
    {
        private Point _a;
        private Point _b;
        private Point _c;

        public Triangle(Point a, Point b, Point c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        private double AB()
        {
            return Math.Pow(Math.Pow(_a.X - _b.X, 2) + Math.Pow(_a.Y - _b.Y, 2.0), 1.0 / 2);
        }
        private double AC()
        {
            return Math.Pow(Math.Pow(_a.X - _c.X, 2) + Math.Pow(_a.Y - _c.Y, 2.0), 1.0 / 2);
        }
        private double BC()
        {
            return Math.Pow(Math.Pow(_b.X - _c.X, 2) + Math.Pow(_b.Y - _c.Y, 2.0), 1.0 / 2);
        }

        private bool IsTriangleExist()
        {
            if (AB() >= (AC() + BC()) ||
                AC() >= AB() + BC() ||
                BC() >= AB() + AC())
                return false;
            else
                return true;
        }
        public double Perimeter()
        {
            if (!this.IsTriangleExist())
            {
                throw new InvalidTriangleException("such triangle doesn't exist");
            }

            return AB() + AC() + BC();
        }
        public double Square()
        {
            if (!this.IsTriangleExist())
            {
                throw new InvalidTriangleException("such triangle doesn't exist");
            }

            return Math.Pow((Perimeter() / 2) * (Perimeter() / 2 - AB()) *
            (Perimeter() / 2 - AC()) *
            (Perimeter() / 2 - BC()), 1.0 / 2);
        }
    }
}
