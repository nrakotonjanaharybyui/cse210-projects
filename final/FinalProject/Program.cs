using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        bool runMenu = true; // Boolean telling to run the main menu
        Budget budget = null; // Create a null budget
        bool budgetExist = false; // budget doesn't exist so far
        while(runMenu) // Run perpetually the menu
        {   
            // Trigger user to choose an option, and consequently run the designed function/operation
            string choice = RunMenu(budget, budgetExist);
            if(choice == "1") // Create a new budget
            {
                Console.Clear();
                Console.Write($"Please provide a name for your budget: ");
                string name = Console.ReadLine();
                Console.Write("Please provide a description for your budget: ");
                string description = Console.ReadLine();
                budget = new Budget(name, description);
                budgetExist = true;
                SuccessMessage("Budget",name,description);
            }
            
            if(choice == "2") // Display current budget
            {
                DisplayBudget(budget,budgetExist);
            }
            
            if(choice == "3") // Load a budget from file
            {
                (budget,budgetExist) = LoadBudget();
            }

            if(choice=="4") // Save current budget to file
            {
                SaveBudget(budget,budgetExist);
            }

            if(choice=="5") // Add a New item to current budget
            {
                AddItem(budget, budgetExist);
            }

            if(choice=="6") // Modify an existing item
            {
                ModifyDelete(budget,budgetExist);
            }
            
            if(choice == "0") // Quit the program
            {
                runMenu = false;
            }
        }
    }


    // Function running the main menu
    private static string RunMenu(Budget budget, bool budgetExist)
    {
        if(budgetExist)
        {
            Console.Clear();
            Console.WriteLine($"Current Budget:\n{budget.GetName().ToUpper()}\n__________\nMAIN MENU");
            Console.Write($"1. Create a New Budget\n2. Display Budget\n3. Load Budget\n4. Save Budget\n5. Add New Item\n6. Modify or Delete Item\n0. Quit\nWhat operation would you like to perform ? ");
            string choice = Console.ReadLine();
            return choice;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Budget Tracker\n__________\nMAIN MENU");
            Console.Write($"1. Create a New Budget\n2. Display Budget\n3. Load Budget\n4. Save Budget\n5. Add New Item\n6. Modify or Delete Item\n0. Quit\nWhat operation would you like to perform ? ");
            string choice = Console.ReadLine();
            return choice;
        }
    }

    // Main menu operations
    private static void DisplayBudget(Budget budget,bool budgetExist) // #2 Display current budget
    {
        if(!budgetExist)
        {
            WarningNonExisting(); // If budget don't exist, display warning message and return
            return;
        }
        // Else: Get all info about budget and display
        List<Income> incomes = budget.GetIncomes();
        List<Expense> expenses = budget.GetExpenses();
        List<Investment> investments = budget.GetInvestments();
        string name = budget.GetName();
        string description = budget.GetDescription();
        DateTime startDate = budget.GetStartDate();
        DateTime endDate = budget.GetEndDate();
        float totalIncome = budget.GetTotalIncome();
        float totalExpense = budget.GetTotalExpenses();
        // Start display
        Console.Clear();
        Console.Write($"-----------\n{name}\n{description}\n{startDate.ToString("MM/dd/yyyy")} - {endDate.ToString("MM/dd/yyyy")}\n-----------\n");
        Console.WriteLine("Income Summary");
        foreach(Income inc in incomes)
        {
            Console.WriteLine(inc.GetDisplay());
        }
        Console.WriteLine("------------\nExpense Summary");
        foreach(Expense exp in expenses)
        {
            Console.WriteLine(exp.GetDisplay());
        }
        Console.WriteLine("------------\nInvestment Summary");
        foreach(Investment inv in investments)
        {
            Console.WriteLine(inv.GetDisplay());
        }
        Console.WriteLine($"------------\nTotal Income: {totalIncome}, Total Expense: {totalExpense}\n\nPlease click ENTER when done");
        string next = Console.ReadLine();

        
    }

    private static (Budget,bool) LoadBudget() // #3 Load a budget from file
    {
        Console.Clear();
        Console.WriteLine("What is the name of the file you wish to load?");
        string fileName = Console.ReadLine();
        Budget budget = new Budget("_placeholder","_placeholder");
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach(string line in lines)
        {
            string[] parts = line.Split(",");
            string type = parts[0];
            if(type == "Budget")
            {
                budget.SetName(parts[1]);
                budget.SetDescription(parts[2]);
                budget.SetStartDate(DateTime.Parse(parts[3]));
                budget.SetEndDate(DateTime.Parse(parts[4]));
            }
            if(type == "Salary")
            {
                string name = parts[1];
                string description = parts[2];
                float value = float.Parse(parts[3]);
                DateTime startDate = DateTime.Parse(parts[4]);
                DateTime endDate = DateTime.Parse(parts[5]);
                budget.AddIncome(new Salary(value,name,description,startDate,endDate));
            }
            if(type == "SideHustle")
            {
                string name = parts[1];
                string description = parts[2];
                float value = float.Parse(parts[3]);
                DateTime date = DateTime.Parse(parts[4]);
                budget.AddIncome(new SideHustlle(value,name,description,date));
            }
            if(type == "FixedExpense")
            {
                string name = parts[1];
                string description = parts[2];
                float value = float.Parse(parts[3]);
                DateTime startDate = DateTime.Parse(parts[4]);
                DateTime endDate = DateTime.Parse(parts[5]);
                budget.AddExpense(new FixedExpense(value,name,description,startDate,endDate));
            }
            if(type == "VariableExpense")
            {
                string name = parts[1];
                string description = parts[2];
                float value = float.Parse(parts[3]);
                DateTime date = DateTime.Parse(parts[4]);
                budget.AddExpense(new VariableExpense(value,name,description,date));
            }
            if(type == "Investment")
            {
                string name = parts[1];
                string description = parts[2];
                float value = float.Parse(parts[3]);
                float rate = float.Parse(parts[4]);
                DateTime date = DateTime.Parse(parts[5]);
                budget.AddInvestment(new Investment(value,name,description,date,rate));
            }
        }




        Console.Clear();
        Console.WriteLine($"Congratulations {fileName} was successfully loaded");
        Thread.Sleep(3000);
        return (budget,true);
    }

    private static void SaveBudget(Budget budget,bool budgetExist) // #4 Save current budget to a file
    {
        if(!budgetExist)
        {
            WarningNonExisting(); // If budget don't exist, display warning message and return
            return;
        }
        Console.Clear();
        Console.Write("Please provide a file name: ");
        string fileName = Console.ReadLine();
        List<Income> incomes = budget.GetIncomes();
        List<Expense> expenses = budget.GetExpenses();
        List<Investment> investments = budget.GetInvestments();
        using (StreamWriter outputfile = new StreamWriter(fileName))
        {
            outputfile.WriteLine(budget.Serialize());
            foreach(Income inc in incomes)
            {
                outputfile.WriteLine(inc.Serialize());
            }
            foreach(Expense exp in expenses)
            {
                outputfile.WriteLine(exp.Serialize());
            }
            foreach(Investment inv in investments)
            {
                outputfile.WriteLine(inv.Serialize());
            }
        }
        Console.Clear();
        Console.WriteLine($"The budget was saved successfully in {fileName}");
        Thread.Sleep(3000);


    }

    private static void AddItem(Budget budget, bool budgetExist) // #5 Add an item to current budget
    {
        if(!budgetExist)
        {
            WarningNonExisting();
            return;
        }
        bool back = false;
        string choice = "";
        while (back == false)
        {
            Console.Clear();
            Console.Write($"Add New Item Menu\n-----------\n1. Add Income\n2. Add Expense\n3. Add Investment\n0. Back\nWhat operation would you like to perform ? ");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                AddIcome(budget);
            }
            if (choice == "2")
            {
                AddExpense(budget);
            }
            if (choice == "3")
            {
                AddInvestment(budget);
            }
            if (choice == "0")
            {
                back = true;
            }
        }
    }

    private static void AddIcome(Budget budget) // #5.1 Add an Income to existing budget
    {
        bool back = false;
        string choice = "";
        while (back == false)
        {
            Console.Clear();
            Console.Write($"NEW INCOME MENU\n-----------\n1. Add Salary\n2. Add Side Hustle\n0. Back\nWhat operation would you like to perform ? "); // Display a menu
            choice = Console.ReadLine();
            if (choice == "1") // Choice 1 is to add a salary
            {
                // Trigger the user for details, create an instance of Salary and add it to current budget
                Console.Clear();
                Console.Write("Your are adding a new salary\nPlease provide an amount: ");
                float value = float.Parse(Console.ReadLine());
                Console.Write("Please provide a name: ");
                string name = Console.ReadLine();
                Console.Write("Please provide a description: ");
                string description = Console.ReadLine();
                Console.Write("Please provide a starting date (format = MM/DD/YYYY), or press ENTER to set the starting date to today: ");
                string readDateStart = Console.ReadLine();
                DateTime startDate;
                if(readDateStart == "")
                {
                    startDate = DateTime.Now;
                }
                else
                {
                    startDate = DateTime.ParseExact(readDateStart, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                Console.Write("Please provide a ending date (format = MM/DD/YYYY), or press ENTER to set the starting date to today: ");
                string readDateEnd = Console.ReadLine();
                DateTime endDate;
                if(readDateEnd == "")
                {
                    endDate = DateTime.Now;
                }
                else
                {
                    endDate = DateTime.ParseExact(readDateEnd, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                Salary salary = new Salary(value,name,description,startDate,endDate);
                budget.AddIncome(salary);
                SuccessMessage("Income",salary.GetName(), salary.GetDescription()); // Display a success message
            }
            if (choice == "2") // Choice 2 is side hustle
            {
                // Trigger the user for details, create an instance of Side Hustle and add it to current budget
                Console.Clear();
                Console.Write("Your are adding a new Side Hustle\nPlease provide an amount: ");
                float value = float.Parse(Console.ReadLine());
                Console.Write("Please provide a name: ");
                string name = Console.ReadLine();
                Console.Write("Please provide a description: ");
                string description = Console.ReadLine();
                Console.Write("Please provide a date (format = MM/DD/YYYY), or press ENTER to set the date to today: ");
                string readDate = Console.ReadLine();
                DateTime date;
                if(readDate == "")
                {
                    date = DateTime.Now;
                }
                else
                {
                    date = DateTime.ParseExact(readDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                SideHustlle sideHustle = new SideHustlle(value,name,description,date);
                budget.AddIncome(sideHustle);
                SuccessMessage("Income",sideHustle.GetName(), sideHustle.GetDescription()); // Display a success message
            }
            if (choice == "0") // Get back to the previous menu
            {
                back = true;
            }
        }
    }

    private static void AddExpense(Budget budget) // #5.2 Add Expense to existing budget
    {
        bool back = false;
        string choice = "";
        while(!back)
        {
            Console.Clear();
            Console.Write($"NEW EXPENSE MENU\n-----------\n1. Add Fixed Expense\n2. Add Variable Expense\n0. Back\nWhat operation would you like to perform ? "); // Display a menu
            choice = Console.ReadLine();
            if(choice=="1") // Add a Fixed Expense to current budget
            {
                // Trigger user for details and add Fixed Expense to current budget
                Console.Clear();
                Console.Write("Your are adding a new Fixed Expense\nPlease provide an amount: ");
                float value = float.Parse(Console.ReadLine());
                Console.Write("Please provide a name: ");
                string name = Console.ReadLine();
                Console.Write("Please provide a description: ");
                string description = Console.ReadLine();
                Console.Write("Please provide a starting date (format = MM/DD/YYYY), or press ENTER to set the starting date to today: ");
                string readDateStart = Console.ReadLine();
                DateTime startDate;
                if(readDateStart == "")
                {
                    startDate = DateTime.Now;
                }
                else
                {
                    startDate = DateTime.ParseExact(readDateStart, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                Console.Write("Please provide a ending date (format = MM/DD/YYYY), or press ENTER to set the starting date to today: ");
                string readDateEnd = Console.ReadLine();
                DateTime endDate;
                if(readDateEnd == "")
                {
                    endDate = DateTime.Now;
                }
                else
                {
                    endDate = DateTime.ParseExact(readDateEnd, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                FixedExpense expense = new FixedExpense(value,name,description,startDate,endDate);
                budget.AddExpense(expense);
                SuccessMessage("Expense",expense.GetName(), expense.GetDescription()); // Display a success message
            }
            if(choice=="2") // Add a variable expense to current budget
            {
                // Trigger details from user, and add a Variable Expense to current budget
                Console.Clear();
                Console.Write("Your are adding a new Variable Expense\nPlease provide an amount: ");
                float value = float.Parse(Console.ReadLine());
                Console.Write("Please provide a name: ");
                string name = Console.ReadLine();
                Console.Write("Please provide a description: ");
                string description = Console.ReadLine();
                Console.Write("Please provide a date (format = MM/DD/YYYY), or press ENTER to set the date to today: ");
                string readDate = Console.ReadLine();
                DateTime date;
                if(readDate == "")
                {
                    date = DateTime.Now;
                }
                else
                {
                    date = DateTime.ParseExact(readDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                VariableExpense expense = new VariableExpense(value,name,description,date);
                budget.AddExpense(expense);
                SuccessMessage("Expense",expense.GetName(), expense.GetDescription()); // Display a success message
            }
            if(choice=="0") // Go to previous menu
            {
                back = true;
            }
        }

    }

    private static void AddInvestment(Budget budget) // #5.3 Add Investment to existing budget
    {
        Console.Clear();
        Console.Write($"You are adding a new investment item to your budget. Please provide the following infos\n");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Starting date (format = MM/DD/YYYY), or press ENTER to set the starting date to today: ");
        string readDateStart = Console.ReadLine();
        DateTime startDate;
        if(readDateStart == "")
        {
            startDate = DateTime.Now;
        }
        else
        {
            startDate = DateTime.ParseExact(readDateStart, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        }
        Console.Write("Initial payment amount: ");
        float value = float.Parse(Console.ReadLine());
        Console.Write("Interest rate (Please inter value in float format 0.00): ");
        float rate = float.Parse(Console.ReadLine());
        Investment invest = new Investment(value,name,description,startDate,rate);
        budget.AddInvestment(invest);
        SuccessMessage("Investment",name,description);
    }

    private static void ModifyDelete(Budget budget, bool budgetExist) // #6 Modify an item on the current budget
    {
        if(!budgetExist)
        {
            WarningNonExisting();
            return;
        }
        string choice_main = "";
        bool run_menu = true;
        while(run_menu)
        {
            List<Income> incomes = budget.GetIncomes();
            List<Expense> expenses = budget.GetExpenses();
            List<Investment> investments = budget.GetInvestments();

            Console.Clear();
            Console.Write("Edit Menu\n1. Delete Item\n2. Modify Item\n0. Go back\nWhich operation do you want to perform? ");
            choice_main = Console.ReadLine();
            if(choice_main == "1") // Delete Item
            {
                Console.Clear();
                Console.WriteLine("Your available items are:");
                int expIndex = 0;
                int invIndex = 0;
                Console.WriteLine("---- Incomes -----");
                for(int i=0; i<incomes.Count(); i++)
                {
                    Console.WriteLine($"{i+1} - {incomes[i].GetName()}, {incomes[i].GetDescription()}, ${incomes[i].GetValue()}");
                    expIndex += 1;
                    invIndex += 1;
                }
                Console.WriteLine("---- Expenses -----");
                for(int i=0; i<expenses.Count(); i++)
                {
                    Console.WriteLine($"{i+expIndex+1} - {expenses[i].GetName()}, {expenses[i].GetDescription()}, ${expenses[i].GetValue()}");
                    invIndex += 1;
                }
                Console.WriteLine("---- Investments -----");
                for(int i=0; i<investments.Count(); i++)
                {
                    Console.WriteLine($"{i+invIndex+1} - {investments[i].GetName()}, {investments[i].GetDescription()}, ${investments[i].GetValue()}");
                }
                Console.Write("\nWhich item do you wish to delete? ");
                int choice = int.Parse(Console.ReadLine());
                if(choice > invIndex)
                {
                    int index = choice - invIndex - 1;
                    string name = budget._investments[index].GetName();
                    budget._investments.RemoveAt(index);
                    Console.Clear();
                    Console.Write($"{name} erased successfully");
                }
                if(invIndex>=choice && choice>expIndex)
                {
                    int index = choice - expIndex - 1;
                    string name = budget._expenses[index].GetName();
                    budget._expenses.RemoveAt(index);
                    Console.Clear();
                    Console.Write($"{name} erased successfully");
                }
                if(expIndex>=choice)
                {
                    int index = choice - 1;
                    string name = budget._incomes[index].GetName();
                    budget._incomes.RemoveAt(index);
                    Console.Clear();
                    Console.Write($"{name} erased successfully");
                }
                Thread.Sleep(3000);
            }
            if(choice_main == "2") // Updating Item
            {
                Console.Clear();
                Console.WriteLine("Your available items are:");
                int expIndex = 0;
                int invIndex = 0;
                Console.WriteLine("---- Incomes -----");
                for(int i=0; i<incomes.Count(); i++)
                {
                    Console.WriteLine($"{i+1} - {incomes[i].GetName()}, {incomes[i].GetDescription()}, ${incomes[i].GetValue()}");
                    expIndex += 1;
                    invIndex += 1;
                }
                Console.WriteLine("---- Expenses -----");
                for(int i=0; i<expenses.Count(); i++)
                {
                    Console.WriteLine($"{i+expIndex+1} - {expenses[i].GetName()}, {expenses[i].GetDescription()}, ${expenses[i].GetValue()}");
                    invIndex += 1;
                }
                Console.WriteLine("---- Investments -----");
                for(int i=0; i<investments.Count(); i++)
                {
                    Console.WriteLine($"{i+invIndex+1} - {investments[i].GetName()}, {investments[i].GetDescription()}, ${investments[i].GetValue()}");
                }
                Console.Write("\nWhich item do you wish to Modify? ");
                int choice = int.Parse(Console.ReadLine());
                if(choice > invIndex)
                {
                    int index = choice - invIndex - 1;
                    UpdateInvestment(index,budget);
                }
                if(invIndex>=choice && choice>expIndex)
                {
                    int index = choice - expIndex - 1;
                    UpdateExpense(index,budget);
                }
                if(expIndex>=choice)
                {
                    int index = choice - 1;
                    UpdateIncome(index,budget);
                }
            }
            if(choice_main == "0") // Go back
            {
                run_menu = false;
            }
        }
    }

    private static void UpdateIncome(int index, Budget budget)
    {
        bool run_menu = true;
        string type = budget._incomes[index].GetType().Name;
        while(run_menu)
        {
            if (type == "SideHustlle")
            {
                Console.Clear();
                Console.WriteLine($"You are updating\n{budget._incomes[index].GetDisplay()}");
                Console.Write("-------\nYour options are:\n1. Update Name\n2. Update Description\n3. Update Value\n4. Update Date\n0. To Finish\nWhat operation do you want to perform? ");
                string choice = Console.ReadLine();
                if(choice == "1")
                {
                    Console.Write("What is the new name? ");
                    string name = Console.ReadLine();
                    budget._incomes[index].SetName(name);
                    Console.Write($"Name updated to {name} successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "2")
                {
                    Console.Write("What is the new description? ");
                    string description = Console.ReadLine();
                    budget._incomes[index].SetDescription(description);
                    Console.Write($"Description updated to '{description}' successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "3")
                {
                    Console.Write("What is the new value? ");
                    float value = float.Parse(Console.ReadLine());
                    budget._incomes[index].SetValue(value);
                    Console.Write($"Initial value updated to {value} successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "4")
                {
                    Console.Write("What is the new date (format MM/DD/YYYY)? ");
                    DateTime date = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    budget._incomes[index].SetDate(date);
                    Console.Write($"Date updated to {date} successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "0")
                {
                    run_menu = false;
                }

            }
            if (type == "Salary")
            {
                Console.Clear();
                Console.WriteLine($"You are updating\n{budget._incomes[index].GetDisplay()}");
                Console.Write("-------\nYour options are:\n1. Update Name\n2. Update Description\n3. Update Value\n4. Update Start Date\n5. Update End Date\n0. To Finish\nWhat operation do you want to perform? ");
                string choice = Console.ReadLine();
                if(choice == "1")
                {
                    Console.Write("What is the new name? ");
                    string name = Console.ReadLine();
                    budget._incomes[index].SetName(name);
                    Console.Write($"Name updated to {name} successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "2")
                {
                    Console.Write("What is the new description? ");
                    string description = Console.ReadLine();
                    budget._incomes[index].SetDescription(description);
                    Console.Write($"Description updated to '{description}' successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "3")
                {
                    Console.Write("What is the new value? ");
                    float value = float.Parse(Console.ReadLine());
                    budget._incomes[index].SetValue(value);
                    Console.Write($"Initial value updated to {value} successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "4")
                {
                    Console.Write("What is the new start date (format MM/DD/YYYY)? ");
                    DateTime date = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    budget._incomes[index].SetStartDate(date);
                    Console.Write($"Date updated to {date} successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "5")
                {
                    Console.Write("What is the new end date (format MM/DD/YYYY)? ");
                    DateTime date = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    budget._incomes[index].SetEndDate(date);
                    Console.Write($"Date updated to {date} successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "0")
                {
                    run_menu = false;
                }

            }
        }
    }

    private static void UpdateExpense(int index, Budget budget)
    {
        bool run_menu = true;
        string type = budget._expenses[index].GetType().Name;
        while(run_menu)
        {
            if (type == "VariableExpense")
            {
                Console.Clear();
                Console.WriteLine($"You are updating\n{budget._expenses[index].GetDisplay()}");
                Console.Write("-------\nYour options are:\n1. Update Name\n2. Update Description\n3. Update Value\n4. Update Date\n0. To Finish\nWhat operation do you want to perform? ");
                string choice = Console.ReadLine();
                if(choice == "1")
                {
                    Console.Write("What is the new name? ");
                    string name = Console.ReadLine();
                    budget._expenses[index].SetName(name);
                    Console.Write($"Name updated to {name} successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "2")
                {
                    Console.Write("What is the new description? ");
                    string description = Console.ReadLine();
                    budget._expenses[index].SetDescription(description);
                    Console.Write($"Description updated to '{description}' successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "3")
                {
                    Console.Write("What is the new value? ");
                    float value = float.Parse(Console.ReadLine());
                    budget._expenses[index].SetValue(value);
                    Console.Write($"Initial value updated to {value} successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "4")
                {
                    Console.Write("What is the new date (format MM/DD/YYYY)? ");
                    DateTime date = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    budget._expenses[index].SetDate(date);
                    Console.Write($"Date updated to {date} successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "0")
                {
                    run_menu = false;
                }

            }
            if (type == "FixedExpense")
            {
                Console.Clear();
                Console.WriteLine($"You are updating\n{budget._expenses[index].GetDisplay()}");
                Console.Write("-------\nYour options are:\n1. Update Name\n2. Update Description\n3. Update Value\n4. Update Start Date\n5. Update End Date\n0. To Finish\nWhat operation do you want to perform? ");
                string choice = Console.ReadLine();
                if(choice == "1")
                {
                    Console.Write("What is the new name? ");
                    string name = Console.ReadLine();
                    budget._expenses[index].SetName(name);
                    Console.Write($"Name updated to {name} successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "2")
                {
                    Console.Write("What is the new description? ");
                    string description = Console.ReadLine();
                    budget._expenses[index].SetDescription(description);
                    Console.Write($"Description updated to '{description}' successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "3")
                {
                    Console.Write("What is the new value? ");
                    float value = float.Parse(Console.ReadLine());
                    budget._expenses[index].SetValue(value);
                    Console.Write($"Initial value updated to {value} successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "4")
                {
                    Console.Write("What is the new start date (format MM/DD/YYYY)? ");
                    DateTime date = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    budget._expenses[index].SetStartDate(date);
                    Console.Write($"Date updated to {date} successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "5")
                {
                    Console.Write("What is the new end date (format MM/DD/YYYY)? ");
                    DateTime date = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    budget._expenses[index].SetEndDate(date);
                    Console.Write($"Date updated to {date} successfully");
                    Thread.Sleep(2000);
                }
                if(choice == "0")
                {
                    run_menu = false;
                }

            }
        }
    }

    private static void UpdateInvestment(int index, Budget budget)
    {
        bool run_menu = true;
        while(run_menu)
        {
            Console.Clear();
            Console.WriteLine($"You are updating\n{budget._investments[index].GetDisplay()}");
            Console.Write("-------\nYour options are:\n1. Update Name\n2. Update Description\n3. Update Initial Value\n4. Update Rate\n5. Update Start Date\n0. To Finish\nWhat operation do you want to perform? ");
            string choice = Console.ReadLine();
            if(choice == "1")
            {
                Console.Write("What is the new name? ");
                string name = Console.ReadLine();
                budget._investments[index].SetName(name);
                Console.Write($"Name updated to {name} successfully");
                Thread.Sleep(2000);
            }
            if(choice == "2")
            {
                Console.Write("What is the new description? ");
                string description = Console.ReadLine();
                budget._investments[index].SetDescription(description);
                Console.Write($"Description updated to '{description}' successfully");
                Thread.Sleep(2000);
            }
            if(choice == "3")
            {
                Console.Write("What is the new value? ");
                float value = float.Parse(Console.ReadLine());
                budget._investments[index].SetValue(value);
                Console.Write($"Initial value updated to {value} successfully");
                Thread.Sleep(2000);
            }
            if(choice == "4")
            {
                Console.Write("What is the new rate (enter value in decimal form 0.00)? ");
                float rate = float.Parse(Console.ReadLine());
                budget._investments[index].SetInterestRate(rate);
                Console.Write($"Interest Rate updated to {rate} successfully");
                Thread.Sleep(2000);
            }
            if(choice == "5")
            {
                Console.Write("What is the new date (format MM/DD/YYYY)? ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);
                budget._investments[index].SetStartDate(date);
                Console.Write($"Date updated to {date} successfully");
                Thread.Sleep(2000);
            }
            if(choice == "0")
            {
                run_menu = false;
            }
        }
    }

    // Additional helper functions
    private static void SuccessMessage(string type, string name, string description)
    {
        Console.Clear();
        Console.Write($"Thank you!\n{type} {name}: {description} was successfully created.");
        Thread.Sleep(3000);
    }

    private static void WarningNonExisting()
    {
        Console.Clear();
        Console.Write("Warining!!!\nYou are trying to perform an operation on a non-existing budget.\nPlease create a budget or load one first.\n");
        Thread.Sleep(4000);
    }


}