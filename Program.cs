using Src.Configs.DataBase;
using Src.Models.Users.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// como se fosse o container 
builder.Services.AddScoped<IUserRepository, UserRepositories>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AppDbContext>(); // var tipo banco de dados 

var app = builder.Build();
app.MapControllers();
app.Run();
