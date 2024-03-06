using Xunit;

namespace Assignment.Tests;

public class NodeTests
{
    [Fact]
    public void Append_AddsNewNodeToLinkedList()
    {
        // Arrange
        var node = new Node<int>(1);

        // Act
        node.Append(2);

        // Assert
        Assert.Equal(2, node.Next.Value);
    }

    [Fact]
    public void Append_ThrowsExceptionIfValueExists()
    {
        // Arrange
        var node = new Node<int>(1);
        node.Append(2);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => node.Append(2));
    }

    [Fact]
    public void Clear_RemovesAllNodesExceptCurrent()
    {
        // Arrange
        var node = new Node<int>(1);
        node.Append(2);

        // Act
        node.Clear();

        // Assert
        Assert.Same(node, node.Next);
    }

    [Fact]
    public void Exists_ReturnsTrueIfValueExists()
    {
        // Arrange
        var node = new Node<int>(1);
        node.Append(2);

        // Act & Assert
        Assert.True(node.Exists(2));
    }

    [Fact]
    public void Exists_ReturnsFalseIfValueDoesNotExist()
    {
        // Arrange
        var node = new Node<int>(1);
        node.Append(2);

        // Act & Assert
        Assert.False(node.Exists(3));
    }

    [Fact]
    public void GetEnumerator_ReturnsAllItemsInCircle()
    {
        // Arrange
        var node = new Node<int>(1);
        node.Append(2);
        node.Append(3);

        // Act
        var result = node.ToList();

        // Assert
        Assert.Equal(1, result[0]);
        Assert.Equal(2, result[1]);
        Assert.Equal(3, result[2]);
    }

    [Fact]
    public void ChildItems_ReturnsRemainingItemsWithMaximum()
    {
        // Arrange
        var node = new Node<int>(1);
        node.Append(2);
        node.Append(3);

        // Act
        var result = node.ChildItems(2).ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(2, result[0]);
        Assert.Equal(3, result[1]);
    }

}


