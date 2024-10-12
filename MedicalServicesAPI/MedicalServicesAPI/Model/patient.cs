using System;
using System.Collections.Generic;

namespace MedicalServicesAPI.Model;

public partial class patient
{
    public ulong id { get; set; }

    public string surname { get; set; } = null!;

    public string name { get; set; } = null!;

    public string? patronym { get; set; }

    public DateOnly birthday { get; set; }

    public string? passport { get; set; }

    public string? phone { get; set; }

    public string email { get; set; } = null!;

    public string? sex { get; set; }

    public string login { get; set; } = null!;

    public string password { get; set; } = null!;

    public byte[]? image { get; set; }

    public virtual ICollection<analysis_order> analysis_orders { get; set; } = new List<analysis_order>();

    public virtual ICollection<message> messages { get; set; } = new List<message>();

    public virtual ICollection<messages_message> messages_messages { get; set; } = new List<messages_message>();

    public virtual ICollection<patient_analysis_cart> patient_analysis_carts { get; set; } = new List<patient_analysis_cart>();
}
