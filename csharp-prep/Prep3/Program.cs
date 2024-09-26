using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        // This program generates a random number to guess between 1 and 100
        // While the user don't guess the number, the program keeps asking questions

        // Generates a random number and stores it in a variable
        Random randomGenerator = new Random();
        int magicNum = randomGenerator.Next(1,100);

        // Displays welcome message
        Console.WriteLine("Guess the magic number between 1 and 100");

        // Asks the user for his input and stores it in a variable
        Console.Write("What is your guess? ");
        string guessInput = Console.ReadLine();
        int guess = int.Parse(guessInput);

        // Sets a guess counter
        int guessCount = 1;


        // Keeps asking user for an inout as long as the magic number isn't found
        // While loop as long as the guess is different from the magic number
        // If guess is higher/lower than the magic number, displays message and keeps asking for a guess
        // The guess count increments each time the user can't guess
        while(guess!=magicNum){
            if(guess > magicNum){
                Console.WriteLine("Lower");
                Console.Write("What is your guess? ");
                guessCount ++;
            }
            else
            {
                Console.WriteLine("Higher");
                Console.Write("What is your guess? ");
                guessCount ++;
            }
            guessInput = Console.ReadLine();
            guess = int.Parse(guessInput);
        }

        // Displays final message when the user guessed the correct number
        Console.WriteLine($"You guessed it!\nAttempt(s) = {guessCount}");
    }
}