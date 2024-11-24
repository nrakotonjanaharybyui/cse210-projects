using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

class Program
{
    private static int currentScore = 0;

    static void Main(string[] args)
    {
        Console.Clear();
        // Creates a list of goals
        List<Goal> currentgoals = [];
        bool quit = false;

        while (!quit) // Start of main menu
        {
            // Displays the current score and the main menu choices
            Console.WriteLine($"--*--*--*--*--*--\nYou have {currentScore} points\n--*--*--*--*--*--\n");
            Console.Write("Menu Options:\n1. Create New Goal\n2. List Goals\n3. Save Goals\n4. Load Goals\n5. Record Event\n6. Quit\nSelect a choice from the menu: ");
            // Triggers user choice
            string userChoice = Console.ReadLine();
            // Toggle the user choice to choose an action
            if (userChoice == "1")
            {
                NewGoal(currentgoals);
            }
            else if (userChoice == "2")
            {
                ListGoals(currentgoals);
            }
            else if (userChoice == "3")
            {
                SaveGoals(currentgoals);
            }
            else if (userChoice == "4")
            {
                LoadGoals(currentgoals);
            }
            else if (userChoice == "5")
            {
                RecordEvent(currentgoals);
            }
            else if (userChoice == "6")
            {
                quit = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"--!--!--!--!--!--\nATTENTION\n{userChoice} is not an available option, please try again.\n--!--!--!--!--!--\n");
                Thread.Sleep(3000);
                Console.Clear();
            }

        } // End of main menu
    }


    // Helper functions
    private static void RecordEvent(List<Goal> currentgoals)
    {
        Console.Clear();
        Console.WriteLine("The goals are:");
        for(int i=0; i<currentgoals.Count; i++)
        {
            Console.WriteLine($"{i+1}. {currentgoals[i].GetName()}");
        }
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        currentgoals[index].CompleteGoal();
        Console.WriteLine($"\nCongratulations, You have earned {currentgoals[index].GetPoints()} points!");
        // Update General Score
        currentScore = 0;
        foreach(Goal goal in currentgoals)
        {
            currentScore += goal.GetScore();
        }
        Console.WriteLine($"You now have {currentScore} points.\n");
        Thread.Sleep(3000);
        Console.Clear();

    }
    
    private static void LoadGoals(List<Goal> currentgoals) // Load all golas from a file
    {
        Console.Clear();
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        currentScore = int.Parse(lines[0]);
        lines = lines.Skip(1).ToArray();
        foreach(string line in lines)
        {
            string[] parts = line.Split("|");
            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            if (type == "SimpleGoal")
            {
                bool completion = bool.Parse(parts[4]);
                currentgoals.Add(new SimpleGoal(name,description,points,completion));
            }
            else if(type == "EternalGoal")
            {
                int completionNumber = int.Parse(parts[4]);
                currentgoals.Add(new EternalGoal(name,description,points,completionNumber));
            }
            else if(type=="CheckListGoal")
            {
                int bonusPoints = int.Parse(parts[4]);
                int finishedSteps = int.Parse(parts[5]);
                int targetSteps = int.Parse(parts[6]);
                bool completion = bool.Parse(parts[7]);
                currentgoals.Add(new CheckListGoal(name,description,points,bonusPoints,targetSteps,finishedSteps,completion));
            }
        }
    }

    private static void SaveGoals(List<Goal> currentgoals) // Save current goals to a fle
    {
        if(currentgoals.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("--!--!--!--!--!--\nATTENTION\nThere is no goal to save yet, please choose to load or create some goals.\n--!--!--!--!--!--\n");
            Thread.Sleep(3000);
            Console.Clear();
        }
        else
        {
            Console.Clear();
            Console.Write("What is the filename for the goal? ");
            string filename = Console.ReadLine();
            int points = GetScore(currentgoals);
            using(StreamWriter outputFile=new StreamWriter(filename))
            {
                outputFile.WriteLine(points);
                foreach(Goal goal in currentgoals)
                {
                    outputFile.WriteLine(goal.SerializeGoal());
                }
            }
            Console.Clear();
        }
        
    }

    private static int GetScore(List<Goal> currentgoals) // Get all the earned score from the given list of goals, adds them together and returns the value
    {
        int totalPoints = 0;
        foreach(Goal goal in currentgoals)
        {
            totalPoints+=goal.GetScore();
        }
        return totalPoints;
    }

    private static void ListGoals(List<Goal> currentgoals) // Displays to the console all the goals present in the goal list
    {
        if(currentgoals.Count>0)
        {
            Console.WriteLine("\nThe goals are:");
            for(int i=0; i<currentgoals.Count; i++)
            {
                Console.WriteLine($"{i+1}. {currentgoals[i].DisplayGoal()}");
            }
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("\nYou have currently no goal to display\n");
        }
    }

    private static void NewGoal(List<Goal> currentgoals) // Create a new goal object and adds it to the given goal list
    {
        // This function creates a new Goal object specifying the type based on the user choice, and appends it to the current goals list
        bool choiceDone = false; // This bool keeps running the menu as long as the user doesn't make a good choice
        while(!choiceDone)
        {   
            Console.Clear();
            Console.Write("--*--*--*--*--*--\nGoals Choice Menu\nThe types of goals are:\n1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal\n4. Cancel\nWhich one do you want to create? ");
            string userChoice = Console.ReadLine();
            
            if(userChoice=="1") // Creates a Simple Goal
            {   
                Console.Write("What is the name of the goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                int points = int.Parse(Console.ReadLine());
                currentgoals.Add(new SimpleGoal(name,description,points));
                choiceDone = true;
            }
            else if(userChoice=="2") // Creates an eternal goal
            {
                Console.Write("What is the name of the goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                int points = int.Parse(Console.ReadLine());
                currentgoals.Add(new EternalGoal(name,description,points));
                choiceDone=true;
            }
            else if(userChoice=="3") // Creates a checklist goal
            {
                Console.Write("What is the name of the goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                int points = int.Parse(Console.ReadLine());
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int targetSteps = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonusPoints = int.Parse(Console.ReadLine());
                currentgoals.Add(new CheckListGoal(name,description,points,bonusPoints,targetSteps));
                choiceDone=true;
            }
            else if(userChoice == "4") // Cancels the operation
            {
                choiceDone = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"--!--!--!--!--!--\nATTENTION\n{userChoice} is not an available option, please try again.\n--!--!--!--!--!--\n");
                Thread.Sleep(3000);
            }
        }
        Console.Clear();
    }
}