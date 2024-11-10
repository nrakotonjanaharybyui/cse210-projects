using System;

public class BreathActivity : ActivityBase
{
    public BreathActivity() // Constructor
    {
        string name = "Breathing Activity";
        SetName(name);
        SetStartMessage(name);
        SetDescription("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
    }

    public override void PlayActivity() // Main function of the class that runs the core activity, overrides the PlayActivity() method in the parent class
    {
        SetEndMessage(GetName(), GetDuration()); // Sets the ending message
        Console.Clear(); // Clears the console
        GetReady(); // Displays a "Get ready message"
        Animation(); // Displays animation
        int duration = GetDuration(); 
        float dCycles = duration/6; // Calculates how many cycles is done durint the provided duration
        int cycles = (int)Math.Floor(dCycles); 
        for (int i=0; i<cycles; i++) // Loops "cycles" times to cycle between breath-in and out sessions 
        {
            Console.Write("Breathe in... ");
            CountDown(3);
            Console.Write("Breathe out... ");
            CountDown(3);
            Console.Write("\n");
        }
        DisplayEnd(); // Displays an end message
        // End of activity, returns to caller
    }

    // Helper function
    // Runs a 5 sec countdown and displays that to the console
}