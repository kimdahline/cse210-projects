public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public string Date
    {
        get { return _date; }
        set { _date = value; }
    }

    public string PromptText
    {
        get { return _promptText; }
        set { _promptText = value; }
    }

    public string EntryText
    {
        get { return _entryText; }
        set { _entryText = value; }
    }

    public Entry()
    {
        _date = "";
        _promptText = "";
        _entryText = "";
    }

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine("--------------------------------");
    }
}