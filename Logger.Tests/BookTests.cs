using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.Metrics;
using System.IO;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Logger.Tests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void BookTest()
        {
            Book testBook = new("Of Mice and Men");
            Assert.AreEqual<string>("Of Mice and Men", testBook.Name);
        }
    }
}
