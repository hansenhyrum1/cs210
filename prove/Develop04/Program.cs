using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("The Mindfulness Program!");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("Select an activity: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        MindfulnessActivity activity = null;

        if (choice == 1)
        {
            activity = new BreathingActivity();
        }
        else if (choice == 2)
        {
            activity = new ReflectionActivity();
        }
        else if (choice == 3)
        {
            activity = new ListingActivity();
        }

        if (activity != null)
        {
            activity.StartActivity();
        }
    }
}