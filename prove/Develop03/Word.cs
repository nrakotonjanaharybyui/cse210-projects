using System;

// Name: Word
// Can be hidden or not

public class Word
{
    // variables
    private string _content; // The string content of the object
    private string _hiddenContent; // The hidden version of the object
    private bool _isHidden; // The "is hidden" status of the object

    // Constructor Function takes one string argument
    public Word(string content)
    {
        _content = content; // Sets the value of the content
        _isHidden = false; // Sets the default value of the "is hidden" state
        _hiddenContent = new string('_', _content.Length); // Creates the hidden content version of the object
    }

    // Setters
    // Sets the _isHidden to true
    public void HideWord()
    {
        _isHidden = true;
    }

    // Getters
    // Gets the word
    public string GetWord()
    {
        if(_isHidden) // returns the hidden content if the status is hidden
        {
            return _hiddenContent;
        }
        else // returns the actual content if the status is NOT hidden
        {
            return _content;
        }
    }

    // Gets the _isHidden state
    public bool GetIsHidden()
    {
        return _isHidden;
    }
}