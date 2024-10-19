using System;

class Fraction
{
    // Member variables
    private int _top;
    private int _bottom;

    // Constructor no parameter
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor top parametered
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor top and bottom parametered

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getters
    // Returns top as an integer
    public int GetTop()
    {
        return _top;
    }

    // Returns bottom as an integer
    public int GetBottom()
    {
        return _bottom;
    }

    // Setters
    // Sets top
    public void SetTop(int top)
    {
        _top = top;
    }

    // Sets bottom
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Formaters
    // Returns a string representation
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns a double value
    public double GetDecimalValue()
    {
        return (double)_top/_bottom;
    }
}