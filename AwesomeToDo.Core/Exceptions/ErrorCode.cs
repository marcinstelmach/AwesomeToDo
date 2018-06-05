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

        public static ErrorCode EmptyCommand => new ErrorCode(nameof(EmptyCommand), HttpStatusCode.InternalServerError);
        public static ErrorCode InvalidCommand => new ErrorCode(nameof(InvalidCommand), HttpStatusCode.InternalServerError);
        public static ErrorCode FaultWhileSavingToDatabase => new ErrorCode(nameof(FaultWhileSavingToDatabase), HttpStatusCode.InternalServerError);

        public static ErrorCode GenericNotExist<T>()
            => new ErrorCode($"{nameof(T)}NotExist");
    }
}
