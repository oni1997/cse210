using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Returns the word's display text based on whether it's hidden or not
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            // Replace each letter with an underscore
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }

    // Hides the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Shows the word
    public void Show()
    {
        _isHidden = false;
    }

    // Returns whether the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }
}