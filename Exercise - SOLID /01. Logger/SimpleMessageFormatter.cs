namespace Logging;

public class SimpleMessageFormatter : IMessageFormatter<LogMessage> {
    public string Format(LogMessage message) =>
        $"{message.Time} - {message.ReportLevel.ToString().ToUpper()} - {message.Message}";
}