using Domain.Interfaces;
using InfoSolutionTeste.Infra.Repositories;
using Infra.Data;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Livraria.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesInfra(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<InfoSolutionContext>(opt => opt
                .UseSqlServer(configuration.GetConnectionString("DB_INFO_SOLUTION")));

            return services;
        }
    }
}
