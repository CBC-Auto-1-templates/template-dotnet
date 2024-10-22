var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration
 .AddEnvironmentVariables()
 .Build();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("./swagger/v1/swagger.json", "template-dotnet");
    c.RoutePrefix = "";
});

app.MapGet("/hello", (IConfiguration config) =>
{
    var thing = config.GetValue<string>("THING");
    return HelloSayer.SayHello(thing);
})
.WithName("hello")
.WithOpenApi();

app.Run();

public static class HelloSayer
{
    public static string SayHello(string? thing)
    {
        if (string.IsNullOrWhiteSpace(thing))
        {
            return "Hello World!";
        }

        return $"Hello {thing}!";
    }
}
