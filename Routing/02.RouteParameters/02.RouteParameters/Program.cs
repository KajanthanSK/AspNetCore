var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("files/{filename}.{extension}", async context =>
{
    string filename = Convert.ToString(context.Request.RouteValues["filename"]);
    string extension = Convert.ToString(context.Request.RouteValues["extension"]);
    await context.Response.WriteAsync($"Filename: {filename}, Extension: {extension}");
});

app.Map("employees/profile/{Employeename}", async context =>
{
    string employeename = Convert.ToString(context.Request.RouteValues["employeename"]);
    await context.Response.WriteAsync($"Employee Name: {employeename}");
});

app.Run();
