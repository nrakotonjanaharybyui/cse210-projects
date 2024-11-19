using System.Reflection.Metadata.Ecma335;

public class Square : Shape
{
    double _side;
    public Square(string color, double side):base(color)
    {
        _side = side;
        SetName("Square");
    }
    public override double GetArea()
    {
        return _side * _side;
    }
}