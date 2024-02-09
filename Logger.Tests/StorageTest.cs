using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace Logger.Tests;
#pragma warning disable CA1707

[TestClass]
public class StorageTest
{

    [TestMethod]
    public void Add_StudentEntity_AddSucessful()
    {
        // Arrange
        Storage storage = new();
        IEntity student = new Student(new FullName("Timothy", "", "Nelson"), 4.0);

        // Act
        storage.Add(student);

        // Assert
        Assert.IsTrue(storage.Contains(student));
    }

    [TestMethod]
    public void Remove_StudentEntity_RemovesSucessful()
    {
        // Arrange
        Storage storage = new();
        IEntity student = new Student(new FullName("Robert", "", "Garcia"), 3.0);
        storage.Add(student);

        // Act
        storage.Remove(student);

        // Assert
        Assert.IsFalse(storage.Contains(student));
    }

    [TestMethod]
    public void Add_BookEntity_AddSucessful()
    {
        // Arrange
        Storage storage = new();
        IEntity book = new Book("The Fault in our Stars");

        // Act
        storage.Add(book);

        // Assert
        Assert.IsTrue(storage.Contains(book));
    }

    [TestMethod]
    public void Remove_BookEntity_RemoveSucessful()
    {
        // Arrange
        Storage storage = new();
        IEntity book = new Book("50 Shades of Grey");
        storage.Add(book);

        // Act
        storage.Remove(book);

        // Assert
        Assert.IsFalse(storage.Contains(book));
    }

}