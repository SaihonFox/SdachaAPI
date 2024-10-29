using System;
using System.Collections.Generic;

namespace MedicalServicesAPI.Model;

public partial class Message
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public virtual ICollection<MessagesMessage> MessagesMessages { get; set; } = new List<MessagesMessage>();

    public virtual Patient Patient { get; set; } = null!;
}
