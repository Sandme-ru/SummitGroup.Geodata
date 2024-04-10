namespace SummitGroup.Geodata.Application.Logger.Interfaces;

public interface ILogger
{
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(string message, System.Exception ex);
}