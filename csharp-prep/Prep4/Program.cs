using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int currentInput;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.Write("Enter a number: ");
            currentInput = int.Parse(Console.ReadLine());
            numbers.Add(currentInput);
        } while(currentInput != 0);
        int sum = 0;
        int count = -1;
        foreach (int number in numbers)
        {
            sum += number;
            count ++;
        } 
        double avg = (double)sum / (double)count;
        int max = 0;
        foreach(int number in numbers)
        {
            if(number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The sum is: {sum}\nThe average is: {avg}\nThe largest number is: {max}");
        
    }
}