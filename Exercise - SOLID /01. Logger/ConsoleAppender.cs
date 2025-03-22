namespace Logging;

public class ConsoleAppender : BaseAppender {
    public ConsoleAppender(IMessageFormatter<LogMessage> formatter) : base(formatter) {
        
    }
    
    public ConsoleAppender(IMessageFormatter<LogMessage> formatter, ReportLevel reportThreshold) : base(formatter, reportThreshold) {
        
    }
    protected override void Append(string logMessage) => Console.WriteLine(logMessage);
}