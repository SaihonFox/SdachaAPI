using System;
using System.Collections.Generic;

namespace APIUI.Model;

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

    public virtual patient? patient { get; set; }

    public virtual patient_analysis_address patient_analysis_address { get; set; } = null!;

    public virtual patient_analysis_cart? patient_analysis_cart { get; set; }

    public virtual user? user { get; set; }
}
