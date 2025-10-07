using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TableGenerator.Application.Common.Behaviors;
using TableGenerator.Application.Common.Mapping;
using TableGenerator.Application.Interfaces;

namespace TableGenerator.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                options.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            return services
                .AddMapping();
        }

        private static IServiceCollection AddMapping(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();

            return services;
        }
    }
}
