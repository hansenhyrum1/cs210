using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        int input = 1;
        
        while (input != 0)
        {
            Console.WriteLine("Enter any number, type 0 to stop");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
            numbers.Add(input);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is {sum}");

        int average = sum / numbers.Count;
        Console.WriteLine($"The average is {average}");


        int max = 0;

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is {max}");
    }
}