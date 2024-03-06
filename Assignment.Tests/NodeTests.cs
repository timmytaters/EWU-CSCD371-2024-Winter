using Xunit;

namespace Assignment.Tests;

public class NodeTests
{
    [Fact]
    public void Append_AddsNewNodeToLinkedList_ValueAppended_NodeContainsNewValue()
    {
        // Arrange
        var node = new Node<int>(1);

        // Act
        node.Append(2);

        // Assert
        Assert.Equal(2, node.Next.Value);
    }

    [Fact]
    public void Clear_RemovesAllNodesExceptCurrent_AllNodesExceptCurrentRemoved()
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
    public void Exists_ReturnsTrueIfValueExists_ValueExists_ReturnsTrue()
    {
        // Arrange
        var node = new Node<int>(1);
        node.Append(2);

        // Act & Assert
        Assert.True(node.Exists(2));
    }

    [Fact]
    public void Exists_ReturnsFalseIfValueDoesNotExist_ValueDoesNotExist_ReturnsFalse()
    {
        // Arrange
        var node = new Node<int>(1);
        node.Append(2);

        // Act & Assert
        Assert.False(node.Exists(3));
    }

    [Fact]
    public void Append_AddsNewItemToEndOfList_NewItemAppendedToEnd()
    {
        // Arrange
        var node = new Node<int>(1);

        // Act
        node.Append(2);
        node.Append(3);

        // Assert
        Assert.Equal(2, node.Next.Value); // Check if 2 is appended after 1
        Assert.Equal(3, node.Next.Next.Value); // Check if 3 is appended after 2
    }

    [Fact]
    public void ChildItems_ReturnsRemainingItemsWithMaximum_MaximumItemsReturned_Params_ExpectedResult()
    {
        // Arrange
        Node<int> headNode = new(1);
        headNode.Append(2);
        headNode.Append(8);

        // Act
        IEnumerable<int> test = headNode.ChildItems(2);
        int count = test.Count();

        // Assert
        Assert.Equal(2, count);
    }
    
}
