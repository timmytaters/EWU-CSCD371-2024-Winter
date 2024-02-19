namespace Calculate;

public class Program
{

    // These properties are guaranteed to be non-null because of the 'init' setter,
    // which mandates that they are initialized either during object instantiation or within a constructor.
    public Action<string> WriteLine { get; init; } = Console.WriteLine;
    public Func<string> ReadLine { get; init; } = Console.ReadLine;

    public Program() { }

    public static void Main(string[] args)
    {
        Program program = new();
        Calculator calculator = new();
        string input;
        int? answer;

        do
        {
            program.WriteLine("Please enter something: ");
            input = program.ReadLine();

        } while (!calculator.TryCalculate(input, out answer));

        program.WriteLine($"The answer is: {answer}");

    }

}