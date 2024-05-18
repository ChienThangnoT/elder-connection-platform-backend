using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfractstructure(this IServiceCollection services, IConfiguration config)
        {
            //Congig local db
            services.AddDbContext<ElderConnectionContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("ElderConnectionDB"));
            });
            return services;

            // add dj

        }
    }
}
