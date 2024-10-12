using System;
using System.Collections.Generic;

namespace MedicalServicesAPI.Model;

public partial class user
{
    public ulong id { get; set; }

    public string surname { get; set; } = null!;

    public string name { get; set; } = null!;

    public string? patronym { get; set; }

    public DateOnly birthday { get; set; }

    public string? passport { get; set; }

    public string? phone { get; set; }

    public sbyte? post { get; set; }

    public string login { get; set; } = null!;

    public string password { get; set; } = null!;

    public byte[]? image { get; set; }

    public virtual ICollection<analysis_order> analysis_orders { get; set; } = new List<analysis_order>();

    public virtual ICollection<messages_message> messages_messages { get; set; } = new List<messages_message>();
}
