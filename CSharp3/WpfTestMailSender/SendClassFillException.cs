using System;
using System.Runtime.Serialization;

namespace WpfTestMailSender
{
    [Serializable]
    public class SendClassFillException : ApplicationException
    {
        public SendClassFillException()
        {
        }

        public SendClassFillException(string message) : base(message)
        {
        }

        public SendClassFillException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SendClassFillException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
