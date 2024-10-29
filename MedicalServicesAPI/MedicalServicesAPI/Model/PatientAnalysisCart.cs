using System;
using System.Collections.Generic;

namespace MedicalServicesAPI.Model;

public partial class PatientAnalysisCart
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public virtual ICollection<AnalysisOrder> AnalysisOrders { get; set; } = new List<AnalysisOrder>();

    public virtual Patient? Patient { get; set; }

    public virtual ICollection<PatientAnalysisCartItem> PatientAnalysisCartItems { get; set; } = new List<PatientAnalysisCartItem>();
}
