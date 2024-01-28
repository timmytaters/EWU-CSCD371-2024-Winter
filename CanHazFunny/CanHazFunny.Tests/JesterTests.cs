<<<<<<< HEAD
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.Metrics;
using System.IO;
=======
using Xunit;
>>>>>>> d7110209c32aafd7f0d4bd877409d09bf9f50e1a

namespace CanHazFunny.Tests;

public class JesterTests
{
<<<<<<< HEAD
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
=======
>>>>>>> d7110209c32aafd7f0d4bd877409d09bf9f50e1a
}
