using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Exceptions
{
    public class NoSuchPlayerException : Exception
    {
        public NoSuchPlayerException()
        {
        }

        public NoSuchPlayerException(string message)
            : base(message)
        {
        }

        public NoSuchPlayerException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
