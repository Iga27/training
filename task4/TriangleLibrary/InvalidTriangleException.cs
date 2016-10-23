using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleLibrary
{
    public class InvalidTriangleException : Exception
    {
        public InvalidTriangleException(string message)
            : base(message)
        {

        }
    }
}
