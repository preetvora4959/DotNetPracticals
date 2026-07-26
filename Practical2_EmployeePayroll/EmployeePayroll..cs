using System;

class Student
{
    // Private Data Members
    private int studentId;
    private string studentName;
    private string course;
    private double admissionFee;

    // Parameterized Constructor
    public Student(int id, string name, string courseName, double fee)
    {
        studentId = id;
        studentName = name;
        course = courseName;
        admissionFee = fee;
    }

    // Display Student Details
    public void DisplayAdmissionDetails()
    {
        Console.WriteLine("\n========== STUDENT ADMISSION DETAILS ==========");
        Console.WriteLine("Student ID      : " + studentId);
        Console.WriteLine("Student Name    : " + studentName);
        Console.WriteLine("Course          : " + course);
        Console.WriteLine("Admission Fee   : Rs. " + admissionFee);
    }

    // Scholarship Check
    public void CheckScholarship()
    {
        if (admissionFee >= 50000)
            Console.WriteLine("Scholarship     : Eligible");
        else
            Console.WriteLine("Scholarship     : Not Eligible");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("========== STUDENT ADMISSION MANAGEMENT ==========\n");

        Console.Write("Enter Student ID      : ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Student Name    : ");
        string name = Console.ReadLine();

        Console.Write("Enter Course Name     : ");
        string course = Console.ReadLine();

        Console.Write("Enter Admission Fee   : ");
        double fee = Convert.ToDouble(Console.ReadLine());

        // Object Creation
        Student s1 = new Student(id, name, course, fee);

        // Display Details
        s1.DisplayAdmissionDetails();

        // Check Scholarship
        s1.CheckScholarship();

        Console.WriteLine("\nAdmission Process Completed Successfully.");
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}