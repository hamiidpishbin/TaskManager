using Application.Models;
using Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BaseApiController : ControllerBase
{
  protected IActionResult HandleResult<T>(OldResult<T> oldResult)
  {
    return oldResult.Succeeded switch
    {
      true when oldResult.Value != null => Ok(oldResult.Value),
      true when oldResult.Value == null => NotFound(),
      _ => BadRequest(oldResult.Error)
    };
  }
}