var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async(HttpContext context,RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello World!");
    await next(context);
});

app.Use(async(HttpContext context,RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello from the second middleware!");
    await next(context);
});

app.Run(async(HttpContext context) =>
{
    await context.Response.WriteAsync("Hello from the third middleware!");
});

app.Run();
