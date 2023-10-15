using Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BaseApiController : ControllerBase
{
  protected IActionResult HandleResult<T>(ServiceResult<T> serviceResult)
  {
    return serviceResult.Succeeded switch
    {
      true when serviceResult.Value != null => Ok(serviceResult.Value),
      true when serviceResult.Value == null => NotFound(),
      _ => BadRequest(serviceResult.Error)
    };
  }
}