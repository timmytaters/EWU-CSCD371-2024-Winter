using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests
{
    [TestClass]
    public class FullNameTests
    {
        [TestMethod]
        public void FullName_WithMiddleName_IsAccurate()
        {
            FullName testName = new("Timothy", "August", "Nelson");
            Assert.IsNotNull(testName);
            Assert.IsNotNull(testName.FirstName); 
            Assert.IsNotNull(testName.MiddleName);
            Assert.IsNotNull(testName.LastName);
#pragma warning disable CS8604 // Possible null reference argument.
            //Not null since asserted previously
            Assert.AreEqual<string>("Timothy", testName.FirstName);
            Assert.AreEqual<string>("August", testName.MiddleName);
            Assert.AreEqual<string>("Nelson", testName.LastName);
#pragma warning restore CS8604 // Possible null reference argument.
            Assert.AreEqual<string>("Timothy August Nelson", testName.GetFullName());
        }
        [TestMethod]
        public void FullName_WithoutMiddleName_IsAccurate()
        {
            FullName testName = new("Timothy", null, "Nelson");
            Assert.IsNotNull(testName);
            Assert.IsNotNull(testName.FirstName);
            Assert.IsNotNull(testName.LastName);
#pragma warning disable CS8604 // Possible null reference argument.
            //Not null since asserted previously
            Assert.AreEqual<string>("Timothy", testName.FirstName);
            Assert.AreEqual<string>("Nelson", testName.LastName);
#pragma warning restore CS8604 // Possible null reference argument.
            Assert.AreEqual<string>("Timothy Nelson", testName.GetFullName());
        }
    }
}