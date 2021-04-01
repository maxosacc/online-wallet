using System;

namespace Core.Domain.Exceptions
{
    public class BankAPINotRespondingException : Exception
    {
        public BankAPINotRespondingException()
        {
        }

        public BankAPINotRespondingException(string message) : base(message)
        {
        }
    }
}
