using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependecyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddDbContext<MyContext>(options =>
                options.UseMySql(
                    "Server=localhost;Port=3306;Database=store;Uid=root;Pwd=123",
                    new MySqlServerVersion(new Version(8, 0, 11))
                )
            );
        }
    }
}
