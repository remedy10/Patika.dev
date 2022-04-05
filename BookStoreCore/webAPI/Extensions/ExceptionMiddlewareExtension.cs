using webapi.Middlewares;

namespace webapi.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionMiddle(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<ExceptionMiddleware>();
            }
    }
}