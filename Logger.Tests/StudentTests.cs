using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void StudentTest()
        {
            FullName testName = new("Timothy", "August", "Nelson");
            Student testStudent = new(testName, 3.55);
            Assert.AreEqual<string>("Timothy August Nelson", testStudent.Name);
            Assert.AreEqual<double>(3.55, testStudent.GPA);
        }
    }
}