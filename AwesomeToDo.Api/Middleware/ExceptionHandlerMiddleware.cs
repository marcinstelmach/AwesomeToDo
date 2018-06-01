using System;
using System.Net;
using System.Threading.Tasks;
using AwesomeToDo.Core.Exceptions;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NLog;

namespace AwesomeToDo.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate request;
        private readonly ILogger logger;

        public ExceptionHandlerMiddleware(RequestDelegate request, ILogger logger)
        {
            this.request = request;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await request(context);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errorCode = nameof(HttpStatusCode.InternalServerError);
            var statusCode = HttpStatusCode.InternalServerError;
            var message = exception.Message;

            if (exception is UnauthorizedAccessException)
            {
                errorCode = nameof(HttpStatusCode.Unauthorized);
                statusCode = HttpStatusCode.Unauthorized;
            }
            else if(exception is AwesomeToDoException awesomeToDoException)
            {
                statusCode = awesomeToDoException.ErrorCode.HttpStatusCode;
                errorCode = awesomeToDoException.ErrorCode.Message;
                message = awesomeToDoException.Message.IsNullOrEmpty() ? errorCode : awesomeToDoException.Message;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) statusCode;
            var responseBody = JsonConvert.SerializeObject(new {errorCode, message});

            return context.Response.WriteAsync(responseBody);
        }

    }
}