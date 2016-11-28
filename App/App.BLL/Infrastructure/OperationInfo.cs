using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Infrastructure
{
    public class OperationInfo
    {
        public bool Succedeed { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }

        public OperationInfo(bool succedeed,string mes,string prop)
        {
            Succedeed = succedeed;
            Message = mes;
            Property = prop;
        }
    }
}
