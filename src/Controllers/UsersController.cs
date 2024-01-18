using Microsoft.AspNetCore.Mvc;
using src.configs.DataBase;
using src.Models.Users.infra.Entities;

namespace src.Controllers
{
  [ApiController]
  [Route("users")]
  class UsersController : ControllerBase
  {
    [HttpGet]
    [Route("/")]
    public List<Users> Handle([FromServices] Connection context)
    {
      return context.Users.ToList();
    }
  }
}