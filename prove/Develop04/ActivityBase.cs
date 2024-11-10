using System;

// Activity class
public class ActivityBase
{
    // Member variables
    private string _name; 
    private string _startingMessage; 
    private string _description;
    private string _endingMessage; 
    private int _duration; 

    public ActivityBase() // Main constructor
    {
        _name = "Activty";
        _startingMessage = $"Welcome to the {_name}.\n";
        _description = "This is a basic activity\n";
        _endingMessage = "This activity has ended";
    }

    /* Run functions and helpers */
    public void RunActivity() // Starter function
    {
        DisplayStart(); // Displays a welcoming message
        string duration = Console.ReadLine();
        _duration = int.Parse(duration); // Gets the desired duration
        PlayActivity();

    }

    public virtual void PlayActivity() // Main function implemented in subclasses that gets called when an activity is set to run
    {
        return;
    }

    /* Helper functions for RunActivity*/
    public void DisplayStart() // Clears the console, displays the welcome message and the description
    {
        Console.Clear();
        Console.WriteLine(_startingMessage);
        Console.WriteLine(_description + "\n");
        Console.Write("How long in seconds, would you like for your session? ");
    }

    public void DisplayEnd() // Displays the ending message
    {   
        Console.WriteLine("Well done!"); // Signals the end of the activity
        Animation();
        Console.WriteLine(_endingMessage);
        Animation();
        PauseActivity(3); // Pause the adtivity for 1 second

    }

    public void PauseActivity(int sec) // Pauses the activity
    {
        /* Accepts float Parameter */
        Thread.Sleep(1000 * sec);
    }

    public void Animation(int n=2) // Displays a loader animation to the console with length n = 2 seconds, unless specified
    {
        for (int i=0; i<n; i++)
        {
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b"); // Erase the characters
            Console.Write("/ ."); 
            Thread.Sleep(250);
            Console.Write("\b\b\b"); // Erase the characters
            Console.Write("- ..");
            Thread.Sleep(250);
            Console.Write("\b\b\b\b"); // Erase the characters
            Console.Write("\\ ...");
            Thread.Sleep(250);
            Console.Write("\b\b\b\b\b     \b\b\b\b\b"); // Erase the characters
        }
        Console.Write("\n"); // Erase the characters
    }
    
    public void GetReady()
    {
        Console.WriteLine("Get ready...");
    }

    public void CountDown(int n=5) // Runs a countdown counter from n=5 default to 1 if not specified
    {
        for (int i=0; i<n; i++)
        {
            Console.Write(n - i);
            Thread.Sleep(1000);
            Console.Write("\b");
        }
        Console.Write(" \n");
    }

    /* Getter methods */
    public int GetDuration()
    {
        return _duration;
    }

    public string GetName()
    {
        return _name;
    }
    /* Setter functions */
    public void SetName(string name)
    {
        _name = name;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public void SetEndMessage(string name, int duration)
    {
        _endingMessage = $"\nYou have completed {duration} seconds of the {name}";
    }

    public void SetStartMessage(string name)
    {
        _startingMessage = $"Welcome to the {name}.\n";
    }
}