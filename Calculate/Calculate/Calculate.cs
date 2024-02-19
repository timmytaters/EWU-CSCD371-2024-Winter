/*Define a Calculator class ❌✔
Define static Add, Subtract, Multiple, and Divide methods that have two parameters and return a third parameter. ❌✔
Define a read-only property, MathematicalOperations, of type System.Collections.Generics.IReadOnlyDictionary<TKey,TValue> that:
is initialized to a System.Collections.Generics.Dictionary<<TKey,TValue> instance that. ❌✔
Uses char for the key corresponding to the operators +, -, *, and /. ❌✔
Has values that correspond with the Add, Subtract, Multiple, and Divide methods. ❌✔
Implement a TryCalculate method following "TryParse" pattern ❌✔
Valid calculation expressions include such strings as "3 + 4", "42 - 2", etc. ❌✔
If there is no whitespace around the operator, you can assume the calculation is invalid and return false. Similarly if the operands are not integers. ❌✔
Use string.Split(), pattern matching, logical and operators to parse the string in their entirety ❌✔
Index into the MathematicalOperations method using the operator parsed during pattern matching to find the corresponding implementation and invoke it. ❌✔*/

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
