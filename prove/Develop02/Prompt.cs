using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

public class Prompt
{
    private List<string> _prompts = new List<string>();

    // Initializes the object and populate the prompts list
    public Prompt()
    {
    _prompts.Add("If I had one thing I could do over today, what would it be?");
    _prompts.Add("What was the best part of my day?");
    _prompts.Add("Who was the most interesting person I interacted with today?");
    _prompts.Add("What is a truth that you discovered today?");
    _prompts.Add("Did you use your talent today?");
    _prompts.Add("Is there someone you miss today?");
    }

    // Returns a prompt to the caller
    // Param int: index
    public string GeneratePrompt(int index)
    {       
        return(_prompts[index]);
    }

    // Returns the length of the prompt list
    public int getLength()
    {
        return _prompts.Count;
    }

}