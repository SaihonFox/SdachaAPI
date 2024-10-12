using System;
using System.Collections.Generic;

namespace MedicalServicesAPI.Model;

public partial class patient_analysis_cart_item
{
    public ulong id { get; set; }

    public uint count { get; set; }

    public ulong analysis_id { get; set; }

    public ulong patient_analysis_cart_id { get; set; }

    public virtual analysis analysis { get; set; } = null!;

    public virtual patient_analysis_cart patient_analysis_cart { get; set; } = null!;
}
