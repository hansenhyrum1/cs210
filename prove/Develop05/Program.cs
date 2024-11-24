using System;

class Program
{
    static void Main(string[] args)
    {
        int _score
        int _choice

        List<Goal> goals = new List<Goals>();


        Console.WriteLine("Eternal Quest Program")
        Console.WriteLine("1. View Goals")
        Console.WriteLine("2. Add Goal")
        Console.WriteLine("3. Record Progress")
        Console.WriteLine("4. View Score")
        Console.WriteLine("5. Save Goals")
        Console.WriteLine("6. Load Goals")
        Console.WriteLine("7. Quit")
        _choice = int.Parse(Console.ReadLine())

        if (_choice = 1)
        {
            foreach (var goal in goals)
            {
                Console.WriteLine(goal.Display());
            }
        }

        if (_choice = 2)
        {
            Console.WriteLine("Add a goal. What type of goal?")
            Console.WriteLine("1. Simple Goal")
            Console.WriteLine("2. Eternal Goal")
            Console.WriteLine("3. Checklist Goal")
            int _goalChoice = int.parse(Console.ReadLine())

            Console.WriteLine("What is the name of this goal?")
            string _name = Console.ReadLine
            Console.WriteLine("How many points is this goal worth?")
            int _points = Console.ReadLine

            if (_goalChoice = 1)
            {
                SimpleGoal goal = new SimpleGoal()
                goal.SetName(_name);
                goal.SetPoints(_points);
                _goals.Add(goal)
                Console.WriteLine("Simple Goal added!")
            }

            if (_goalChoice = 2)
            {
                EternalGoal goal = new EternalGoal()
            }
        }
        
    }
}