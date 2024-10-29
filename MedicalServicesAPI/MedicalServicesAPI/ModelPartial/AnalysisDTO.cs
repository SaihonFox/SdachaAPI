namespace MedicalServicesAPI.ModelPartial;

public class AnalysisDTO
{
	public int Id { get; set; }

	public string Name { get; set; } = null!;

	public string? Description { get; set; }

	public string? Preparation { get; set; }

	public string ResultsAfter { get; set; } = null!;

	public string Biomaterial { get; set; } = null!;

	public decimal Price { get; set; }

	public int AnalysisCategory { get; set; }
}