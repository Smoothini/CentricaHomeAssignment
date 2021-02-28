using System;

namespace DataLayer
{
    public class IllegalDataArgumentException : Exception
    {
        public string ExceptionMessage { get; set; }
        public string InnerExceptionMessage { get; set; }

        public IllegalDataArgumentException() { }

        public IllegalDataArgumentException(string msg) : base(msg)
        {
            this.ExceptionMessage = msg;
        }

        public IllegalDataArgumentException(string msg, Exception inex) : base(msg, inex)
        {
            this.ExceptionMessage = msg;
            this.InnerExceptionMessage = msg;
        }
    }
}
