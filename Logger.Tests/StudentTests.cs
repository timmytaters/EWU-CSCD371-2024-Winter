using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests;

[TestClass]
public class StudentTests
{
    [TestMethod]
    //getter also tested
    public void StudentConstructor_GivenProperties_Succeeds()
    {
        FullName testName = new("Timothy", "August", "Nelson");
        Student testStudent = new(testName, 3.55);
        Assert.AreEqual<string>("Timothy August Nelson", testStudent.Name);
        Assert.AreEqual<double>(3.55, testStudent.GPA);
    }
    [TestMethod]
    public void StudentGPASet_GivenDouble_SetsGPA()
    {
        FullName testName = new("Timothy", "August", "Nelson");
        #pragma warning disable IDE0017 
        Student testStudent = new(testName, 3.55);
        #pragma warning restore IDE0017
        testStudent.GPA = 2.1;
        Assert.AreEqual<double>(2.1, testStudent.GPA);
    }

}