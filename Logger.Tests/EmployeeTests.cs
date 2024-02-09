using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests;

[TestClass]
public class EmployeeTests
{
    [TestMethod]
    public void EmployeeConstructor_GivenProperties_Succeeds()
    {
        FullName testName = new("Timothy", "August", "Nelson");
        Employee testEmployee = new(testName, 181);
        Assert.AreEqual<string>("Timothy August Nelson", testEmployee.Name);
        Assert.AreEqual<int>(181, testEmployee.EmployeeID);
    }
    [TestMethod]
    public void EmployeeIDSet_GivenInt_SetsID()
    {
        FullName testName = new("Timothy", "August", "Nelson");
        #pragma warning disable IDE0017
        Employee testEmployee = new(testName, 181);
        #pragma warning restore IDE0017
        testEmployee.EmployeeID = 21;
        Assert.AreEqual<double>(21, testEmployee.EmployeeID);
    }

}
