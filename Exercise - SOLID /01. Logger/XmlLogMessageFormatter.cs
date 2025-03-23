using System.Text;

namespace Logging;

public class XmlLogMessageFormatter : IMessageFormatter<LogMessage> {
    public string Format(LogMessage message) {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<log>");
        sb.AppendLine($"   <time>{message.Time}</time>");
        sb.AppendLine($"   <level>{message.ReportLevel}</level>");
        sb.AppendLine($"   <message>{message.Message}</message>");
        sb.Append("</log>");
        
        return sb.ToString();
    }
}