using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Users;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependecyInjection
{
    public static class ConfigureService
    {
        public static void ConfigureDependenciesService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
        }
    }
}
