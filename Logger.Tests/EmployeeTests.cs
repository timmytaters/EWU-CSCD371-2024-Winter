using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void EmployeeTest()
        {
            FullName testName = new("Timothy", "August", "Nelson");
            Employee testEmployee = new(testName, 181);
            Assert.AreEqual<string>("Timothy August Nelson", testEmployee.Name);
            Assert.AreEqual<int>(181, testEmployee.EmployeeID);
        }
    }
}
