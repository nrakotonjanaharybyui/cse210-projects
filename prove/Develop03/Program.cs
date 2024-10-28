using System;

class Program
{
    static void Main(string[] args)
    {
        // Creates a new scripture object for the user to memorize
        Scripture scripture = new Scripture("Proverbs 3", [
        (5, "Trust in the Lord with all thine heart; and lean not unto thine own understanding."), 
        (6,"In all thy ways acknowledge him, and he shall direct thy paths."), 
        (7,"Be not wise in thine own eyes: fear the Lord, and depart from evil.")]);

        // Creating condition for a loop to ask user for action
        string condition1 = "";
        bool condition2 = true;
        

        // Checks if both of those conditions are met and runs the loop
        // If either one of the condition is false, the loop ends
        while  (condition1 != "quit" && condition2)
        {   
            Console.Clear(); // Clears the console
            Console.WriteLine(scripture.GetScripture()); // Displays the scripture
            Console.WriteLine(""); // Writes a blank line
            Console.WriteLine("Press enter to continue or type 'quit' to finish:"); // Writes the prompt to the user
            condition1 = Console.ReadLine(); // Set the value of condition1 to the user input
            condition2 = !scripture.GetHasEnded(); // sets the value of condition2 to the "Has ended state" of the scripture
        }
    }
}