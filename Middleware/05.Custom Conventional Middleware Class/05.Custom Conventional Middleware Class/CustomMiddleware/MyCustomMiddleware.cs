namespace _05.Custom_Conventional_Middleware_Class.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Custom logic before the next middleware
            await context.Response.WriteAsync("Before next middleware\n");
            // Call the next middleware in the pipeline
            await next(context);
            // Custom logic after the next middleware
            await context.Response.WriteAsync("After next middleware\n");
        }
    }

    public static class MyCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
