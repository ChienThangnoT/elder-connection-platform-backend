using Application.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Repositories
{
    public class RegistrationProgramRepository : GenericRepository<RegistrationProgram>, IRegistrationProgramRepository
    {
        public RegistrationProgramRepository(ElderConnectionContext context) : base(context)
        {
        }

        public async Task<bool> ExistsRegistrationAsync(string connectorId, int programId)
        {
            return await _dbSet.AnyAsync(rp => rp.ConnectorId == connectorId && rp.TraningProgramId == programId);
        }

        public async Task<RegistrationProgram?> GetRegistrationProgramByConnectorAndProgramAsync(string connectorId, int programId)
        {
            return await _dbSet
                .Include(rp => rp.TraningProgram)
                .Include(rp => rp.Connector)
                .FirstOrDefaultAsync(rp => rp.ConnectorId == connectorId && rp.TraningProgramId == programId);
        }

        public async Task<RegistrationProgram?> GetRegistrationProgramByIdAsync(int registrationProgramId)
        {
            return await _dbSet.FirstOrDefaultAsync(rp => rp.RegistrationId == registrationProgramId);
        }
    }
}
