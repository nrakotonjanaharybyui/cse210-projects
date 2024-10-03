using System;
using System.Runtime.InteropServices.Marshalling;

class Program
{
    static void Main(string[] args)
    {
        List<string> animals = new List<string>();
        animals.Add("goat");
        animals.Add("sheep");
        animals.Add("cow");

        Console.WriteLine("Animals:");
        foreach (string animal in animals)
        {
            Console.WriteLine($"* {animal}");
        }
    }
}