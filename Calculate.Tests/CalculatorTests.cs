namespace Calculate.Tests;


[TestClass]
public class CalculateTests
{
    [TestMethod]
    public void Addition_WithInts_Succeeds()
    {
        Assert.AreEqual<int>(63, Calculate.Addition(21,42));
    }
    [TestMethod]
    public void Subtraction_WithInts_Succeeds()
    {
        Assert.AreEqual<int>(63, Calculate.Subtraction(84, 21));
    }
    [TestMethod]
    public void Multiplication_WithInts_Succeeds()
    {
        Assert.AreEqual<int>(63, Calculate.Multiplication(9, 7));
    }
    [TestMethod]
    public void Division_WithInts_Succeeds()
    {
        Assert.AreEqual<int>(63, Calculate.Division(189, 3));
    }
    [TestMethod]
    public void Division_WithZero_Fails()
    {
        Assert.ThrowsException<ArgumentException>(() => Calculate.Division(53, 0));
    }
    [TestMethod]
    public void TryCalculate_Add_Succeeds()
    {
        Calculate calculator = new();
        int? answer;
        Assert.IsTrue(calculator.TryCalculate("21 + 42", out answer));
        Assert.AreEqual<int?>(63, answer);
    }
    [TestMethod]
    public void TryCalculate_Sub_Succeeds()
    {
        Calculate calculator = new();
        int? answer;
        Assert.IsTrue(calculator.TryCalculate("84 - 21", out answer));
        Assert.AreEqual<int?>(63, answer);
    }
    [TestMethod]
    public void TryCalculate_Mult_Succeeds()
    {
        Calculate calculator = new();
        int? answer;
        Assert.IsTrue(calculator.TryCalculate("9 * 7", out answer));
        Assert.AreEqual<int?>(63, answer);
    }
    [TestMethod]
    public void TryCalculate_Div_Succeeds()
    {
        Calculate calculator = new();
        int? answer;
        Assert.IsTrue(calculator.TryCalculate("189 / 3", out answer));
        Assert.AreEqual<int?>(63, answer);
    }
    [TestMethod]
    public void TryCalculate_NotEnoughArgs_Fails()
    {
        Calculate calculator = new();
        int? answer;
        Assert.IsFalse(calculator.TryCalculate(" 3 *", out answer));
        Assert.IsNull(answer);
    }
}