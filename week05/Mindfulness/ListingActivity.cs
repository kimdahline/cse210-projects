using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("\nYou may begin in:");
        ShowCountDown(Math.Min(5, Duration));

        Console.WriteLine("\nStart listing items. Press Enter after each item.");
        Stopwatch timer = Stopwatch.StartNew();
        int itemCount = 0;

        while (timer.Elapsed.TotalSeconds < Duration)
        {
            Console.Write("> ");
            string response = Console.ReadLine();

            // Count the response for which the user was already prompted, then let the loop check the time.
            if (!string.IsNullOrWhiteSpace(response))
            {
                itemCount++;
            }
        }

        Console.WriteLine($"\nYou listed {itemCount} item(s).");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int index = Random.Shared.Next(_prompts.Count);
        return _prompts[index];
    }
}

