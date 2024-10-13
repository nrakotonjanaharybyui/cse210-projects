using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {   
        // Creates a new journal
        Journal journal = new Journal();

        // Creates a new promt
        Prompt prompt = new Prompt();
        int pLength = prompt.getLength();

        // Creates a random int to iterate through the prompt
        Random randomizer = new Random();
        int index = randomizer.Next(0, pLength);

        // Date to be used to create entries
        DateTime date = DateTime.Now;

        // Default answer to start the loop
        int answer = 0;

        // Gets all the journal file present in the directory
        string path = Directory.GetCurrentDirectory();
        string[] files = Directory.GetFiles(path, "*.txt");
        List<string> allJournal = new List<string>();
        foreach (string fileN in files)
        {
            allJournal.Add(Path.GetFileName(fileN));
        }

        // Loops through to ask the user to choose between options
        while (answer != 5)
        {
            // Display the options
            Console.WriteLine($"Please select one of the following choices:");
            Console.WriteLine($"1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.WriteLine($"What would you like to do?");

            // Get the option
            int answerInput = int.Parse(Console.ReadLine());

            // Runs a function depending on the choice
            if(answerInput == 1)
            {
                Write(journal, prompt, date, index);
                
                // Index handler that cycles throught the different elements of the prompt
                if (index < pLength - 1)
                {
                    index += 1;
                }
                else
                {
                    index = 0;
                }          
            }
            else if(answerInput == 2)
            {
                if(journal.empty)
                {
                    Console.WriteLine("----------------\n!! There is nothing to diplay yet !!\n----------------");
                    Console.WriteLine("You can choose between the following files to load");
                    foreach(string journalFile in allJournal)
                    {
                        Console.WriteLine(journalFile);
                    }
                    Console.WriteLine("----------------\n");
                }
                else
                {
                    Display(journal);
                }
            }
            else if(answerInput == 3)
            {
                Load(journal);
            }
            else if(answerInput == 4)
            {
                if(journal.empty)
                {
                    Console.WriteLine("----------------\n!! There is nothing to save yet !!\n----------------");
                }
                else
                {
                    Save(journal);
                }
            }
            else if(answerInput == 5)
            {
                answer = answerInput;
            }
        }        
    }

    private static void Save(Journal journal)
    {
        journal.SaveJournal();
    }

    private static void Load(Journal journal)
    {
        journal.LoadJournal();
    }

    private static void Display(Journal journal)
    {
        journal.DisplayJournal();
    }

    private static void Write(Journal journal, Prompt prompt, DateTime date, int index)
    {   
        // Generates a prompt and cycles through the prompt object as long as the user asks to write
        string currentPrompt = prompt.GeneratePrompt(index);

        Console.WriteLine(currentPrompt);

        // Gets user input
        string userInput = Console.ReadLine();

        // Creates a new entry
        Entry entry = new Entry(userInput, currentPrompt, date);

        // Store the entry in the journal
        journal.WriteJournal(entry);            
    }
}