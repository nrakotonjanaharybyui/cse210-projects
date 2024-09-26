using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome("Welcome to the program!");
        string nameInput = PromptUserName();
        int numberInput = PromptUserNumber();
        DisplayResult(nameInput, numberInput);
    }

    static void DisplayWelcome(string message)
    {
        Console.WriteLine(message);
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    } 

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number * number; 
    }

    static void DisplayResult(string name, int number)
    {
        number = SquareNumber(number);
        Console.WriteLine($"{name}, the square of your number is {number}");
    }
}