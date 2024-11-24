using System;

public class CheckListGoal : Goal
{
    private bool _completion;
    private int _targetSteps;
    private int _finishedSteps;
    private int _bonusPoints;

    // Constructor
    public CheckListGoal(string name, string description, int points, int bonusPoints, int targetSteps, int finishedSteps=0, bool completion=false):base(name,description,points)
    {
        _completion = false;
        _targetSteps = targetSteps;
        _finishedSteps = finishedSteps;
        _bonusPoints = bonusPoints;
        _completion = completion;
        base.SetType("CheckListGoal");
    }

    // Getter method
    public override void CompleteGoal() // Increments the finished steps and set to completed once the finished steps equal target step
    {
        _finishedSteps += 1;
        int currentScore = base.GetScore();
        currentScore += base.GetPoints();
        if(_finishedSteps>=_targetSteps)
        {
            currentScore += _bonusPoints;
            _completion = true;
        }
        base.SetScore(currentScore);
    }
    public int GetBonus() // Returns the bonus points if completed
    {
        if(_completion)
        {
            return _bonusPoints;
        }
        else
        {
            return 0;
        }
    }

    // Override methods to abstract methods from parent
    public override string DisplayGoal()
    {
        string sign = " ";
        if (_completion)
        {
            sign = "X";
        }
        return $"[{sign}] {base.GetName()} ({base.GetDescription()}) -- Currently completed: {_finishedSteps}/{_targetSteps}";
    }

    public override string SerializeGoal()
    {
        return $"{base.GetType()}|{base.GetName()}|{base.GetDescription()}|{base.GetPoints()}|{_bonusPoints}|{_finishedSteps}|{_targetSteps}|{_completion}";
    }
}