using System;

namespace LoginDatabase.Exceptions
{
    class InvalidMessageException : Exception
    {
        public InvalidMessageException(ExceptionTypes type, string message) : base($"[{type}]: {message}") { }
        public enum ExceptionTypes
        {
            InvalidID,
            InvalidAuthor,
            InvalidContent
        }
    }
}
