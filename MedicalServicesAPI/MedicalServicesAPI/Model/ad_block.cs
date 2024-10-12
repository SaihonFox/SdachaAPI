using System;
using System.Collections.Generic;

namespace MedicalServicesAPI.Model;

public partial class ad_block
{
    public ulong id { get; set; }

    public string name { get; set; } = null!;

    public string? description { get; set; }

    public string? sex { get; set; }

    public decimal price { get; set; }

    public DateTime? date_start { get; set; }

    public DateTime? date_end { get; set; }

    public ulong? analysis_id { get; set; }

    public virtual analysis? analysis { get; set; }
}
