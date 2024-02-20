/*Define a Program Class
Define two init-only setter properties, WriteLine and ReadLine, that contain delegates for writing a line of text and reading a line of text respectively ❌✔

Set the default behavior for the WriteLine and ReadLine properties to invoke System.Console versions of the methods and add an empty default constructor. ❌✔*/

namespace Calculate;

public class Program
{

    // These properties are guaranteed to be non-null because of the 'init' setter,
    // which mandates that they are initialized either during object instantiation or within a constructor.
    public Action<string> WriteLine { get; init; } = Console.WriteLine;
    public Func<string?> ReadLine { get; init; } = Console.ReadLine;

    public Program() { }

    public static void Main(string[] args)
    {
        Program program = new();
        Calculate calculator = new();
        string input;
        int? answer;

        do
#pragma warning disable CS8604 // Possible null reference argument, input never null since either empty string or readline (when readline isnt null)
        {
            program.WriteLine("Please enter the problem (num operator num): ");
            if(program.ReadLine == null)
            {
                input = "";
            }
            else
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type, okay since null checked above
                input = program.ReadLine();
#pragma warning restore CS8600 
            }

        } while (!calculator.TryCalculate(input, out answer));
#pragma warning restore CS8604 

        program.WriteLine($"The answer is: {answer}");

    }

}