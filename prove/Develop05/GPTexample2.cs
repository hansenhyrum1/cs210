using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Goal> goals = new List<Goal>();
            int score = 0;

            LoadGoals(goals, ref score);

            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Eternal Quest Program ===");
                Console.WriteLine("1. View Goals");
                Console.WriteLine("2. Add Goal");
                Console.WriteLine("3. Record Progress");
                Console.WriteLine("4. View Score");
                Console.WriteLine("5. Save Goals");
                Console.WriteLine("6. Load Goals");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                choice = int.Parse(Console.ReadLine() ?? "7");

                if (choice == 1)
                {
                    DisplayGoals(goals);
                }
                else if (choice == 2)
                {
                    AddGoal(goals);
                }
                else if (choice == 3)
                {
                    score += RecordProgress(goals);
                }
                else if (choice == 4)
                {
                    DisplayScore(score);
                }
                else if (choice == 5)
                {
                    SaveGoals(goals, score);
                }
                else if (choice == 6)
                {
                    LoadGoals(goals, ref score);
                }
            } while (choice != 7);
        }

        static void DisplayGoals(List<Goal> goals)
        {
            Console.WriteLine("\n--- Goals ---");
            foreach (var goal in goals)
            {
                Console.WriteLine(goal.Display());
            }
            Console.ReadLine();
        }

        static void AddGoal(List<Goal> goals)
        {
            Console.WriteLine("\n--- Add Goal ---");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Select a type: ");
            int type = int.Parse(Console.ReadLine() ?? "1");

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter points: ");
            int points = int.Parse(Console.ReadLine() ?? "0");

            Goal goal;
            if (type == 1)
            {
                goal = new SimpleGoal(name, points);
            }
            else if (type == 2)
            {
                goal = new EternalGoal(name, points);
            }
            else if (type == 3)
            {
                goal = ChecklistGoal.CreateChecklistGoal(name, points);
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            goals.Add(goal);
            Console.WriteLine("Goal added successfully!");
            Console.ReadLine();
        }

        static int RecordProgress(List<Goal> goals)
        {
            Console.WriteLine("\n--- Record Progress ---");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
            }
            Console.Write("Select a goal: ");
            int index = int.Parse(Console.ReadLine() ?? "1") - 1;

            if (index >= 0 && index < goals.Count)
            {
                return goals[index].RecordProgress();
            }
            Console.ReadLine();
            return 0;
        }

        static void DisplayScore(int score)
        {
            Console.WriteLine($"\nCurrent Score: {score}\n");
            Console.ReadLine();
        }

        static void SaveGoals(List<Goal> goals, int score)
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                writer.WriteLine(score);
                foreach (var goal in goals)
                {
                    goal.Save(writer);
                }
            }
            Console.WriteLine("Goals saved successfully!");
            Console.ReadLine();
        }

        static void LoadGoals(List<Goal> goals, ref int score)
        {
            if (!File.Exists("goals.txt")) return;

            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                score = int.Parse(reader.ReadLine() ?? "0");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    Goal goal;
                    if (parts[0] == "SimpleGoal")
                    {
                        goal = new SimpleGoal(parts[1], int.Parse(parts[2]));
                    }
                    else if (parts[0] == "EternalGoal")
                    {
                        goal = new EternalGoal(parts[1], int.Parse(parts[2]));
                    }
                    else if (parts[0] == "ChecklistGoal")
                    {
                        goal = ChecklistGoal.FromString(parts);
                    }
                    else
                    {
                        continue;
                    }
                    goals.Add(goal);
                }
            }
            Console.WriteLine("Goals loaded successfully!");
            Console.ReadLine();
        }
    }

    abstract class Goal
    {
        private string name;
        private int points;

        public Goal(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public string GetName() => name;

        public abstract string Display();
        public abstract int RecordProgress();
        public abstract void Save(StreamWriter writer);
    }

    class SimpleGoal : Goal
    {
        private bool isCompleted;

        public SimpleGoal(string name, int points) : base(name, points)
        {
            isCompleted = false;
        }

        public override string Display()
        {
            return $"{(isCompleted ? "[X]" : "[ ]")} Simple Goal: {GetName()}";
        }

        public override int RecordProgress()
        {
            if (!isCompleted)
            {
                isCompleted = true;
                return 100; // Example points for completing
            }
            return 0;
        }

        public override void Save(StreamWriter writer)
        {
            writer.WriteLine($"SimpleGoal|{GetName()}|{(isCompleted ? "1" : "0")}");
        }
    }

    class EternalGoal : Goal
    {
        public EternalGoal(string name, int points) : base(name, points) { }

        public override string Display()
        {
            return $"[ ] Eternal Goal: {GetName()}";
        }

        public override int RecordProgress()
        {
            return 50; // Example points for progress
        }

        public override void Save(StreamWriter writer)
        {
            writer.WriteLine($"EternalGoal|{GetName()}");
        }
    }

    class ChecklistGoal : Goal
    {
        private int timesCompleted;
        private int targetCount;
        private int bonusPoints;

        public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) : base(name, points)
        {
            this.targetCount = targetCount;
            this.bonusPoints = bonusPoints;
            timesCompleted = 0;
        }

        public static ChecklistGoal CreateChecklistGoal(string name, int points)
        {
            Console.Write("Enter target count: ");
            int targetCount = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter bonus points: ");
            int bonusPoints = int.Parse(Console.ReadLine() ?? "0");
            return new ChecklistGoal(name, points, targetCount, bonusPoints);
        }

        public static ChecklistGoal FromString(string[] parts)
        {
            string name = parts[1];
            int points = int.Parse(parts[2]);
            int timesCompleted = int.Parse(parts[3]);
            int targetCount = int.Parse(parts[4]);
            int bonusPoints = int.Parse(parts[5]);
            var goal = new ChecklistGoal(name, points, targetCount, bonusPoints);
            goal.timesCompleted = timesCompleted;
            return goal;
        }

        public override string Display()
        {
            return $"[ ] Checklist Goal: {GetName()} (Completed {timesCompleted}/{targetCount})";
        }

        public override int RecordProgress()
        {
            timesCompleted++;
            if (timesCompleted >= targetCount)
            {
                return bonusPoints;
            }
            return 10; // Example points for progress
        }

        public override void Save(StreamWriter writer)
        {
            writer.WriteLine($"ChecklistGoal|{GetName()}|{timesCompleted}|{targetCount}|{bonusPoints}");
        }
    }
}
