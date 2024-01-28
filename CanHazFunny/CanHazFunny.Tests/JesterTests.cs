using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.Metrics;
using System.IO;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        public Jester testJester = new(new JokePrint(), new JokeService());
        [TestMethod]
        public void JokePrint_GivenString_Prints()
        {
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            testJester.jokePrint.PrintJoke("TestJoke");
            string expected = "TestJoke";
            string actual = sw.ToString().Trim();
            Assert.AreEqual<string>(expected, actual);
            Console.SetOut(Console.Out);
        }
        [TestMethod]
        public void JokeService_OnReturn_NoChuck()
        {
            Assert.IsFalse(testJester.jokeService.GetJoke().Contains("Chuck Norris"));
        }
    }
}
