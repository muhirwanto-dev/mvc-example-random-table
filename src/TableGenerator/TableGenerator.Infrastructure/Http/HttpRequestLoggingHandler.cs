using System.Net.Mime;
using System.Text;
using Microsoft.Extensions.Logging;

namespace TableGenerator.Infrastructure.Http
{
    public class HttpRequestLoggingHandler(
        ILogger<HttpRequestLoggingHandler> _logger
        ) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
            {
                string? body = null;

                if (request.Content is StringContent content)
                {
                    body = await request.Content.ReadAsStringAsync();

                    var encoding = content.Headers.ContentType?.CharSet != null
                        ? Encoding.GetEncoding(content.Headers.ContentType.CharSet)
                        : null;
                    var mediaType = content.Headers.ContentType?.MediaType;

                    // re-create the content
                    request.Content = new StringContent(body, encoding, mediaType ?? MediaTypeNames.Application.Json);
                }


                _logger.LogTrace(
                    "Sending HTTP request: {Method} {Uri} with body: {Body}",
                    request.Method,
                    request.RequestUri,
                    body ?? $"({request.Content?.GetType().Name}) has no body"
                );
            }
            else
            {
                _logger.LogInformation(
                    "Sending HTTP request: {Method} {Uri}",
                    request.Method,
                    request.RequestUri
                );
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
