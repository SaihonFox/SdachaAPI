using System;
using System.Collections.Generic;

namespace APIUI.Model;

public partial class Analysis
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Preparation { get; set; }

    public string ResultsAfter { get; set; } = null!;

    public string Biomaterial { get; set; } = null!;

    public decimal Price { get; set; }

    public int AnalysisCategory { get; set; }

    public virtual ICollection<AdBlock> AdBlocks { get; set; } = new List<AdBlock>();

    public virtual AnalysisCategory AnalysisCategoryNavigation { get; set; } = null!;

    public virtual ICollection<PatientAnalysisCartItem> PatientAnalysisCartItems { get; set; } = new List<PatientAnalysisCartItem>();
}
