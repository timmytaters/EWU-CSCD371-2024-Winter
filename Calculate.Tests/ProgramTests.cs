using System.Runtime.CompilerServices;

namespace Calculate.Tests;
//Write a test that sets these properties at construction time and then invokes the properties and verifies the expected behavior occurs. ❌✔
[TestClass]
public class ProgramTests
{
    private static string Output = "";
    Func<string> TestInput = () => "63 / 9";
    private static void Out(string s)
    {
        Output += s;
    }
    Action<string> TestOutput = Out;
    [TestMethod]
    public void Program_ChangeInput_Succeeds()
    {
        int? answer;
        Program program = new()
        {
            ReadLine = TestInput
        };
        Calculate calculator = new();
        string? input = program.ReadLine();

#pragma warning disable CS8604 // Possible null reference argument, if input null will throw error anyway, shouldn't be for premise
        calculator.TryCalculate(input, out answer);
#pragma warning restore CS8604 
        Assert.AreEqual<int?>(7, answer);
    }
    [TestMethod]
    public void Program_ChangeOutput_Succeeds()
    {
        Program program = new()
        {
            WriteLine = TestOutput
        };
        program.WriteLine("Yes");
        Assert.AreEqual<string>("Yes", Output);
    }
    [TestMethod]
    public void Program_WriteLineAndReadLine_Succeeds()
    {
        // Arrange
        string expected = "Hello frieds!";
        string actual = string.Empty;
        Program program = new()
        {
            WriteLine = (s) => actual = s,
            ReadLine = () => expected
        };

        // Act
        program.WriteLine(expected);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
