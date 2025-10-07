
using Asp.Versioning.ApiExplorer;
using TableGenerator.Api.Middlewares;
using TableGenerator.Application;
using TableGenerator.Infrastructure;

namespace TableGenerator.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .AddPresentation(builder.Configuration)
                .AddApplication(builder.Configuration)
                .AddInfrastructure(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    // Separate swagger docs by it's API version
                    IReadOnlyList<ApiVersionDescription> descriptions = app.DescribeApiVersions();

                    foreach (var description in descriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToLowerInvariant());
                    }
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseMiddleware<ApiExceptionHandleMiddleware>();
            app.UseMiddleware<HttpRequestLoggerMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
