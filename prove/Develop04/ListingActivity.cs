using System;
using System.Runtime.CompilerServices;

public class ListingActivity : ActivityBase
{
    private List<string> _questions;
    private List<string> _userAnswers;

    private Random _randomizer;

    public ListingActivity() // Constructor
    {
        string name = "Listing Activity";
        SetName(name);
        SetStartMessage(name);
        SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        _questions = ["Who are people that you appreciate?",
                    "What are personal strengths of yours?",
                    "Who are people that you have helped this week?",
                    "When have you felt the Holy Ghost this month?",
                    "Who are some of your personal heroes?"];
        _randomizer = new Random();
        _userAnswers = [];
    }

    public override void PlayActivity() // Main function that runs the specificities of this class
    {
        SetEndMessage(GetName(), GetDuration()); // Sets the ending message
        Console.Clear(); // Clears the console
        GetReady(); // Displays a "Get ready message"
        Animation(); // Displays animation
        int duration = GetDuration();
        int qIndex = _randomizer.Next(0, _questions.Count);
        string question = _questions[qIndex];
        DateTime startTime = DateTime.Now; // Starting time
        DateTime endTime = startTime.AddSeconds(duration);
        int answerCounter = 0;
        Console.Write($"List as many responses you can to the following prompt\n--- {question} ---\nYou can start in: ");
        CountDown();
        while (endTime > DateTime.Now) // Gather User's ansers until endtime is reached
        {
            Console.Write("> ");
            string answer = Console.ReadLine();
            answerCounter +=1;
            _userAnswers.Add(answer);
        }
        Console.Write($"You listed {answerCounter} items!\n");
        PauseActivity(1);
        DisplayEnd(); // Displays end message
    }
}