using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Exceptions
{
    public class DecryptFailureException : Exception
    {
        public DecryptFailureException()
        {
        }

        public DecryptFailureException(string message)
            : base(message)
        {
        }

        public DecryptFailureException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
