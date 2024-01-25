using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    private LogFactory _logFactory = new();
    private BaseLogger? _baseLoggerVar;
    [TestInitialize]
    public void Constructor()
    {
        _logFactory = new();
        _logFactory.ConfigureFileLogger("test.txt");
        _baseLoggerVar = _logFactory.CreateLogger("class");
    }

    [TestMethod]
    public void CreateLogger_ClassName_Success()
    {
        Assert.IsNotNull(_baseLoggerVar);
        if (_baseLoggerVar != null)
        {
            Assert.IsNotNull(_baseLoggerVar.ClassName);
            if (_baseLoggerVar.ClassName != null)
            {
                Assert.IsTrue(_baseLoggerVar.ClassName.Equals("class", StringComparison.Ordinal));
            }
        }
    }

    [TestMethod]
    public void ConfigureFileLogger_FilePath_Success()
    {
        Assert.AreEqual("test.txt", _logFactory.GetFilename());
    }

    [TestMethod]
    public void CreateLogger_Constructor_Success()
    {
        Assert.AreNotEqual(null, _baseLoggerVar);
    }
    [TestMethod]
    public void CreateLogger_Constructor_Fail()
    {
        _logFactory.ConfigureFileLogger(null);
        _baseLoggerVar = _logFactory.CreateLogger("class");
        Assert.AreEqual(null, _baseLoggerVar);
    }

}
