using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TrainingProgram
{
    public int TraningProgramId { get; set; }

    public string? TraningProgramLevel { get; set; }

    public string? TraningProgramTitle { get; set; }

    public string? TraningProgramContent { get; set; }

    public string? TraningProgramDuration { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<RegistrationProgram> RegistrationPrograms { get; set; } = new List<RegistrationProgram>();
}
