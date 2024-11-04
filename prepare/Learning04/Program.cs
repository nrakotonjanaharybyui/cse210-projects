using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment ass1 = new Assignment("Samuel Bennett", "Multiplication");
        MathAssignment ass2 = new MathAssignment("Roberto Rodriguez", "Fractions", "Section 7.3", "8-19");
        WritingAssignment ass3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(ass3.GetSummary());
        Console.WriteLine(ass3.GetWritingInformation());
    }
}