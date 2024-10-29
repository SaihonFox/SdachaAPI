using System;
using System.Collections.Generic;

namespace APIUI.Model;

public partial class AnalysisCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Analysis> Analyses { get; set; } = new List<Analysis>();
}
