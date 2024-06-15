using Microsoft.AspNetCore.Builder;

namespace Core.CrossCuttingConcerns.Exceptions.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionMiddlewareExtensions(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
 