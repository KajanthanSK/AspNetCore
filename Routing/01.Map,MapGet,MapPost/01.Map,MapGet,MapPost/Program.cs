var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("map1", async (context) =>
{
    await context.Response.WriteAsync("Hello from map1");
});

app .Map("map2", async (context) =>
{
    await context.Response.WriteAsync("Hello from map2");
});

//app.MapPost("mappost", async (context) =>
//{
//    await context.Response.WriteAsync("Hello from mappost");
//});

//app.MapGet("mapget", async (context) =>
//{
//    await context.Response.WriteAsync("Hello from mapget");
//});

app.MapFallback(async (context) =>
{
    await context.Response.WriteAsync("Hello from fallback");
});

app.Run();
