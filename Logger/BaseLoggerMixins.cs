using static System.Net.Mime.MediaTypeNames;
using System.Data.Common;
using System.Dynamic;
using System;
using System.IO;
using System.Globalization;

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
    public static void Error(this BaseLogger? baseLogger, string message, params object[] args)
    {
        if (baseLogger == null)
        {
            throw new ArgumentNullException(nameof(baseLogger));
        }
        else
        {
            string postMessage = string.Format(CultureInfo.CurrentCulture, message, args);
            baseLogger.Log(LogLevel.Error, postMessage);
        }
    }
    public static void Warning(this BaseLogger? baseLogger, string message, params object[] args)
    {
        if (baseLogger == null)
        {
            throw new ArgumentNullException(nameof(baseLogger));
        }
        else
        {
            string postMessage = string.Format(CultureInfo.CurrentCulture, message, args);
            baseLogger.Log(LogLevel.Warning, postMessage);
        }
    }
    public static void Information(this BaseLogger? baseLogger, string message, params object[] args)
    {
        if (baseLogger == null)
        {
            throw new ArgumentNullException(nameof(baseLogger));
        }
        else
        {
            string postMessage = string.Format(CultureInfo.CurrentCulture, message, args);
            baseLogger.Log(LogLevel.Information, postMessage);
        }
    }
    public static void Debug(this BaseLogger? baseLogger, string message, params object[] args)
    {
        if (baseLogger == null)
        {
            throw new ArgumentNullException(nameof(baseLogger));
        }
        else
        {
            string postMessage = string.Format(CultureInfo.CurrentCulture,message, args);
            baseLogger.Log(LogLevel.Debug, postMessage);
        }
    }
}
