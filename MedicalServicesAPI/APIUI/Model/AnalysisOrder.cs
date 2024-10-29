using System;
using System.Collections.Generic;

namespace APIUI.Model;

public partial class AnalysisOrder
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? PatientId { get; set; }

    public DateTime RegistrationDate { get; set; }

    public int? PatientAnalysisCart { get; set; }

    public DateTime AnalysisDatetime { get; set; }

    public string? Comment { get; set; }

    public int PatientAnalysisAddress { get; set; }

    public virtual Patient? Patient { get; set; }

    public virtual PatientAnalysisAddress PatientAnalysisAddressNavigation { get; set; } = null!;

    public virtual PatientAnalysisCart? PatientAnalysisCartNavigation { get; set; }

    public virtual User? User { get; set; }
}
