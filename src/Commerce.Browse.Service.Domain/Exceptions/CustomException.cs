using Microsoft.Extensions.Logging;
using Commerce.Browse.Service.Domain.Extensions;

namespace Commerce.Browse.Service.Domain.Exceptions
{
    internal class CustomException
    {
        public static void OnError(ILogger logger, SeverityLevel severityLevel, LogLevelEnum logLevelEnum, string customMessage)
        {
            var message = $"Message : {severityLevel} - {logLevelEnum} - {customMessage}";
            // Log the error
            logger.LogError(message);

        }

        public static void OnInformation(ILogger logger, SeverityLevel severityLevel, LogLevelEnum logLevelEnum, string customMessage)
        {
            var message = $"Message : {severityLevel} - {logLevelEnum} - {customMessage}";
            // Log the error
            logger.LogError(message);
        }

    }
}
