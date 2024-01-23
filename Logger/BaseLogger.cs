namespace Logger;
//There is an existing BaseLogger class. It needs an auto property to hold a class name.
//This property should be set in the LogFactory using an object initializer.
public abstract class BaseLogger
{
    public string? ClassName { get; set; }
    public abstract void Log(LogLevel logLevel, string message);
}

