using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

public abstract class Goal
{
    private string _type;
    private string _name;
    private string _description;
    private int _points;
    private int _score;
    
    public Goal(string name, string description, int points) // Default constructor implemented in all subclasses
    {
        _name = name;
        _description = description;
        _points = points;
        _score = 0;
    }

    // Setters
    public void SetScore(int score)
    {
        _score = score;
    }

    // Getters
    public string GetName() // Returns the me to the caller
    {
        return _name;
    }

    public string GetDescription() // Returns the description to the caller
    {
        return _description;
    }

    public int GetScore() // returns the score to the caller
    {
        return _score;
    }

    public int GetPoints() // returns the points to the caller
    {
        return _points;
    }

    public string GetType() // returns the type to the caller
    {
        return _type;
    }
    
    // Abstract Getters: must be implemented in all subsclasses
    public abstract string DisplayGoal(); // Returns the string representation for displaying

    public abstract string SerializeGoal(); // Returns the string representation for saving in file

    public abstract void CompleteGoal();
    // Setters
    public void SetType(string type) // Sets the type of the goal, has to be called in all subclasses' constructor
    {
        _type = type;
    }
}