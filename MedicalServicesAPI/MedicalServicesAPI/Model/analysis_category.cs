using System.Text.Json.Serialization;

namespace MedicalServicesAPI.Model;

public partial class analysis_category
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    [JsonIgnore]
	public virtual ICollection<analysis> analyses { get; set; } = new List<analysis>();
}