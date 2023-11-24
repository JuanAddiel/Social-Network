using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Infrastructured.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructured.Persistence
{
    public static class ServicesRegistration
    {
        public static void AddPersistences (this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(p =>
                p.UseInMemoryDatabase("SocialNetwork")
                );
            }
            services.AddDbContext<ApplicationContext>(
                a => a.UseSqlServer(configuration.GetConnectionString("SocialNetwork")
                , m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
        }
    }
}
