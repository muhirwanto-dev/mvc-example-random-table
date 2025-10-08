using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using SingleScope.Persistence.EFCore;
using TableGenerator.Application.Interfaces.Repositories;
using TableGenerator.Infrastructure.Http;
using TableGenerator.Infrastructure.Persistence.Contexts;
using TableGenerator.Infrastructure.Persistence.Repositories;

namespace TableGenerator.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddLogging(configuration)
                .AddPersistence(configuration);
        }

        private static IServiceCollection AddLogging(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<HttpRequestLoggingHandler>();
            services.AddLogging(builder =>
            {
                builder.AddSerilog(new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger());
            });

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEfCorePersistence<LocalDbContext>(builder => builder.UseSqlServer(configuration.GetConnectionString("SqlServer")));
            services.AddScoped<IPersonalRepository, PersonalRepository>();

            return services;
        }
    }
}
