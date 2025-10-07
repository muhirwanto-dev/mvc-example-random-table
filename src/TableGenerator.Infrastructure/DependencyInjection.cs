using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TableGenerator.Infrastructure.Http;

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
            return services;
        }
    }
}
