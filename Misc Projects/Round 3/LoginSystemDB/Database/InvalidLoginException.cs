using System;

namespace LoginDatabase
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
