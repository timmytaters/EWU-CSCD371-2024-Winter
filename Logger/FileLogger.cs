using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
//It should take in a path to a file to write the log message to. When its Log method is called, it should
//append messages on their own line in the file. The output should include all of the following:
/*The current date/time ❌✔
The name of the class that created the logger ❌✔
The log level ❌✔
The message ❌✔
The format may vary, but an example might look like this "10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message"*/
//Use the nameof() operator when identifying the class name to the logger 
namespace Logger
{
    internal class FileLogger : BaseLogger
    {
        public FileLogger(string classname) { }
        public override void Log(LogLevel logLevel, string message)
        {
            string log = DateTime.Now.ToString() + " " + this.ClassName + " " +logLevel + ": " + message;
            File.AppendAllText(Filepath, log);
        }
    }
}
