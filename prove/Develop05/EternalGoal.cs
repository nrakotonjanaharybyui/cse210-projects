using System;

public class EternalGoal : Goal
{   
    private int _completionNumber;

    // Constructor, takes 4 param
    public EternalGoal(string name, string description, int points, int completionNumber=0) : base(name, description, points)
    {
        _completionNumber = completionNumber;
        base.SetType("EternalGoal");
    }


    // Override methods to abstract methods from parent
    public override void CompleteGoal()
    {
        int currentScore = base.GetScore();
        currentScore += base.GetPoints();
        base.SetScore(currentScore);
        _completionNumber += 1;
    }

    public override string DisplayGoal() // returms a string for displaying purpose
    {   
        if(_completionNumber == 0)
        {
            return $"[ ] {base.GetName()} ({base.GetDescription()})";
        }
        else
        {
            return $"[ ] {base.GetName()} ({base.GetDescription()}) - Done {_completionNumber} times";
        }
    }

    public override string SerializeGoal() // Returns a string for serialization purpose
    {
        return $"{base.GetType()}|{base.GetName()}|{base.GetDescription()}|{base.GetPoints()}|{_completionNumber}";
    }
}