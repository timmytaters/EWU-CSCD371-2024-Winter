namespace PrincessBrideTrivia;
//Timothy Nelson & Nathan Marsee, CSCD 371, Assignment 1
public class Program
{
    public static void Main(string[] args)
    {
        string filePath = GetFilePath();
        Question[] questions = LoadQuestions(filePath);
        Console.WriteLine("Enter h for the answer for a hint with half credit");
        double numberCorrect = 0.0;
        for (int i = 0; i < questions.Length; i++)
        {
            double result = AskQuestion(questions[i]);
            numberCorrect += result;
        }
        Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct");
    }

    public static string GetPercentCorrect(double numberCorrectAnswers, int numberOfQuestions)
    {
        return Math.Round((numberCorrectAnswers / numberOfQuestions * 100),2) + "%";
    }

    public static double AskQuestion(Question question)
    {
        DisplayQuestion(question);

        string userGuess = GetGuessFromUser();
        return DisplayResult(userGuess, question);
    }

    public static string GetGuessFromUser()
    {
        return Console.ReadLine();
    }

    public static double DisplayResult(string userGuess, Question question)
    {
        if(userGuess == "h")
        {
            Console.WriteLine(question.Hint);
            userGuess = Console.ReadLine();
            if (userGuess == question.CorrectAnswerIndex)
            {
                Console.WriteLine("Correct");
                return 0.5;
            }
        }
        else if (userGuess == question.CorrectAnswerIndex)
        {
            Console.WriteLine("Correct");
            return 1.0;
        }

        Console.WriteLine("Incorrect");
        return 0.0;
    }

    public static void DisplayQuestion(Question question)
    {
        Console.WriteLine("Question: " + question.Text);
        for (int i = 0; i < question.Answers.Length; i++)
        {
            Console.WriteLine((i + 1) + ": " + question.Answers[i]);
        }
    }

    public static string GetFilePath()
    {
        return "Trivia.txt";
    }

    public static Question[] LoadQuestions(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        Question[] questions = new Question[lines.Length / 6];
        for (int i = 0; i < questions.Length; i++)
        {
            int lineIndex = i * 6;
            string questionText = lines[lineIndex];

            string answer1 = lines[lineIndex + 1];
            string answer2 = lines[lineIndex + 2];
            string answer3 = lines[lineIndex + 3];

            string correctAnswerIndex = lines[lineIndex + 4];
            string hint = lines[lineIndex + 5];

            Question question = new();
            question.Text = questionText;
            question.Answers = new string[3];
            question.Answers[0] = answer1;
            question.Answers[1] = answer2;
            question.Answers[2] = answer3;
            question.CorrectAnswerIndex = correctAnswerIndex;
            question.Hint = hint;
            questions[i] = question;
        }
        return questions;
    }
}
