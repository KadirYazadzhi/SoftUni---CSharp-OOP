namespace Logging;

public interface IMessageFormatter<T> {
    string Format(T value);
}