using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.Metrics;
using System.IO;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GenericsHomework.Tests;
#pragma warning disable CS8603

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
        Assert.ThrowsException<ArgumentException>(() => newNode.Append(1));
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
        string Expected = "1";
        Assert.AreEqual<String>(Expected, newNode.ToString());
    }
    [TestMethod]
    public void Clear_MultipleNodes_True()
    {
        Node<string> newNode = new("I Loveeeee .Net!!!");
        newNode.Append("Node1");
        newNode.Append("Node2");
        newNode.Clear();
        Assert.AreEqual(newNode, newNode.Next);
    }
}
#pragma warning restore CS8603