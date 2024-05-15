using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class RegistrationProgram
{
    public int RegistrationId { get; set; }

    public int ProgramId { get; set; }

    public string? ConnectorId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public int IsCompleted { get; set; }

    public virtual Account? Connector { get; set; }

    public virtual TraningProgram? Program { get; set; }
}
