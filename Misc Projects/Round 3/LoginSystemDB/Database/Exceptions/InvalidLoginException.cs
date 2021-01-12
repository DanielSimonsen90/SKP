using System;

namespace LoginDatabase.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException(ExceptionTypes type, string message) : base($"[{type}]: {message}") { }

        public enum ExceptionTypes
        {
            InvalidUsername,
            InvalidPassword
        }
    }
}
