using System.Net;
using System.Text.Json;
using App.Shared.ResponseData;
using FluentValidation;

namespace App.Shared.Middlewares
{

    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                await HandleExceptionAsync(context, error);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var statusCode = error switch
            {
                ValidationException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };

            var responseModel = Result<string>.Fail(error is ValidationException e ? e.Message : error.Message);
            response.StatusCode = (int)statusCode;

            var result = JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(result);
        }
    }



}
