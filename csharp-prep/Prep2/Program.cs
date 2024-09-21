using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int gradePercent = int.Parse(Console.ReadLine());
        string gradeLetter;
        if(gradePercent >= 90)
        {
            gradeLetter = "A";
        }
        else if(gradePercent >= 80 && gradePercent < 90)
        {
            gradeLetter = "B";
        }
        else if(gradePercent >= 70 && gradePercent < 80)
        {
            gradeLetter = "C";
        }
        else if(gradePercent >= 60 && gradePercent < 70)
        {
            gradeLetter = "D";
        }
        else
        {
            gradeLetter = "F";
        }
        Console.WriteLine($"Your letter grade is {gradeLetter}");
        if(gradePercent >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass the course. You can do better next time!");
        }
    }
}