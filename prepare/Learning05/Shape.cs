public class Shape
{
    private string _color;
    private string _name;

    // Constructor
    public Shape(string color)
    {
        _color = color;
    }

    public void SetName(string name)
    {
        _name = name;
    }
    public string GetColor()
    {
        return _color;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    public virtual double GetArea()
    {
        return 0d;
    }
}