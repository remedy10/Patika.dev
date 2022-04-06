using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using webAPI.Services;

namespace webAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _LoggerService;

        public ExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _LoggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                //loglama mesajı oluşturuyoruz.
                string message =
                    "[Request] HTTP" + context.Request.Method + " - " + context.Request.Path;
                //! " [Request] HTTPGET - /Books  ve  [Request] HTTPGET - /Books/2 " şeklinde yazar
                _LoggerService.Write(message); //? Yazdığımız logger service
                await _next(context);
                watch.Stop();
                message =
                    "[Response] HTTP"
                    + context.Request.Method
                    + " - "
                    + context.Request.Path
                    + " responded "
                    + context.Response.StatusCode
                    + " in "
                    + Math.Round(watch.Elapsed.TotalMilliseconds, 2)
                    + " ms";
                //!  [Response] HTTPGET - /Books responded 200 in 99.7335 ms şeklinde yazar
                _LoggerService.Write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message =
                "[Error] HTTP"
                + context.Request.Method
                + " - "
                + context.Response.StatusCode
                + " message:"
                + ex.Message
                + " in "
                + Math.Round(watch.Elapsed.TotalMilliseconds, 2)
                + " ms";
            _LoggerService.Write(message);
            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }
}
