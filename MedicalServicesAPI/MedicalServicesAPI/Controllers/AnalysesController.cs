using MedicalServicesAPI.Model;
using MedicalServicesAPI.ModelPartial;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalServicesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AnalysesController : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> Get(int? index)
	{
		var list = await Program.ctx.Analyses.ToListAsync();
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

	[HttpPost]
	public async Task<ActionResult<Analysis>> Post([FromBody] AnalysisDTO? new_analysis_dto)
	{
		Program.ctx.ChangeTracker.Clear();

		if (new_analysis_dto == null)
			return BadRequest("Был введен null");


		var anal = new Analysis
		{
			Id = new_analysis_dto.Id,
			Name = new_analysis_dto.Name,
			Description = new_analysis_dto.Description,
			Price = new_analysis_dto.Price,
			Preparation = new_analysis_dto.Preparation,
			ResultsAfter = new_analysis_dto.ResultsAfter,
			AnalysisCategory = new_analysis_dto.AnalysisCategory,
			Biomaterial = new_analysis_dto.Biomaterial,
		};

		await Program.ctx.Analyses.AddAsync(anal);
		await Program.ctx.SaveChangesAsync();

		return CreatedAtAction("Get", new { anal.Id }, anal);
	}

	[HttpPut]
	public async Task<ActionResult<Analysis>> Put(int id, [FromBody] Analysis? analysis)
	{
		if (analysis == null || analysis.Id != id)
			return BadRequest("Были введены некорректные данные");

		Program.ctx.ChangeTracker.Clear();

		var updated = await Program.ctx.Analyses.FirstOrDefaultAsync(a => a.Id == id);
		if (updated == null)
			return NotFound("Анализ с таким id не был найден");

		updated.Biomaterial = analysis.Biomaterial;
		updated.Description = analysis.Description;
		updated.Name = analysis.Name;
		updated.Preparation = analysis.Preparation;
		updated.ResultsAfter = analysis.ResultsAfter;
		updated.Price = analysis.Price;
		updated.AnalysisCategory = analysis.AnalysisCategory;

		await Program.ctx.SaveChangesAsync();

		return Ok(updated);
	}

	[HttpDelete]
	public async Task<ActionResult<Analysis>> Delete(int id)
	{
		var analysis = await Program.ctx.Analyses.FirstOrDefaultAsync(a => a.Id == id);
		if (analysis == null)
			return NotFound("id not found");

		await Program.ctx.Analyses.ExecuteDeleteAsync();
		await Program.ctx.SaveChangesAsync();

		return Ok(analysis);
	}
}