namespace Logging;

public class FileAppender : BaseAppender {
    private readonly string path;

    public FileAppender(IMessageFormatter<LogMessage> formatter, string path) : base(formatter) {
        if (string.IsNullOrEmpty(this.path)) throw new ArgumentNullException(nameof(path));
        this.path = path;
    }
    
    public FileAppender(IMessageFormatter<LogMessage> formatter, ReportLevel repostThreshold, string path) : base(formatter, repostThreshold) {
        if (string.IsNullOrEmpty(this.path)) throw new ArgumentNullException(nameof(path));
        this.path = path;
    }
    

    protected override void Append(string formattedLogMessage) {
        using StreamWriter streamWriter = File.AppendText(this.path);
        streamWriter.WriteLine(formattedLogMessage);
    }
}