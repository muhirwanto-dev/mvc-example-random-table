using System.Text.Json.Serialization;
using TableGenerator.Api.Configurations;
using TableGenerator.Api.Routing;

namespace TableGenerator.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .Configure<AppSettings>(configuration.Bind)
                .AddEndpoints()
                .AddSwagger()
                .AddProblemDetails();
        }

        /// <summary>
        /// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.ConfigureOptions<SwaggerConfiguration>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(setup =>
            {
                setup.OrderActionsBy(desc => desc.RelativePath);
            });

            return services;
        }

        private static IServiceCollection AddEndpoints(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                // Customize route & action naming convention
                options.Conventions.Add(new ControllerRoutingConvention());
                options.Conventions.Add(new ActionRoutingConvention());
            })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddRouting(config =>
            {
                // All route path become lowercase
                config.LowercaseUrls = true;
            });

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
            })
                // This is required for Swagger to work with API versioning
                .AddApiExplorer(options =>
                {
                    // Format: v1, v1.0, etc.
                    options.GroupNameFormat = "'v'VVV";

                    // THIS makes {version} become real version like '1'
                    options.SubstituteApiVersionInUrl = true;
                });

            return services;
        }
    }
}
