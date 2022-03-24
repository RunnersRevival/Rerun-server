using System;

namespace Rerun.Exceptions
{
    /// <summary>
    /// Returned by Cryptor when it fails to decrypt text.
    /// </summary>
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
