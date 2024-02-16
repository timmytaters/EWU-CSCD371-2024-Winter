using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.Metrics;
using System.IO;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GenericsHomework.Tests;

[TestClass]
public class NodeTests
{
    [TestMethod]
    public void ConstructorGivenDataSucceeds()
    {
        Node<int> newNode = new(1);
        Assert.AreEqual<Node<int>>(newNode, newNode.Next);
        Assert.AreEqual<int>(1, newNode.Data);
    }
    [TestMethod]
    public void AppendGivenDuplicateThrowsException()
    {
        Node<int> newNode = new(1);
        Assert.ThrowsException<ArgumentException>(() => newNode.Append(1));
    }
    [TestMethod]
    public void AppendGivenUniqueSucceeds()
    {
        Node<int> newNode = new(1);
        newNode.Append(2);
        Assert.AreEqual(2, newNode.Next.Data);
    }
    [TestMethod]
    public void ExistsDoesExistTrue()
    {
        Node<int> newNode = new(1);
        newNode.Append(2);
        Assert.AreEqual<Boolean>(true, newNode.Exists(2));
    }
    [TestMethod]
    public void ExistsDoesntExistFalse()
    {
        Node<int> newNode = new(1);
        newNode.Append(3);
        Assert.AreEqual<Boolean>(false, newNode.Exists(2));
    }
    [TestMethod]
    public void ClearOnClearNoOtherNodes()
    {
        Node<int> newNode = new(1);
        newNode.Append(3);
        newNode.Clear();
        Assert.AreEqual<Boolean>(false, newNode.Exists(3));
    }
    [TestMethod]
    public void ClearOnClearNodeRemains()
    {
        Node<int> newNode = new(1);
        newNode.Append(3);
        newNode.Clear();
        Assert.AreEqual<Boolean>(true, newNode.Exists(1));
    }
    [TestMethod]
    public void ToStringWithListPrints()
    {
        Node<int> newNode = new(1);
        string Expected = "1";
        Assert.AreEqual<String>(Expected, newNode.ToString());
    }
    [TestMethod]
    public void ClearMultipleNodesTrue()
    {
        Node<string> newNode = new("I Loveeeee .Net!!!");
        newNode.Append("Node1");
        newNode.Append("Node2");
        newNode.Clear();
        Assert.AreEqual(newNode, newNode.Next);
    }
}
