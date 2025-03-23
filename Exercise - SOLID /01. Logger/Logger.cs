using System.Collections.Immutable;
using System.Text;

namespace Logging;

public class Logger : ILogger {
    private readonly IImmutableList<IAppender> appenders;

    public Logger(IImmutableList<IAppender> appenders) {
        this.appenders = appenders ?? throw new ArgumentNullException(nameof(appenders));
    }

    public void Log(string time, ReportLevel reportLevel, string message) {
        foreach (IAppender appender in appenders){
            LogMessage logMessage = new LogMessage(time, reportLevel, message);
            appender.Append(logMessage);
        }
    }

    public override string ToString() {
        StringBuilder sb = new StringBuilder();
        
        sb.AppendLine("Logger ifo");
        foreach (IAppender appender in appenders){
            sb.AppendLine();
            sb.AppendLine(appender.ToString());
        }
        
        return sb.ToString();
    }
}