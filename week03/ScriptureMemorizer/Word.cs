public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        char[] hiddenText = _text.ToCharArray();

        for (int i = 0; i < hiddenText.Length; i++)
        {
            if (char.IsLetter(hiddenText[i]))
            {
                hiddenText[i] = '_';
            }
        }

        return new string(hiddenText);
    }

    public bool IsHidden()
    {
        return _isHidden;
    }
}