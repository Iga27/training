﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointLibrary
{
    public class Point
    {
        private int _x;
        private int _y;

        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }
        public int X
        {
            get { return _x; }
            set
            {
                //_x = value >= 0 ? value : 0;
                _x = value;
            }
        }
        public int Y
        {
            get { return _y; }
            set
            {
                _y = value;
            }
        }
    }
}
