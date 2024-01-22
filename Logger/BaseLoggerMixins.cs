using static System.Net.Mime.MediaTypeNames;
using System.Data.Common;
using System.Dynamic;
using System;
using System.IO;

namespace Logger;
//Inside of BaseLoggerMixins implement extension methods on BaseLogger for
/*Error, ❌✔
Warning, ❌✔
Information, and ❌✔
Debug. ❌✔ Each of these methods should take in a string for the message, as well as a parameter array of arguments for the message.
Each of these extension methods is expected to be a shortcut for calling the BaseLogger.Log method, 
by automatically supplying the appropriate LogLevel. These methods should throw an exception if the BaseLogger parameter is null. 
There are a couple example unit tests to get you started.*/
public static class BaseLoggerMixins
{
    public static void Error(this BaseLogger bl, string[] message)
    {
       bl.Log(LogLevel.Error, combine(message));
    }
    public static void Warning(this BaseLogger bl, string[] message)
    {
        bl.Log(LogLevel.Warning, combine(message));
    }
    public static void Information(this BaseLogger bl, string[] message)
    {
        bl.Log(LogLevel.Information, combine(message));
    }
    public static void Debug(this BaseLogger bl, string[] message)
    {
        bl.Log(LogLevel.Debug, combine(message));
    }
    public static string combine(string[] message)
    {
        string newMessage = "";
        for(int i = 0; i < message.Length; i++)
        {
            newMessage += (message[i] + " ");
        }
        return newMessage;
    }
}
