using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IRegistrationProgramRepository : IGenericRepository<RegistrationProgram>
    {
        Task<RegistrationProgram> GetRegistrationProgramByIdAsync(int registrationProgramId);
        Task<RegistrationProgram?> GetRegistrationProgramByConnectorAndProgramAsync(string connectorId, int programId);
        Task<bool> ExistsRegistrationAsync(string connectorId, int programId);
    }
}
