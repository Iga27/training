using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuclidLibrary
{
    public class NegativeValueException : Exception
    {
        public NegativeValueException(string message)
            : base(message)
        {

        }

    }
}
