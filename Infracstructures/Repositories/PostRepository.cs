using Application.IRepositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepostiory
    {
        public PostRepository(ElderConnectionContext context) : base(context)
        {

        }
    }
}
