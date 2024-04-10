using NLog;

namespace SummitGroup.Geodata.Application.Logger.Domain;


public class Logger : Interfaces.ILogger
{
    private static readonly NLog.Logger _logger = LogManager.GetCurrentClassLogger();

    public void LogError(string message, System.Exception ex)
    {
        _logger.Error(ex, message);
    }
    
    public void LogInformation(string message)
    {
        _logger.Info(message);
    }

    public void LogWarning(string message)
    {
        _logger.Warn(message);
    }
}