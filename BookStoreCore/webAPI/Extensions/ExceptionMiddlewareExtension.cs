
using webAPI.Middlewares;

namespace webAPI.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionMiddle(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<ExceptionMiddleware>();
            }
    }
}