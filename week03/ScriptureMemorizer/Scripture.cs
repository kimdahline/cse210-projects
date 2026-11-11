using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private static Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] wordTexts = text.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string wordText in wordTexts)
        {
            _words.Add(new Word(wordText));
        }
    }

    public string GetDisplayText()
    {
        string wordsText = string.Join(
            " ",
            _words.Select(word => word.GetDisplayText())
        );

        return $"{_reference.GetDisplayText()} {wordsText}";
    }

    public void HideRandomWords(int count)
    {
        for (int i = 0; i < count; i++)
        {
            List<Word> visibleWords = _words
                .Where(word => !word.IsHidden())
                .ToList();

            if (visibleWords.Count == 0)
            {
                break;
            }

            int randomIndex = _random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}