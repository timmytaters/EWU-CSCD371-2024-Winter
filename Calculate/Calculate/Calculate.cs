namespace Calculate;

public class Calculator
{
    public IReadOnlyDictionary<char, Func<int, int, int>> Operations { get; } =
        new Dictionary<char, Func<int, int, int>>()
        {
            ['+'] = Addition,
            ['-'] = Subtraction,
            ['*'] = Multiplication,
            ['/'] = Division
        };

    public static int Addition(int a, int b) => a + b;
    public static int Subtraction(int a, int b) => a - b;
    public static int Multiplication(int a, int b) => a * b;

    public static int Division(int dividend, int divisor)
    {
        if (divisor == 0)
        {
            throw new ArgumentException("Division by zero is undefined", nameof(divisor));
        }
        return dividend / divisor;

    }

    public bool TryCalculate(string expression, out int? result)
    {
        string[] components = expression.Split(" ");

        if (components.Length != 3)
        {
            result = null;
            return false;
        }
        else
        {
            if (int.TryParse(components[0], out int operand1) && int.TryParse(components[2], out int operand2))
            {
                if (Operations.ContainsKey(components[1][0]))
                {
                    try
                    {
                        char op = components[1][0];
                        Func<int, int, int> operation = Operations[op];
                        result = operation(operand1, operand2);
                        return true;
                    }
                    catch (FormatException)
                    {
                        throw new FormatException($"Unable to parse operands {components[0]} or {components[2]}");
                    }
                }
            }
        }

        result = null;
        return false;

    }

}
