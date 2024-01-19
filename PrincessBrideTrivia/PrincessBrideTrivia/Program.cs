﻿namespace PrincessBrideTrivia;
//Timothy Nelson & Nathan Marsee, CSCD 371, Assignment 1
public class Program
{
    private static int hints = 0;
    public static void Main(string[] args)
    {
        string filePath = GetFilePath();
        Question[] questions = LoadQuestions(filePath);
        Console.WriteLine("Enter h for the answer for a hint with half credit");
        double numberCorrect = 0.0;
        for (int i = 0; i < questions.Length; i++)
        {
            bool result = AskQuestion(questions[i]);
            if(result) 
            {
                numberCorrect++;
            }
        }
        numberCorrect = AdjustHints(numberCorrect, hints);
        Console.WriteLine("You got " + GetPercentCorrect(numberCorrect, questions.Length) + " correct");
    }
    public static double AdjustHints(double numberCorrect, int hints)
    {
        return numberCorrect - (0.5 * hints);
    }

    public static string GetPercentCorrect(double numberCorrectAnswers, int numberOfQuestions)
    {
        return Math.Round((numberCorrectAnswers / numberOfQuestions * 100),2) + "%";
    }

    public static bool AskQuestion(Question question)
    {
        DisplayQuestion(question);

        string userGuess = GetGuessFromUser();
        return DisplayResult(userGuess, question);
    }

    public static string GetGuessFromUser()
    {
        return Console.ReadLine();
    }

    public static bool DisplayResult(string userGuess, Question question)
    {
        if(userGuess == "h")
        {
            Console.WriteLine(question.Hint);
            userGuess = Console.ReadLine();
            if (userGuess == question.CorrectAnswerIndex)
            {
                Console.WriteLine("Correct");
                hints++;
                return true;
            }
        }
        else if (userGuess == question.CorrectAnswerIndex)
        {
            Console.WriteLine("Correct");
            return true;
        }

        Console.WriteLine("Incorrect");
        return false;
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
        string[] hints =
        [
            "Hint: He is talking to someone he dislikes",
            "Hint: His eyes are a primary color",
            "Hint: All you need is _",
            "Hint: It's easier to do this with six fingers",
            "Hint: What does Wesley fight in the swamp?",
            "Hint: It is not a real poison",
            "Hint: You can't be neither handed",
        ];
        Question[] questions = new Question[lines.Length / 5];
        for (int i = 0; i < questions.Length; i++)
        {
            int lineIndex = i * 5;
            string questionText = lines[lineIndex];

            string answer1 = lines[lineIndex + 1];
            string answer2 = lines[lineIndex + 2];
            string answer3 = lines[lineIndex + 3];

            string correctAnswerIndex = lines[lineIndex + 4];

            Question question = new();
            question.Text = questionText;
            question.Answers = new string[3];
            question.Answers[0] = answer1;
            question.Answers[1] = answer2;
            question.Answers[2] = answer3;
            question.CorrectAnswerIndex = correctAnswerIndex;
            question.Hint = hints[i];
            questions[i] = question;
        }
        return questions;
    }
}
