using Src.Config.Container;
using Src.Configs.DataBase;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddRepositories();
builder.Services.AddUseCases();


var app = builder.Build();
app.MapControllers();
app.Run();
