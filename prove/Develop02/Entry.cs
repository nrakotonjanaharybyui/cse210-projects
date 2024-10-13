using System;

public class Entry
{
    private string _description;
    private string _prompt;
    private DateTime _date;

    // Constructor function
    // Param: string description, string prompt, DateTime date
    public Entry(string description, string prompt, DateTime date)
    {
        _description = description;
        _prompt = prompt;
        _date = date;
    }

    // Displayer function
    public void DisplayEntry()
    {
        Console.WriteLine($"{_date.ToShortDateString()}: {_prompt}\n{_description}");
    }

    public string EntryToStringSave()
    {
        return $"{_date}||{_prompt}||{_description}";
    }

}