using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Data;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure
{
    public static class DependencyInjection
    {
        //Extension method to add infrastructure services to the dependency injection container 
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //TO DO: Add services to the IOC container
            //Infastructure services often include data access, caching and other low-level components
             
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<DapperDbContext>();

            return services;
        }
    }
}
