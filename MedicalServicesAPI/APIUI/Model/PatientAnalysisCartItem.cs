using System;
using System.Collections.Generic;

namespace APIUI.Model;

public partial class PatientAnalysisCartItem
{
    public int Id { get; set; }

    public uint Count { get; set; }

    public int AnalysisId { get; set; }

    public int PatientAnalysisCart { get; set; }

    public virtual Analysis Analysis { get; set; } = null!;

    public virtual PatientAnalysisCart PatientAnalysisCartNavigation { get; set; } = null!;
}
