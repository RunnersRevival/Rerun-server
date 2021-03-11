using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutrunSharp.Exceptions
{
    public class PlayerIDConflictException : Exception
    {
        public PlayerIDConflictException()
        {
        }

        public PlayerIDConflictException(string message)
            : base(message)
        {
        }

        public PlayerIDConflictException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
