using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Src.Controllers;

[Route("")]
[ApiController]
public class IndexController : ControllerBase
{
  [HttpGet("")]
  public IActionResult Get() {
    return Ok();
  }
}