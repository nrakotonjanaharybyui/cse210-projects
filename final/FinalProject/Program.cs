using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        bool runMenu = true;
        Budget budget = new Budget("Starter","Description");
        bool budgetExist = false;
        while(runMenu)
        {
            string choice = RunMenu(budget, budgetExist);
            if(choice == "1")
            {
                if(budgetExist){
                    Display(budget.GetDisplay());
                }
                else{
                    Display("There is no available budget to display, \nplease load one or start to create one.");
                }
            }
            
            if(choice == "2")
            {
                budgetExist = LoadBudget(budget);
            }

            if(choice=="3")
            {
                Display("Saving budget");
            }

            if(choice=="4")
            {
                Display("Recording an item");
            }
            
            if(choice == "5")
            {
                runMenu = false;
            }
        }
    }

    private static bool LoadBudget(Budget budget)
    {
        Console.Clear();
        Console.WriteLine("What is the name of the file you wish to load?");
        string fileName = Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"Congratulations {fileName} was successfully loaded");
        budget.SetName("Loaded budget");
        Thread.Sleep(3000);
        return true;
    }

    private static void Display(string content)
    {
        Console.Clear();
        Console.Write(content);
        Thread.Sleep(3000);
    }

    private static string RunMenu(Budget budget, bool budgetExist)
    {
        if(budgetExist)
        {
            Console.Clear();
            Console.WriteLine($"Current Budget: {budget.GetName()}\n__________\nMAIN MENU");
            Console.Write($"1. Display Budget\n2. Load Budget\n3. Save Budget\n4. Record an Item\n5. Quit\nWhat operation would you like to perform ? ");
            string choice = Console.ReadLine();
            return choice;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Budget Tracker\n__________\nMAIN MENU");
            Console.Write($"1. Display Budget\n2. Load Budget\n3. Save Budget\n4. Record an Item\n4. Quit\nWhat operation would you like to perform ? ");
            string choice = Console.ReadLine();
            return choice;
        }
    }

}