
using src.configs.DataBase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<Connection>(); // var tipo banco de dados 

var app = builder.Build();

app.MapControllers();
app.Run();
