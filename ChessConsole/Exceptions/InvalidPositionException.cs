using System;

namespace ChessConsole.Exceptions
{
    class InvalidPositionException : ApplicationException
    {
        public InvalidPositionException(string message) : base(message)
        {

        }
    }
}
