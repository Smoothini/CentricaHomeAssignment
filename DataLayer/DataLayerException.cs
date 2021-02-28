using System;

namespace DataLayer
{
    public class DataLayerException : Exception
    {
        public string ExceptionMessage { get; set; }
        public string InnerExceptionMessage { get; set; }

        public DataLayerException() { }

        public DataLayerException(string msg) : base(msg)
        {
            this.ExceptionMessage = msg;
        }

        public DataLayerException(string msg, Exception inex) : base(msg, inex)
        {
            this.ExceptionMessage = msg;
            this.InnerExceptionMessage = inex.Message;
        }
    }
}
