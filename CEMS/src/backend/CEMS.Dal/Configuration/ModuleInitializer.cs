using CEMS.Core.Configurations;
using CEMS.Core.Interfaces;
using CEMS.Core.RepositoryInterfaces.DalRepositories;
using CEMS.Dal.Models;
using CEMS.Dal.Repositories;
using CEMS.Dal.SqlContext;
using CEMS.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CEMS.Dal.Configuration
{
    public static class ModuleInitializer
    {
        public static IServiceCollection ConfigureDal(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDbContext(services, configuration);
            AddDependenciesToContainer(services);

            return services;
        }

        private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(Constants.DATABASE_CONNECTION_STRING);

            services.AddDbContext<CemsDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            var dbFactory = new CemsContextFactory(connectionString);
            services.AddSingleton(typeof(ICemsContextFactory), dbFactory);
        }

        private static void AddDependenciesToContainer(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppMappingProfile));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

        }
    }

}
