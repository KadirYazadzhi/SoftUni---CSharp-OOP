namespace Logging;

public class LogMessage {
    public string Time { get; }
    public ReportLevel ReportLevel { get; }
    public string Message { get; }

    public LogMessage(string time, ReportLevel reportLevel, string message) {
        Time = time;
        ReportLevel = reportLevel;
        Message = message;
    }
}