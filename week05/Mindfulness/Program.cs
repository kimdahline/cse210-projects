using System;

class Program
{
    static void Main(string[] args)
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice: ");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    keepRunning = false;
                    continue;
                default:
                    Console.WriteLine("Please choose 1, 2, 3, or 4.");
                    Console.WriteLine("Press Enter to try again.");
                    Console.ReadLine();
                    continue;
            }

            activity.Run();
            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }

        Console.WriteLine("Thank you for taking time for mindfulness.");
    }
}
// Creativity feature: Reflection questions are shuffled and are not repeated until every question has been shown during that activity session.
