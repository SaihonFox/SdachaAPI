using MedicalServicesAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServicesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AnalysesController : ControllerBase
{
	[HttpGet("list")]
	public ActionResult<IList<analysis>> Get() => Ok(Program.ctx.analyses.ToList());

	[HttpGet]
	public ActionResult<analysis> Get(int index)
	{
		try
		{
			return Ok(Program.ctx.analyses.ToList()[index]);
		}
		catch
		{
			return BadRequest("out of range");
		}
	}
}