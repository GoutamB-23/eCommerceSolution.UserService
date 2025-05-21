using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core
{
    public static class DependencyInjection
    {
        //Extension method to add core services to the dependency injection container 
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            //TO DO: Add services to the IOC container
            //Core services often include data access, caching and other low-level components
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
