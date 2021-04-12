using System;

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
