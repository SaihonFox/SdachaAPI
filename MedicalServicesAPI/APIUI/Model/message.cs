using System;
using System.Collections.Generic;

namespace APIUI.Model;

public partial class message
{
    public ulong id { get; set; }

    public ulong patient_id { get; set; }

    public virtual ICollection<messages_message> messages_messages { get; set; } = new List<messages_message>();

    public virtual patient patient { get; set; } = null!;
}
