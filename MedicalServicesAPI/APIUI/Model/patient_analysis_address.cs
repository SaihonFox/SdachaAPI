using System;
using System.Collections.Generic;

namespace APIUI.Model;

public partial class patient_analysis_address
{
    public ulong id { get; set; }

    public string address { get; set; } = null!;

    public int? floor { get; set; }

    public int? room { get; set; }

    public int? entrance { get; set; }

    public string? intercome { get; set; }

    public virtual ICollection<analysis_order> analysis_orders { get; set; } = new List<analysis_order>();
}
