

var builder = WebApplication.CreateBuilder(args);
var router = builder.Build();

router.MapGet("/receptionist");

router.Run();


