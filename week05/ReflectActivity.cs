using System;
using System.Collections.Generic;

public class ReflectActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done something like this before?",
        "How did you get started?",
        "How did you feel when it was over?",
        "What made this time different from other times when you were not as successful?",
        "What is your favorite part of this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?"
    };

    private List<string> _unusedQuestions = new List<string>();
    private Random _random = new Random();

    public ReflectActivity() : base("Reflection Activity", 
        "This activity will help you reflect on times in your life when you showed strength and resilience. This will help you recognize the strength you have and how you can use it in other parts of your life.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine("\nWhen you have something in mind, press ENTER to continue.");
        Console.ReadLine();

        Console.WriteLine("Now reflect on each of the following questions in relation to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(Math.Min(10, GetRemainingSeconds(endTime)));
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        // Exceeds core requirements: Questions do not repeat until all have been used.
        if (_unusedQuestions.Count == 0)
        {
            _unusedQuestions = new List<string>(_questions);
        }

        int index = _random.Next(_unusedQuestions.Count);
        string question = _unusedQuestions[index];
        _unusedQuestions.RemoveAt(index);

        return question;
    }
}
