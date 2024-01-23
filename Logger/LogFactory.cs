namespace Logger;
//The LogFactory should be updated with a new method ConfigureFileLogger. This should take in a file path and store it in a private member.
//It should use this when instantiating a new FileLogger in its CreateLogger method. ❌
//If the file logger has not be configured in the LogFactory, its CreateLogger method should return null
public class LogFactory
{
    private string? _filename;
    public BaseLogger? CreateLogger(string className)
    {
        if (_filename == null)
        {
            return null;
        }
        else
        {
            return new FileLogger(_filename) { ClassName = className};
        }
    }
    public void ConfigureFileLogger(string? filepath)
    {
        _filename = filepath;
    }
    public string? GetFilename()
    {
        return _filename;
    }
}
