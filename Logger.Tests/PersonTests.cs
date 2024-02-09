using Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Logger.Tests;
[TestClass]
public class PersonTests
{
    [TestMethod]
    public void EmployeeConstructor_GivenProperties_Succeeds()
    {
        FullName testName = new("Timothy", "August", "Nelson");
        Person testPerson = new(testName);
        Assert.AreEqual<string>("Timothy August Nelson", testPerson.Name);
    }
}