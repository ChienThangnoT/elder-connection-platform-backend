using Application.IRepositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Repositories
{
    public class UserRepository : GenericRepository<Account>, IUserRepository
    {
        public UserRepository(ElderConnectionContext context) : base(context)
        {
        }
    }
}
