using System.Reflection.Metadata.Ecma335;

public class Circle : Shape
{
    double _radius;
    public Circle(string color, double radius):base(color)
    {
        _radius = radius;
        SetName("Circle");
    }
    public override double GetArea()
    {
        return  Math.Pow(_radius, 2) * Math.PI;
    }
}