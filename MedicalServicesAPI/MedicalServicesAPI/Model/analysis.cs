using System;
using System.Collections.Generic;

namespace MedicalServicesAPI.Model;

public partial class analysis
{
    public ulong id { get; set; }

    public string name { get; set; } = null!;

    public string? description { get; set; }

    public string? preparation { get; set; }

    public DateTime results_after { get; set; }

    public string biomaterial { get; set; } = null!;

    public decimal price { get; set; }

    public int analyses_category_id { get; set; }

    public virtual ICollection<ad_block> ad_blocks { get; set; } = new List<ad_block>();

    public virtual analysis_category analyses_category { get; set; } = null!;

    public virtual ICollection<patient_analysis_cart_item> patient_analysis_cart_items { get; set; } = new List<patient_analysis_cart_item>();
}
