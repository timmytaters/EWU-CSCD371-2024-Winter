using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.Metrics;
using System.IO;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace CanHazFunny.Tests;

[TestClass]
public class JesterTests
{
    private static readonly Jester testJester = new(new JokePrint(), new JokeService());
    [TestMethod]
    public void JokePrint_GivenString_Prints()
    {
        StringWriter sw = new();
        Console.SetOut(sw);
        testJester.JokePrint.PrintJoke("TestJoke");
        string expected = "TestJoke";
        string actual = sw.ToString().Trim();
        Assert.AreEqual<string>(expected, actual);
        Console.SetOut(Console.Out);
    }
    [TestMethod]
    public void JokeService_OnReturn_NoChuck()
    {
        Assert.IsFalse(testJester.JokeService.GetJoke().Contains("Chuck Norris"));
    }
    [TestMethod]
    public void TellJoke_OnReturn_PrintsAndNoChuck()
    {
        StringWriter sw = new();
        Console.SetOut(sw);
        testJester.TellJoke();
        string actual = sw.ToString().Trim();
        Assert.IsFalse(actual.Contains("Chuck Norris"));
        Assert.IsFalse(actual.Contains("chuck norris"));
        Assert.IsTrue(actual.Length>0);
        Console.SetOut(Console.Out);
    }
    [TestMethod]
    public void Constructor_NullIJokePrint_ThrowsArgumentNullException()
    {
        JokeService testJokeService = new();
        Assert.ThrowsException<ArgumentNullException>(() => { Jester jester = new(null!, testJokeService); });
    }
    [TestMethod]
    public void Constructor_NullIJokeService_ThrowsArgumentNullException()
    {
        JokePrint testJokePrint = new JokePrint();  
        Assert.ThrowsException<ArgumentNullException>(() => { Jester jester = new(testJokePrint, null!); });
    }
}

