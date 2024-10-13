using System;
using System.IO;

public class Journal
{
    private string _fileName;
    private List<Entry> _entries = new List<Entry>();
    public bool empty = true;


    // Write Journal function
    public void WriteJournal(Entry entry)
    {
        _entries.Add(entry);
        empty = false;
    }
    // TODO Load Journal function
    public void LoadJournal()
    {
        // Ask the user for the file name
        Console.WriteLine("What is the file name?");
        _fileName = Console.ReadLine();

        // Reading the content of the file and store it in a list
        string[] lines = System.IO.File.ReadAllLines(_fileName);

        // Create a Entry object for each text entry
        foreach (string line in lines)
        {
            // Gathers the information at the line an creates variables
            string[] parts = line.Split("||");
            DateTime date = DateTime.Parse(parts[0]);
            string prompt = parts[1];
            string description = parts[2];

            // Creates a new Entry object and adds it to the entry list
            _entries.Add(new Entry(description, prompt, date));
        }
        empty = false;
    }

    // Save Journal function
    public void SaveJournal()
    {
        // Ask the user for the file name
        Console.WriteLine("What is the file name?");
        _fileName = Console.ReadLine();

        // Creates a StreamWriter object to write to the file
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            // Loops the _entries list and writes to the _fileName
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.EntryToStringSave());
            }
        }
    }

    // TODO Display Journal function
    public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
            Console.WriteLine("");
        }
    }
}