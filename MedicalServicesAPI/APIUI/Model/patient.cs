using System;
using System.Collections.Generic;

namespace APIUI.Model;

public partial class Patient
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronym { get; set; }

    public DateOnly Birthday { get; set; }

    public int? PassportId { get; set; }

    public int? PhoneId { get; set; }

    public int? EmailId { get; set; }

    public string? Sex { get; set; }

    public int LoginId { get; set; }

    public string Password { get; set; } = null!;

    public byte[]? Image { get; set; }

    public virtual ICollection<AnalysisOrder> AnalysisOrders { get; set; } = new List<AnalysisOrder>();

    public virtual EmailList? Email { get; set; }

    public virtual LoginList Login { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<MessagesMessage> MessagesMessages { get; set; } = new List<MessagesMessage>();

    public virtual PassportList? Passport { get; set; }

    public virtual ICollection<PatientAnalysisCart> PatientAnalysisCarts { get; set; } = new List<PatientAnalysisCart>();

    public virtual ICollection<PatientsDataList> PatientsDataLists { get; set; } = new List<PatientsDataList>();

    public virtual PhoneList? Phone { get; set; }
}
