using System;
using System.Collections.Generic;

namespace MedicalServicesAPI.Model;

public partial class User
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronym { get; set; }

    public DateOnly Birthday { get; set; }

    public int? PassportId { get; set; }

    public int? PhoneId { get; set; }

    public sbyte? Post { get; set; }

    public int LoginId { get; set; }

    public string Password { get; set; } = null!;

    public byte[]? Image { get; set; }

    public virtual ICollection<AnalysisOrder> AnalysisOrders { get; set; } = new List<AnalysisOrder>();

    public virtual LoginList Login { get; set; } = null!;

    public virtual ICollection<MessagesMessage> MessagesMessages { get; set; } = new List<MessagesMessage>();

    public virtual PassportList? Passport { get; set; }

    public virtual PhoneList? Phone { get; set; }
}
