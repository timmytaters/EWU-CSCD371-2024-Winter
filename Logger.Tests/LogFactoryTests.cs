using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;

[TestClass]
public class LogFactoryTests
{
    private LogFactory _logFactory = new();
    private BaseLogger? _bl;
    [TestInitialize]
    public void Constructor()
    {
        _logFactory = new();
        _logFactory.ConfigureFileLogger("test.txt");
        _bl = _logFactory.CreateLogger("class");
    }

    [TestMethod]
    public void CreateLogger_ClassName_Success()
    {
        Assert.IsNotNull(_bl);
        if (_bl != null)
        {
            Assert.IsNotNull(_bl.ClassName);
            if (_bl.ClassName != null)
            {
                Assert.IsTrue(_bl.ClassName.Equals("class", StringComparison.Ordinal));
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
        Assert.AreNotEqual(null, _bl);
    }
    [TestMethod]
    public void CreateLogger_Constructor_Fail()
    {
        _logFactory.ConfigureFileLogger(null);
        _bl = _logFactory.CreateLogger("class");
        Assert.AreEqual(null, _bl);
    }

}
