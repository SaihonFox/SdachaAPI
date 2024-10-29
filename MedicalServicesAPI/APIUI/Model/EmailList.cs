using System;
using System.Collections.Generic;

namespace APIUI.Model;

public partial class EmailList
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
