using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment first = new Assignment("Hyrum", "Algebra");
        Console.WriteLine(first.GetAll());

        MathAssignment second = new MathAssignment("Hyrum", "Trigonometry", "15.4", "12-22");
        Console.WriteLine(second.GetAll());
        Console.WriteLine(second.GetHomeworkList());

        WritingAssignment third = new WritingAssignment("Hyrum", "Why Writing is the Worst", "The Slow Death of a Student");
        Console.WriteLine(third.GetAll());
        Console.WriteLine(third.GetWritingInformation());
    }
}