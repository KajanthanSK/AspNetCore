using _05.Custom_Conventional_Middleware_Class.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Before MyCustomMiddleware\n");
    await next();
    await context.Response.WriteAsync("After MyCustomMiddleware\n");
});

//app.UseMiddleware<MyCustomMiddleware>();
app.UseMyCustomMiddleware();
app.UseHelloCustomMiddleware();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Before final middleware\n");
    await next();
    await context.Response.WriteAsync("After final middleware\n");
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello from the final middleware!\n");
});

app.Run();