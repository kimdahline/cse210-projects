using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine("\nWhen you have something in mind, take a moment to begin.");
        ShowSpinner(3);

        Stopwatch timer = Stopwatch.StartNew();
        List<string> questionsForThisSession = new List<string>(_questions);
        Shuffle(questionsForThisSession);

        while (timer.Elapsed.TotalSeconds < Duration)
        {
            if (questionsForThisSession.Count == 0)
            {
                questionsForThisSession = new List<string>(_questions);
                Shuffle(questionsForThisSession);
            }

            Console.WriteLine($"\n{questionsForThisSession[0]}");
            questionsForThisSession.RemoveAt(0);

            int remaining = (int)Math.Ceiling(Duration - timer.Elapsed.TotalSeconds);
            if (remaining <= 0)
            {
                break;
            }

            ShowSpinner(Math.Min(5, remaining));
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int index = Random.Shared.Next(_prompts.Count);
        return _prompts[index];
    }

    private void Shuffle(List<string> items)
    {
        for (int i = items.Count - 1; i > 0; i--)
        {
            int j = Random.Shared.Next(i + 1);
            (items[i], items[j]) = (items[j], items[i]);
        }
    }
}
