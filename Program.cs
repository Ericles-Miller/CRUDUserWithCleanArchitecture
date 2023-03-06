var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "HeServer is running!");

app.Run();
