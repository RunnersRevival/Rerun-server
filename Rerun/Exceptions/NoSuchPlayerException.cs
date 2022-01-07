using System;

namespace Rerun.Exceptions
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
