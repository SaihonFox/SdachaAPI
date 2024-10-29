using System;
using System.Collections.Generic;

namespace APIUI.Model;

public partial class PassportList
{
    public int Id { get; set; }

    public string Passport { get; set; } = null!;

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
