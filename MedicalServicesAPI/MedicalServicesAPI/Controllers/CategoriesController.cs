using MedicalServicesAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServicesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
	[HttpGet]
	public ActionResult<AnalysisCategory> Get(int? index)
	{
		var list = Program.ctx.AnalysisCategories.ToList();
		if (index == null)
			return Ok(list);

		try
		{
			return Ok(list[index.Value]);
		}
		catch
		{
			return BadRequest("out of range");
		}
	}
}