using Microsoft.AspNetCore.Mvc;
using src.configs.DataBase;
using src.Models.Users.infra.Entities;
namespace src.Controllers;

  [ApiController]
  [Route("users")]
  public class UsersController : ControllerBase
  {
    [HttpGet]
    public List<Users> Handle([FromServices] AppDbContext context)
    { 
      return context.Users.ToList();
    }

  }
