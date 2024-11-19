using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = [];
        Square sq1 = new Square("Blue", 12.5);
        Rectangle rec1 = new Rectangle("Green", 5.2, 3.4);
        Circle cir1 = new Circle("Red", 12);
        shapes.Add(sq1);
        shapes.Add(rec1);
        shapes.Add(cir1);

        foreach(Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetName}, Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}