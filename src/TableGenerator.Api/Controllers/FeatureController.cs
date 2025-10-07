using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TableGenerator.Api.Configurations;
using TableGenerator.Application.Feature.Commands.AddFeature;
using TableGenerator.Contracts.Dtos.Feature;

namespace TableGenerator.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FeatureController(
        IOptions<AppSettings> _appSettingsOptions,
        ISender _mediator
        ) : ApiController
    {
        private readonly AppSettings _appSettings = _appSettingsOptions.Value;

        [HttpPost("{identifier}")]
        [ProducesResponseType<FeatureResponseDto>(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddFeatureAsync([FromRoute] string identifier, [FromBody] FeatureRequestDto payload, CancellationToken cancellationToken)
        {
            var command = new AddFeatureCommand(identifier);
            var result = await _mediator.Send(command, cancellationToken);

            return result.Match(
                onValue: Ok,
                onError: Problem
                );
        }
    }
}
