using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the guess my number game! Guess a number between 1 and 100");

        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);

        int guess = 0;

        while (guess != number)
        {
            Console.WriteLine("Guess the number:");
            guess = int.Parse(Console.ReadLine());

            if (guess == number)
            {
                Console.WriteLine("You guessed it!");
            }
            else if (guess > number)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < number)
            {
                Console.WriteLine("Higher");
            }
        }

    }
}