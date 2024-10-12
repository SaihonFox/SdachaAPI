using System;
using System.Collections.Generic;

namespace MedicalServicesAPI.Model;

public partial class patient_analysis_cart
{
    public ulong id { get; set; }

    public ulong? patient_id { get; set; }

    public virtual ICollection<analysis_order> analysis_orders { get; set; } = new List<analysis_order>();

    public virtual patient? patient { get; set; }

    public virtual ICollection<patient_analysis_cart_item> patient_analysis_cart_items { get; set; } = new List<patient_analysis_cart_item>();
}
