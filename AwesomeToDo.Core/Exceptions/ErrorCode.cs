using System.Net;

namespace AwesomeToDo.Core.Exceptions
{
    public class ErrorCode
    {
        public string Message { get; protected set; }
        public string Code { get; set; }
        public HttpStatusCode HttpStatusCode { get; }

        public ErrorCode(string message, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            Message = message;
            HttpStatusCode = httpStatusCode;
        }

        public static ErrorCode EmptyCommand => new ErrorCode(nameof(EmptyCommand));
        public static ErrorCode InvalidCommand => new ErrorCode(nameof(InvalidCommand));

        public static ErrorCode UserNotExist => new ErrorCode(nameof(UserNotExist));
    }
}
