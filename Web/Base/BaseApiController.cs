using System.Net;
using Application.Common.Models;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
	private ISender? _mediator;

	protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    
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