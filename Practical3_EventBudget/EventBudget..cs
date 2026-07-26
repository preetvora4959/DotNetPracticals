using System;

class EventBudget
{
    // Private Data Members
    private string eventName;
    private double totalBudget;

    // Parameterized Constructor
    public EventBudget(string name, double budget)
    {
        eventName = name;
        totalBudget = budget;
    }

    // Display Event Summary
    public void ShowSummary(double expense)
    {
        Console.WriteLine("\nEvent Name       : " + eventName);
        Console.WriteLine("Total Budget     : Rs. " + totalBudget);
        Console.WriteLine("Total Expense    : Rs. " + expense);
        Console.WriteLine("Remaining Budget : Rs. " + (totalBudget - expense));
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Exception Handling starts
        try
        {
            Console.Write("Enter Event Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter Total Budget : ");
            double budget = Convert.ToDouble(Console.ReadLine());

            Console.Write("Decoration Cost : ");
            double decoration = Convert.ToDouble(Console.ReadLine());

            Console.Write("Food Cost : ");
            double food = Convert.ToDouble(Console.ReadLine());

            Console.Write("Sound Cost : ");
            double sound = Convert.ToDouble(Console.ReadLine());

            // Generate exception if budget is invalid
            if (budget <= 0)
                throw new Exception("Budget must be greater than zero.");

            double totalExpense = decoration + food + sound;

            // Generate exception if expense exceeds budget
            if (totalExpense > budget)
                throw new Exception("Total expense exceeds the budget.");

            // Create Object
            EventBudget obj = new EventBudget(name, budget);

            // Display Event Details
            obj.ShowSummary(totalExpense);

            Console.WriteLine("\nBudget Analysis Completed Successfully.");
        }

        // Handle all generated exceptions
        catch (Exception ex)
        {
            Console.WriteLine("\nError : " + ex.Message);
        }

        // This block always executes
        finally
        {
            Console.WriteLine("\nThank You!");
        }
    }
}