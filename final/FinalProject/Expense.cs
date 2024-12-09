using System;
using System.ComponentModel;

public abstract class Expense
{
    private float _value;
    private string _name;
    private string _description;

    // Constructor
    public Expense(float value, string name, string description)
    {
        _value = value;
        _name = name;
        _description = description;
    }

    // Public Getters
    public float GetValue()
    {
         return _value;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    // Public Setters
    public void SetValue(float value)
    {
        _value = value;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }
}