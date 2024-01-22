namespace Logger;
//The LogFactory should be updated with a new method ConfigureFileLogger. This should take in a file path and store it in a private member.
//It should use this when instantiating a new FileLogger in its CreateLogger method. ❌
//If the file logger has not be configured in the LogFactory, its CreateLogger method should return null
public class LogFactory
{
    public string Filepath {get; set;}
    public BaseLogger CreateLogger(string className)
    {
        if (Filepath == null)
        {
            return null;
        }
        else
        {
            return new FileLogger(className);
        }
    }
    public void ConfigureFileLogger(string filepath)
    {
        Filepath = filepath;
    }
}
