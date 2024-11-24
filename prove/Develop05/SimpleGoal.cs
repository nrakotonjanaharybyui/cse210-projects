using System;

public class SimpleGoal : Goal
{
    private bool _completion;

    public SimpleGoal(string name, string description, int points, bool completion=false):base(name, description, points)
    {
        _completion = completion;
        base.SetType("SimpleGoal");
    }

    // Override methods to abstract methods from parent
    public override void CompleteGoal()
    {
        base.SetScore(base.GetPoints());
        _completion = true;
    }

    public override string DisplayGoal()
    {
        string sign = " ";
        if (_completion)
        {
            sign = "X";
        }
        return $"[{sign}] {base.GetName()} ({base.GetDescription()})";

    }

    public override string SerializeGoal()
    {
        return $"{base.GetType()}|{base.GetName()}|{base.GetDescription()}|{base.GetPoints()}|{_completion}";
    }
}