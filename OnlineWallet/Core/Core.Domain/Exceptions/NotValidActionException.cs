using System;

namespace Core.Domain.Exceptions
{
    public class NotValidActionException : Exception
    {
        public NotValidActionException()
        {
        }

        public NotValidActionException(string message) : base(message)
        {
        }
    }
}
