using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeToDo.Core.Exceptions
{
    public class AwesomeToDoException : Exception
    {
        public ErrorCode ErrorCode { get; }

        public AwesomeToDoException(ErrorCode errorCode)
            : this(errorCode, string.Empty)
        {

        }

        public AwesomeToDoException(ErrorCode errorCode, string message)
            : this(errorCode, message, null)
        {

        }

        public AwesomeToDoException(ErrorCode errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
