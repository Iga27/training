using System;

namespace App.BLL.Infrastructure
{
    public class OperationInfo
    {
        public OperationInfo(bool succedeed, string message, string prop)
        {
            Succedeed = succedeed;
            Message = message;
            Property = prop;
        }
        public bool Succedeed { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }
    }
}