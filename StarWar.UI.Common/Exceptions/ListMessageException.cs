using System;
using System.Collections.Generic;
using System.Text;

namespace StarWar.UI.Common.Exceptions
{
    public class ListMessageException : MessageException
    {
        public List<string> Errors { get; set; }

        public ListMessageException(List<string> errors) : base(string.Join(", ", errors)) => Errors = errors;
        public ListMessageException(List<string> errors, Exception innerException) : base(string.Join(", ", errors), innerException) => Errors = errors;
    }
}
