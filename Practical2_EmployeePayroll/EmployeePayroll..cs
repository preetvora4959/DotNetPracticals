using System;

// Interface
interface IPayroll
{
    void CalculateSalary();
}

// Base Class
class Employee
{
    protected int empId;
    protected string empName;
    protected double basicSalary;

    // Parameterized Constructor
    public Employee(int id, string name, double salary)
    {
        empId = id;
        empName = name;
        basicSalary = salary;
    }

    // Virtual Method (Polymorphism)
    public virtual void DisplayDetails()
    {
        Console.WriteLine("\n============== EMPLOYEE DETAILS ==============");
        Console.WriteLine("Employee ID      : " + empId);
        Console.WriteLine("Employee Name    : " + empName);
        Console.WriteLine("Basic Salary     : Rs. " + basicSalary);
    }
}

// Derived Class
class Payroll : Employee, IPayroll
{
    private double bonus;
    private double totalSalary;

    // Constructor
    public Payroll(int id, string name, double salary, double bonus)
        : base(id, name, salary)
    {
        this.bonus = bonus;
    }

    // Interface Method
    public void CalculateSalary()
    {
        totalSalary = basicSalary + bonus;
    }

    // Method Overriding (Polymorphism)
    public override void DisplayDetails()
    {
        base.DisplayDetails();

        Console.WriteLine("Bonus            : Rs. " + bonus);
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Total Salary     : Rs. " + totalSalary);
        Console.WriteLine("----------------------------------------------");
    }
}

// Main Class
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("         EMPLOYEE PAYROLL MANAGEMENT SYSTEM");
        Console.WriteLine("==================================================");

        Console.Write("Enter Employee ID      : ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Employee Name    : ");
        string name = Console.ReadLine();

        Console.Write("Enter Basic Salary     : ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Bonus            : ");
        double bonus = Convert.ToDouble(Console.ReadLine());

        // Object Creation
        Payroll emp = new Payroll(id, name, salary, bonus);

        // Interface Method Call
        emp.CalculateSalary();

        // Overridden Method Call
        emp.DisplayDetails();

        Console.WriteLine("\nPayroll Generated Successfully!");
        Console.WriteLine("==================================================");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}