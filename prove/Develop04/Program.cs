using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        // Run the menu
        List<string> menuList = ["Start Breathing Activity","Start Reflecting Activity","Start Listing Activity","Quit"];
        string choice = "";


        while (choice != menuList.Count.ToString())
        {
            RunMenu(menuList); // Run the menu and Prompt the user for a choice
            choice = Console.ReadLine(); // Takes the choice fro, the user
            
            // Create and run an activity appropriately
            if (choice == "1")
            {
                BreathActivity activity = new BreathActivity(); // Creates the activity
                activity.RunActivity(); // Runs the activity
            }
            else if(choice == "2")
            {
                ReflectingActivity activity = new ReflectingActivity(); // Creates the activity
                activity.RunActivity(); // Runs the activity
            }
            else if(choice == "3")
            {
                ListingActivity activity = new ListingActivity(); // Creates a Listing Activity
                activity.RunActivity(); // Runs the activity
            }
            else if(choice == "4")
            {
                return;
            }
            else{ // Handles other input from the user on the menu
                Console.WriteLine($"'{choice}' is not an appropriate input, please choose a number from the menu");
                choice = "";
                Thread.Sleep(3000);
            }
        }
    }

    /* Helper functions */
    // This function Diplays the menu to the user for him to make the choice of an activity
    static void RunMenu(List<string> menu)
    {   
        Console.Clear(); // Clears the console
        Console.WriteLine("Menu Options:");
        for (int i=0; i< menu.Count; i++) // Loops through the menu list to display each and assign each a number
        {   
            Console.WriteLine($"  {i+1}. {menu[i]}");
        }
        Console.Write("Select a choice from the menu: ");
    }
}

