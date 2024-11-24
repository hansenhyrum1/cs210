using System;

class Program
{
    static void Main(string[] args)
    {
        int score = 0;
        List<Goal> goals = new List<Goal>();

        while (true)
        {
            Console.WriteLine("");
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Add Goal");
            Console.WriteLine("3. Record Progress");
            Console.WriteLine("4. View Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                foreach (var goal in goals)
                {
                    Console.WriteLine(goal.Display());
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine("Add a goal. What type of goal?");
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal");
                Console.WriteLine("3. Checklist Goal");
                int goalChoice = int.Parse(Console.ReadLine());

                Console.WriteLine("What is the name of this goal?");
                string name = Console.ReadLine();
                Console.WriteLine("How many points is this goal worth?");
                int points = int.Parse(Console.ReadLine());

                if (goalChoice == 1)
                {
                    goals.Add(new SimpleGoal(name, points));
                    Console.WriteLine("Simple Goal added!");
                }
                else if (goalChoice == 2)
                {
                    goals.Add(new EternalGoal(name, points));
                    Console.WriteLine("Eternal Goal added!");
                }
                else if (goalChoice == 3)
                {
                    Console.WriteLine("How many times must this goal be completed?");
                    int targetCount = int.Parse(Console.ReadLine());
                    Console.WriteLine("How many bonus points for completing this checklist?");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, points, targetCount, bonusPoints));
                    Console.WriteLine("Checklist Goal added!");
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("Which goal would you like to record progress for?");
                for (int i = 0; i < goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {goals[i].Display()}");
                }
                int goalIndex = int.Parse(Console.ReadLine()) - 1;
                int pointsEarned = goals[goalIndex].RecordProgress();
                score += pointsEarned;
                Console.WriteLine($"Progress recorded! You earned {pointsEarned} points.");
            }
            else if (choice == 4)
            {
                Console.WriteLine($"Your total score is: {score}");
            }
            else if (choice == 5)
            {
                Console.WriteLine("Enter the filename to save the goals:");
                string saveFileName = Console.ReadLine();
                SaveGoals(goals, score, saveFileName);
                Console.WriteLine($"Goals saved to {saveFileName}!");
            }
            else if (choice == 6)
            {
                Console.WriteLine("Enter the filename to load the goals:");
                string loadFileName = Console.ReadLine();
                LoadGoals(out goals, out score, loadFileName);
                Console.WriteLine($"Goals loaded from {loadFileName}!");
            }
            else if (choice == 7)
            {
                break;
            }
        }
    }

    static void SaveGoals(List<Goal> goals, int score, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(score);
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.GetType().Name + "|" + goal.ToString());
            }
        }
    }

    static void LoadGoals(out List<Goal> goals, out int score, string fileName)
    {
        goals = new List<Goal>();
        score = 0;

        if (File.Exists(fileName))
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                score = int.Parse(reader.ReadLine());
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split('|');
                    string goalType = parts[0];
                    string goalData = parts[1];

                    if (goalType == "SimpleGoal")
                    {
                    }
                    else if (goalType == "EternalGoal")
                    {
                    }
                    else if (goalType == "ChecklistGoal")
                    {
                    }
                }
            }
        }
        else
        {
            Console.WriteLine($"File {fileName} does not exist.");
        }
    }
}
