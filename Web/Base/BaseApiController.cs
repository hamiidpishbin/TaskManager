using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Base;

[Route("api/[controller]")]
[ApiController]
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