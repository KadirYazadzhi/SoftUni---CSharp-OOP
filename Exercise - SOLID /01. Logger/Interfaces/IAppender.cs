namespace Logging;

public interface IAppender {
    void Append(LogMessage message);
}