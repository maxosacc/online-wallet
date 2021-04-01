using System;

namespace Core.Domain.Exceptions
{
    public class NotValidParameterException : Exception
    {
        public NotValidParameterException()
        {
        }

        public NotValidParameterException(string message) : base(message)
        {
        }
    }
}
