var builder = WebApplication.CreateBuilder(args);
var receptionist = builder.Build();

receptionist.MapPost("/");