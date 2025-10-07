using System.Text.Json;
using SingleScope.Common.Extensions;

namespace TableGenerator.Api.Extensions
{
    public static class LoggerExtensions
    {
        public static void LogApiInvoked(this ILogger logger, HttpContext context, LogLevel level, string? postfix = null)
        {
            string logMessage;

            if (string.IsNullOrEmpty(postfix))
            {
                logMessage = string.Format("Api invoked: {0}{1}{2}", context.Request.Host, context.Request.Path, context.Request.QueryString);
            }
            else
            {
                logMessage = string.Format("Api invoked: {0}{1}{2}, {3}", context.Request.Host, context.Request.Path, context.Request.QueryString, postfix);
            }

            logger.Log(level, 0, logMessage.Sanitize(), null, (val, _) => val);
        }

        public static void LogApiDebugInvoked(this ILogger logger, HttpContext context, string? postfix = null)
        {
            LogApiInvoked(logger, context, LogLevel.Debug, postfix);
        }

        public static void LogApiTraceInvoked(this ILogger logger, HttpContext context, string? postfix = null)
        {
            LogApiInvoked(logger, context, LogLevel.Trace, postfix);
        }

        public static void LogApiDebugInvokedWithBody<TBody>(this ILogger logger, HttpContext context, TBody body)
        {
            LogApiInvoked(logger, context, LogLevel.Debug, $"\n{JsonSerializer.Serialize(body)}");
        }

        public static void LogApiTraceInvokedWithBody<TBody>(this ILogger logger, HttpContext context, TBody body)
        {
            LogApiInvoked(logger, context, LogLevel.Trace, $"\n{JsonSerializer.Serialize(body)}");
        }
    }
}
