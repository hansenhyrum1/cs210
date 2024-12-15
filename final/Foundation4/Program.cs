using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
        };

        Running running1 = new Running("December 5, 2024", 60, 5);
        activities.Add(running1);

        Cycling cycling1 = new Cycling("December 6, 2003", 24, 15);
        activities.Add(cycling1);

        Swimming swimming1 = new Swimming("June 3, 1968", 120, 50);
        activities.Add(swimming1);

        foreach (Activity Activity in activities)
        {
            Console.WriteLine(Activity.GetSummary());
            Console.WriteLine();
        }

    }
}