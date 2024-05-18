using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class RegistrationProgram
{
    public int RegistrationId { get; set; }

    public int TraningProgramId { get; set; }

    public string? ConnectorId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public bool IsCompleted { get; set; }

    public virtual Account? Connector { get; set; }

    public virtual TrainingProgram? TraningProgram { get; set; }
}
