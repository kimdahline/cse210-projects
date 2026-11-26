using System;
using System.Diagnostics;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Stopwatch timer = Stopwatch.StartNew();
        bool breatheIn = true;

        while (timer.Elapsed.TotalSeconds < Duration)
        {
            int seconds = Math.Min(4, (int)Math.Ceiling(Duration - timer.Elapsed.TotalSeconds));
            if (seconds <= 0)
            {
                break;
            }

            Console.Write(breatheIn ? "\nBreathe in... " : "\nBreathe out... ");
            ShowCountDown(seconds);
            breatheIn = !breatheIn;
        }

        DisplayEndingMessage();
    }
}
