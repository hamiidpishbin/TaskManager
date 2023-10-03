using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BaseApiController : ControllerBase
{
  protected IActionResult HandleResult<T>(Result<T> result)
  {
    return result.Succeeded switch
    {
      true when result.Value != null => Ok(result.Value),
      true when result.Value == null => NotFound(),
      _ => BadRequest(result.Error)
    };
  }
}