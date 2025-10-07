using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TableGenerator.Api.Configurations
{
    public class SwaggerConfiguration(
        IApiVersionDescriptionProvider _provider
        ) : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            foreach (ApiVersionDescription description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, new OpenApiInfo
                {
                    Title = AppDomain.CurrentDomain.FriendlyName,
                    Version = description.ApiVersion.ToString(),
                });
            }
        }
    }
}
