using System;
using System.Collections.Generic;

namespace MedicalServicesAPI.Model;

public partial class analysis_category
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public virtual ICollection<analysis> analyses { get; set; } = new List<analysis>();
}
