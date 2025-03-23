using System.Text;

namespace Logging;

public class JsonLogMessageFormatter : IMessageFormatter<LogMessage> {
    public string Format(LogMessage message) {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("{");
        sb.AppendLine($"   \"time\": \"{message.Time}\",");
        sb.AppendLine($"   \"reportLevel\": \"{message.ReportLevel}\",");
        sb.AppendLine($"   \"message\": \"{message.Message}\"");
        sb.AppendLine("}");
        
        return sb.ToString();
    }
}