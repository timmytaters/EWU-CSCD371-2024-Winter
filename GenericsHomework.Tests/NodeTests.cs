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
    public void Constructor_GivenData_Succeeds()
    {
        Node<int> newNode = new(1);
        Assert.AreEqual<Node<int>>(newNode, newNode.Next);
        Assert.AreEqual<int>(1, newNode.Data);
    }
    [TestMethod]
    public void Append_GivenDuplicate_ThrowsException()
    {
        Node<int> newNode = new(1);
        Assert.ThrowsException<InvalidOperationException>(() => newNode.Append(1));
    }
    [TestMethod]
    public void Append_GivenUnique_Succeeds()
    {
        Node<int> newNode = new(1);
        newNode.Append(2);
        Assert.AreEqual(2, newNode.Next.Data);
    }
    [TestMethod]
    public void Exists_DoesExist_True()
    {
        Node<int> newNode = new(1);
        newNode.Append(2);
        Assert.AreEqual<Boolean>(true, newNode.Exists(2));
    }
    [TestMethod]
    public void Exists_DoesntExist_False()
    {
        Node<int> newNode = new(1);
        newNode.Append(3);
        Assert.AreEqual<Boolean>(false, newNode.Exists(2));
    }
    [TestMethod]
    public void Clear_OnClear_NoOtherNodes()
    {
        Node<int> newNode = new(1);
        newNode.Append(3);
        newNode.Clear();
        Assert.AreEqual<Boolean>(false, newNode.Exists(3));
    }
    [TestMethod]
    public void Clear_OnClear_NodeRemains()
    {
        Node<int> newNode = new(1);
        newNode.Append(3);
        newNode.Clear();
        Assert.AreEqual<Boolean>(true, newNode.Exists(1));
    }
    [TestMethod]
    public void ToString_WithList_Prints()
    {
        Node<int> newNode = new(1);
        newNode.Append(2);
        newNode.Append(3);
        string Expected = "LinkedList: 1 - 3 - 2";
        Assert.AreEqual<String>(Expected, newNode.ToString());
    }
}