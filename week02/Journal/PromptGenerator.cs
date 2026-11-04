public class PromptGenerator
{
    private List<string> _prompts;
    private Random _random;

    public PromptGenerator()
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "What was the best part of my day?",
            "What did I learn today?",
            "Who was the most interesting person I interacted with today?",
            "What was the strongest emotion I felt today?",
            "What am I grateful for today?",
            "What challenge did I overcome today?",
            "How did I see the hand of the Lord in my life today?",
            "What is one thing I would like to improve tomorrow?",
            "What made me smile today?",
            "What is one thing I would do differently today?"
        };
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);

        return _prompts[index];
    }
}