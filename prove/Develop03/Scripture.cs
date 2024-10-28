using System;
using System.Reflection.Metadata;
using System.Xml.XPath;

// Implements the Scripture class

public class Scripture
{
    // Member variables
    private string _chapter; // The chapter details
    private List<Reference> _references; // List of all references in the scripture
    private bool _hasStarted; // "Has started" state
    private bool _hasEnded; // "Has ended" state
    private string _verses; // String representation of the number of the verses (references)

    // Constructor
    // Takes 2 param: Name of the chapter && a list of tuples, made up with the (number of the verse, the content of the verse)
    public Scripture(string chapter, List<(int, string)> references)
    {
        _references = [];
        _chapter = chapter;
        foreach ((int, string) item in references)
        {
            _references.Add(new Reference(item)); // Creates a new reference with each entry in the list of tuples and adds it to the _references list
        }
        _hasStarted = false;
        _hasEnded = false;
        _verses = GetVerses();
    }

    // Get Scripture method
    // Returns a string representation of the scripture
    public string GetScripture()
    {
        string result = _chapter + ": " + _verses;
        if (!_hasStarted)
        {
            foreach (Reference reference in _references)
            {
                result += reference.GetStartContent();
            }
            _hasStarted = true;
            return result;
        }
        else
        {
            foreach (Reference reference in _references)
            {
                result += reference.GetContent();
            }
            return result;
        }        
    }

    // Get Has Ended Method
    public bool GetHasEnded()
    {
        int limit = 0;
        foreach (Reference reference in _references)
        {
            if (reference.GetIsHidden())
            {
                limit += 1;
            }
        }
        if(limit == _references.Count())
        {
            _hasEnded = true;
        }
        return _hasEnded;
    }

    // Returns a string representation of the number of the verses (references) in the _references
    // Will be used to create a string representation of the scripture
    private string GetVerses()
    {
        if(_references.Count == 1)
        {
            return _references[0].GetNumber().ToString() + " ";
        }
        else
        {
            string result = "";
            string first = _references[0].GetNumber().ToString();
            string last = _references[_references.Count - 1].GetNumber().ToString();
            result += first + "-" + last + " ";
            return result;
        }
    }
}