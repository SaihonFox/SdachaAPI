using System;
using System.Collections.Generic;

namespace APIUI.Model;

public partial class messages_message
{
    public ulong id { get; set; }

    public ulong? messages_id { get; set; }

    public string? message { get; set; }

    public DateTime time { get; set; }

    public ulong? user_id { get; set; }

    public ulong? patient_id { get; set; }

    public virtual message? messages { get; set; }

    public virtual patient? patient { get; set; }

    public virtual user? user { get; set; }
}
