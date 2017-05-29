namespace Shop.BLL.Exceptions
{
    using System;

    public class InvalidUserIdException : Exception
    {
        public InvalidUserIdException() : base() { }

        public InvalidUserIdException(string message) : base(message) { }

        public InvalidUserIdException(string message, Exception innerException) : base (message, innerException) { }
    }
}
