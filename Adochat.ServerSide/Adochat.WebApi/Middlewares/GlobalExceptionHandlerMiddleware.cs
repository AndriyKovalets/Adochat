using Adochat.Domain.Exceptions;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Net;

namespace Adochat.WebApi.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                switch (exception)
                {
                    case HttpException ex:
                        await HandleHttpException(context, ex);
                        break;
                    default:
                        await HandleGenericException(context, exception);
                        break;
                }
            }
        }

        private async Task HandleGenericException(HttpContext context, Exception ex)
        {
            Log.Error(ex, "Unknown error has occured");
            await CreateExceptionAsync(context);
        }

        private async Task HandleHttpException(HttpContext context, HttpException ex)
        {
            Log.Error(ex, ex.Message, ex.StatusCode);
            await CreateExceptionAsync(context, ex.StatusCode, new { error = ex.Message });
            return;
        }

        private async Task CreateExceptionAsync(HttpContext context,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            object? errorBody = null)
        {
            errorBody ??= new { error = "Unknown error has occured" };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorBody));
        }
    }
}

