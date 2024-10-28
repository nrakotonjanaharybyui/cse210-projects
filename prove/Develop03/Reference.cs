using System;

// Implements the Reference class which is similar to a verse in the scriptures
// It is made of multiple words
// The reference can be hidden or not

public class Reference
{
    // member variables
    private List<Word> _content; // List of Word objects which is the content
    private int _number; // The number of the verse
    private bool _isHidden; // The status of the Reference (the whole sentence or Word set)
    private List<int> _hiddenIndex; // List of the hidden indexes
    private List<int> _visibleIndex; // List of the visible indexes
    private Random _randomizer; // Used to generate random indexes to hide Words

    // Constructor
    // Takes as parameter a tuple of int (number) and a string (content)
    public Reference((int, string) content)
    {
        _content = [];
        foreach (string item in content.Item2.Split(' '))
        {
            // Creates a Word object out of each word in the provided content (paragraph) and adds it to the _content list
            _content.Add(new Word(item));
        }

        // Sets the _number variable to the value of the first element in the Tuple
        _number = content.Item1;

        _visibleIndex = []; // An empty list to store the visible indexes
        for (int i = 0; i < _content.Count(); i++) // Populates the visible index list
        {
            _visibleIndex.Add(i);
        }
        _isHidden = false; // is hidden is set to false by default
        _hiddenIndex = []; // hidden indexes is empty by default
        _randomizer = new Random(); // intializes the randomizer object
    }

    // Getters
    // Gets starter content
    public string GetStartContent() // Returns the starter content, where all the words are visible
    {
        SyncContent(); // synchronizes the "is hidden" variable with the actual state of all words in the content
        string result = "";
        foreach (Word word in _content) // Constructs the content from an iteration on the _content items
        {
            result += word.GetWord();
            result += ' ';
        }
        return result;
    }

    // Gets the content and hides random words
    // Returns the string content with hidden words
    public string GetContent()
    {
        SyncContent();
        string result = "";
        for (int i = 0; i < 3; i++)
        {   
            if (_hiddenIndex.Count == 0)
            {
                int index = _randomizer.Next(0, _content.Count);
                _hiddenIndex.Add(index);
                _visibleIndex.Remove(index);
                _content[index].HideWord();
            }
            else if(_hiddenIndex.Count == _content.Count)
            {
                foreach(Word word in _content)
                {
                    word.HideWord();
                }
            }
            else
            {
                int index = _randomizer.Next(_visibleIndex.Count);
                _hiddenIndex.Add(_visibleIndex[index]);
                _content[_visibleIndex[index]].HideWord();
                _visibleIndex.Remove(_visibleIndex[index]);

                /* // int index = 0;
                // foreach (int hiddenIndex in _hiddenIndex)
                // {
                //     do
                //     {
                //         index = _randomizer.Next(0, _content.Count);
                //     } while (index == hiddenIndex);
                // }
                // _hiddenIndex.Add(index);
                // _content[index].HideWord();''' */
            }
        }
        
        foreach (Word word in _content)
        {
            result += word.GetWord();
            result += ' ';
        }
        return result;
    }

    // Returns the number of the reference
    public int GetNumber()
    {
        return _number;
    }

    // Returns the "hidden" state of the reference
    public bool GetIsHidden()
    {   
        SyncContent();
        return _isHidden;
    }

    // Synchorizes the "is hidden" state with the individual state of each word in the _content list
    private void SyncContent()
    {
        int limit = 0;
        foreach (Word word in _content)
        {
            if (word.GetIsHidden())
            {
                limit += 1;
            }
        }
        if (limit == _content.Count())
        {
            _isHidden = true;
        }
    }
}