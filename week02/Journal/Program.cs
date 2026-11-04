/*
 * Additional Features Beyond Core Requirements:
 *
 * 1. JSON Storage:
 * The program uses JSON to save and load journal entries.
 * This provides structured storage and makes the journal
 * data easier to read and manage.
 *
 * 2. Journal Search:
 * Users can search their saved journal entries using keywords.
 * The search is case-insensitive and checks both prompts
 * and responses.
 *
 * 3. Input Validation:
 * The program prevents empty journal responses and invalid
 * filenames from being submitted.
 *
 * 4. Additional Prompts:
 * The program provides ten different writing prompts,
 * exceeding the minimum requirement of five.
 */

public class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        Console.WriteLine("================================");
        Console.WriteLine("       MY JOURNAL PROGRAM       ");
        Console.WriteLine("================================");

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");

            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load the journal");
            Console.WriteLine("4. Save the journal");
            Console.WriteLine("5. Search journal entries");
            Console.WriteLine("6. Quit");

            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteEntry(journal, promptGenerator);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    LoadJournal(journal);
                    break;

                case "4":
                    SaveJournal(journal);
                    break;

                case "5":
                    SearchJournal(journal);
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Thank you for using My Journal!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void WriteEntry(
        Journal journal,
        PromptGenerator promptGenerator
    )
    {
        string prompt = promptGenerator.GetRandomPrompt();

        Console.WriteLine();
        Console.WriteLine($"Prompt: {prompt}");

        Console.Write("Your response: ");

        string response = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(response))
        {
            Console.WriteLine("Your response cannot be empty.");
            return;
        }

        string date = DateTime.Now.ToString("yyyy-MM-dd");

        Entry newEntry = new Entry(date, prompt, response);

        journal.AddEntry(newEntry);

        Console.WriteLine("Your journal entry has been recorded!");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter the filename to save your journal: ");

        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Please enter a valid filename.");
            return;
        }

        try
        {
            journal.SaveToFile(filename);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving journal: {e.Message}");
        }
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter the filename to load your journal: ");

        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Please enter a valid filename.");
            return;
        }

        try
        {
            journal.LoadFromFile(filename);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading journal: {e.Message}");
        }
    }

    static void SearchJournal(Journal journal)
    {
        Console.Write("Enter a keyword to search for: ");

        string keyword = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(keyword))
        {
            Console.WriteLine("Please enter a search keyword.");
            return;
        }

        journal.SearchEntries(keyword);
    }
}