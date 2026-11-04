using System.Text.Json;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is currently empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        string json = JsonSerializer.Serialize(
            _entries,
            new JsonSerializerOptions { WriteIndented = true }
        );

        File.WriteAllText(file, json);

        Console.WriteLine("Journal saved successfully!");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            throw new FileNotFoundException(
                "The specified journal file was not found."
            );
        }

        string json = File.ReadAllText(file);

        List<Entry> loadedEntries =
            JsonSerializer.Deserialize<List<Entry>>(json);

        if (loadedEntries == null)
        {
            throw new InvalidDataException(
                "The journal file does not contain valid journal data."
            );
        }

        _entries.Clear();
        _entries.AddRange(loadedEntries);

        Console.WriteLine("Journal loaded successfully!");
    }

    // Extra feature: Search journal entries using keywords.
    public void SearchEntries(string keyword)
    {
        bool found = false;

        foreach (Entry entry in _entries)
        {
            if (entry.EntryText.Contains(
                keyword,
                StringComparison.OrdinalIgnoreCase
            ) ||
            entry.PromptText.Contains(
                keyword,
                StringComparison.OrdinalIgnoreCase
            ))
            {
                entry.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No matching journal entries were found.");
        }
    }
}