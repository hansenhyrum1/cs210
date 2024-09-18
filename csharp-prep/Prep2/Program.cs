using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string number = Console.ReadLine();
        int percentage = int.Parse(number);

        string letter = "";

        if (percentage >= 90)
        {
            letter = "A";
        }

        else if (percentage >= 80)
        {
            letter = "B";
        }

        else if (percentage >= 70)
        {
            letter = "C";
        }

        else if (percentage >= 60)
        {
            letter = "D";
        }

        else if (percentage < 60)
        {
            letter = "F";
        }

        Console.WriteLine($"You got an {letter} in the class.");

        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the Class!");
        }

        else if (percentage < 70)
        {
            Console.WriteLine("You did not pass the class, better luck next time!");
        }
    }
}