using System;

public class ReflectingActivity : ActivityBase
{
    private List<string> _prompts;
    private List<string> _questions;
    private Random _randomizer;

    public ReflectingActivity() // Constructor
    {
        string name = "Reflecting Activity";
        SetName(name);
        SetStartMessage(name);
        SetDescription("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        _prompts = ["Think of a time when you stood up for someone else.",
                    "Think of a time when you did something really difficult.",
                    "Think of a time when you helped someone in need.",
                    "Think of a time when you did something truly selfless."];
        _questions = ["Why was this experience meaningful to you?",
                    "Have you ever done anything like this before?",
                    "How did you get started?",
                    "How did you feel when it was complete?",
                    "What made this time different than other times when you were not as successful?",
                    "What is your favorite thing about this experience?",
                    "What could you learn from this experience that applies to other situations?",
                    "What did you learn about yourself through this experience?",
                    "How can you keep this experience in mind in the future?"];
        _randomizer = new Random();
    }

    public override void PlayActivity()
    {
        SetEndMessage(GetName(), GetDuration()); // Sets the ending message
        Console.Clear(); // Clears the console
        GetReady(); // Displays a "Get ready message"
        Animation(); // Displays animation
        int duration = GetDuration();
        float dCycles = duration/10; // Calculates how many cycles is done durint the provided duration
        int cycles = (int)Math.Floor(dCycles); 
        DisplayPrompt();
        DisplayQuestion(cycles);
        DisplayEnd();
    }

    private void DisplayPrompt() // Display a random prompt out of the prompt list
    {
        int promptIndex = _randomizer.Next(0, _prompts.Count);
        string prompt = _prompts[promptIndex];
        Console.WriteLine($"Consider the following prompt:\n\n--- {prompt} ---\n");
        Console.Write("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.Write("\nNow ponder on each of the following questions as they related to this experiece.\nYou can begin in: ");
        CountDown();
    }

    /* The DisplayQuestion function is enhanced to not repeat any question, until all the questions in the list are displayed*/
    private void DisplayQuestion(int cycles) // Display question depending on the time provided (10 secs each)
    {   
        Console.Clear();
        List<int> usedQuestions = []; // Keep track of the used questions
        int max = _questions.Count; // Max length that the used questions list compares to
        for (int i=0; i<cycles; i++) // Displays "cycles" times questions
        {
            if (usedQuestions.Count == max)
            {
                usedQuestions = []; // Empties the usedQuestions list once it is full
            }

            int questionIndex; 
            
            if(usedQuestions.Count >= 1) // If there is more than one item in the used Questions list
            {
                do
                {
                    questionIndex = _randomizer.Next(0, _questions.Count);
                    // Grab a new random integer
                } while (usedQuestions.Contains(questionIndex)); // As long as the generated integer is part of the used index list
            }
            else{
                questionIndex = _randomizer.Next(0, _questions.Count); // Else creates a random index
            }
            string question = _questions[questionIndex]; // Gets a question
            usedQuestions.Add(questionIndex); // Adds the new index to the usedQuestions index lis
            Console.Write($"{question} ");
            Animation(10); // Runs the animation for a length of 10 secs (thus, the program waits 10 secs)
            Console.Write("\n");
        }
    }
}