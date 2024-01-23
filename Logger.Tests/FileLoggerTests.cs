using System;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class FileLoggerTests
{
    private FileLogger? _fileLogger;
    private readonly string _filePath = "test.txt";
    [TestInitialize]
    public void Constructor()
    {
        _fileLogger = new(_filePath);
    }

    [TestMethod]
    public void Constructor_FilePath_Success()
    {
        Assert.IsNotNull(_fileLogger);
        if (_fileLogger != null)
        {
            Assert.IsTrue(_filePath.Equals(_fileLogger.getFilePath()));
        }
    }

    [TestMethod]
    public void Log_Append_Success()
    {
        string message = "test message";

        if (!File.Exists(_filePath))
        {
            FileStream file = File.Create(_filePath);
            file.Close();
        }
        Assert.IsNotNull(_fileLogger);
        if (_fileLogger != null)
        {
            _fileLogger.ClassName = "FileLoggerTests";
            _fileLogger.Log(LogLevel.Error, message);

            StreamReader sr = new(_filePath);
            string? actual = sr.ReadLine();
            sr.Close();
            //Unsure how to make the date times sync
            string expected = DateTime.Now.ToString() + " FileLoggerTests Error: test message\n"; ;

            Assert.AreEqual(expected, actual);
        }
    }
}