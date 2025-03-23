namespace Logging;

public interface ILogger {
    void Log(string time, ReportLevel reportLevel, string message);
}