namespace Logging;

public abstract class BaseAppender : IAppender {
    private readonly IMessageFormatter<LogMessage> formatter;
    private readonly ReportLevel reportThreshold;
    
    private int appndedMessages, appendedCharacters;

    protected BaseAppender(IMessageFormatter<LogMessage> formatter) : this(formatter, ReportLevel.Info) { 
    }
    protected BaseAppender(IMessageFormatter<LogMessage> formatter, ReportLevel reportThreshold) {
        this.formatter = formatter  ?? throw new ArgumentNullException(nameof(formatter));
        this.reportThreshold = reportThreshold;
    }

    public void Append(LogMessage logMessage) {
        if (logMessage.ReportLevel < this.reportThreshold) return;
        
        string textToAppend = formatter.Format(logMessage);
        this.Append(textToAppend);

        appndedMessages++;
        appendedCharacters += textToAppend.Length;
    }
    
    protected abstract void Append(string textToAppend);

    public override string ToString() {
        return $"Appender type: {this.GetType().Name}, " +
               $"Formatter: {this.formatter.GetType().Name}, " +
               $"Report threshold: {this.reportThreshold.ToString()}," +
               $"Messages appended: {this.appendedCharacters}," +
               $"Characters appended: {this.appendedCharacters}";
    }
}