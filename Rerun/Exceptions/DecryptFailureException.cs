using System;

namespace Rerun.Exceptions
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
