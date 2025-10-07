using TableGenerator.Web.Options;

namespace TableGenerator.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .Configure<AppSettings>(configuration.Bind)
                .AddProblemDetails();
        }
    }
}
