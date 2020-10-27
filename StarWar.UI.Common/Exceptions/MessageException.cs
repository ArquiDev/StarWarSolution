using System;
using System.Collections.Generic;
using System.Text;

namespace StarWar.UI.Common.Exceptions
{
    public class MessageException : Exception
    {
        public MessageException(string message) : base(message) { }
        public MessageException(string message, Exception innerException) : base(message, innerException) { }
    }
}
