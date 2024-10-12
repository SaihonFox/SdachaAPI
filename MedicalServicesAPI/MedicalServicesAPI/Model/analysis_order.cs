using System.Text.Json.Serialization;

namespace MedicalServicesAPI.Model;

public partial class analysis_order
{
    public ulong id { get; set; }

    public ulong? user_id { get; set; }

    public ulong? patient_id { get; set; }

    public DateTime registration_date { get; set; }

    public ulong? patient_analysis_cart_id { get; set; }

    public DateTime analysis_datetime { get; set; }

    public string? comment { get; set; }

    public ulong patient_analysis_address_id { get; set; }

    [JsonIgnore]
	public virtual patient? patient { get; set; }

    [JsonIgnore]
	public virtual patient_analysis_address patient_analysis_address { get; set; } = null!;

    [JsonIgnore]
	public virtual patient_analysis_cart? patient_analysis_cart { get; set; }

	[JsonIgnore]
	public virtual user? user { get; set; }
}