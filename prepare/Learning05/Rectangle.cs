using System.Reflection.Metadata.Ecma335;

public class Rectangle : Shape
{
    double _length;
    double _width;
    public Rectangle(string color, double length, double width):base(color)
    {
        _length = length;
        _width = width;
        SetName("Rectangle");
    }

    public override double GetArea()
    {
        return _length * _width;
    }
}