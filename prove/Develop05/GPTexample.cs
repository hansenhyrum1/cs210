using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestManager questManager = new QuestManager();
            questManager.LoadGoals();

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

                switch (choice)
                {
                    case 1: questManager.DisplayGoals(); break;
                    case 2: questManager.AddGoal(); break;
                    case 3: questManager.RecordProgress(); break;
                    case 4: questManager.DisplayScore(); break;
                    case 5: questManager.SaveGoals(); break;
                    case 6: questManager.LoadGoals(); break;
                }
            } while (choice != 7);
        }
    }

    abstract class Goal
    {
        private string _name;
        private int _points;

        public void SetName(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetPoints(int points)
        {
            _points = points;
        }

        public int GetPoints()
        {
            return _points;
        }

        public abstract int RecordProgress();
        public abstract bool IsComplete();
    }

    class SimpleGoal : Goal
    {
        private bool _isComplete = false;

        public override int RecordProgress()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                Console.WriteLine($"Completed: {GetName()}. Gained {GetPoints()} points.");
                return GetPoints();
            }
            Console.WriteLine($"{GetName()} is already completed.");
            return 0;
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }
    }

    class EternalGoal : Goal
    {
        public override int RecordProgress()
        {
            Console.WriteLine($"Recorded progress for: {GetName()}. Gained {GetPoints()} points.");
            return GetPoints();
        }

        public override bool IsComplete()
        {
            return false;
        }
    }

    class ChecklistGoal : Goal
    {
        private int _requiredCount;
        private int _currentCount;
        private int _bonus;

        public void SetRequiredCount(int count)
        {
            _requiredCount = count;
        }

        public int GetRequiredCount()
        {
            return _requiredCount;
        }

        public void IncrementCurrentCount()
        {
            _currentCount++;
        }

        public int GetCurrentCount()
        {
            return _currentCount;
        }

        public void SetBonus(int bonus)
        {
            _bonus = bonus;
        }

        public int GetBonus()
        {
            return _bonus;
        }

        public override int RecordProgress()
        {
            IncrementCurrentCount();
            if (_currentCount >= _requiredCount)
            {
                Console.WriteLine($"Completed: {GetName()}! Gained {GetPoints() + GetBonus()} points.");
                return GetPoints() + GetBonus();
            }
            Console.WriteLine($"Progressed: {GetName()} ({_currentCount}/{_requiredCount}). Gained {GetPoints()} points.");
            return GetPoints();
        }

        public override bool IsComplete()
        {
            return _currentCount >= _requiredCount;
        }
    }

    class QuestManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;

        public void DisplayGoals()
        {
            Console.WriteLine("\n--- Goals ---");
            foreach (var goal in _goals)
            {
                string status = goal.IsComplete() ? "[X]" : "[ ]";
                if (goal is ChecklistGoal checklistGoal)
                {
                    status += $" ({checklistGoal.GetCurrentCount()}/{checklistGoal.GetRequiredCount()})";
                }
                Console.WriteLine($"{status} {goal.GetName()}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        public void AddGoal()
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

            Goal goal = type switch
            {
                1 => CreateSimpleGoal(name, points),
                2 => CreateEternalGoal(name, points),
                3 => CreateChecklistGoal(name, points),
                _ => null
            };

            if (goal != null)
            {
                _goals.Add(goal);
                Console.WriteLine("Goal added successfully!");
            }
            Console.ReadLine();
        }

        private Goal CreateSimpleGoal(string name, int points)
        {
            var goal = new SimpleGoal();
            goal.SetName(name);
            goal.SetPoints(points);
            return goal;
        }

        private Goal CreateEternalGoal(string name, int points)
        {
            var goal = new EternalGoal();
            goal.SetName(name);
            goal.SetPoints(points);
            return goal;
        }

        private ChecklistGoal CreateChecklistGoal(string name, int points)
        {
            Console.Write("Enter required count: ");
            int requiredCount = int.Parse(Console.ReadLine() ?? "1");
            Console.Write("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine() ?? "0");

            var goal = new ChecklistGoal();
            goal.SetName(name);
            goal.SetPoints(points);
            goal.SetRequiredCount(requiredCount);
            goal.SetBonus(bonus);
            return goal;
        }

        public void RecordProgress()
        {
            Console.WriteLine("\n--- Record Progress ---");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. { _goals[i].GetName()}");
            }
            Console.Write("Select a goal: ");
            int index = int.Parse(Console.ReadLine() ?? "1") - 1;

            if (index >= 0 && index < _goals.Count)
            {
                _score += _goals[index].RecordProgress();
            }
            Console.ReadLine();
        }

        public void DisplayScore()
        {
            Console.WriteLine($"\nCurrent Score: {_score}\n");
            Console.ReadLine();
        }

        public void SaveGoals()
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                writer.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    if (goal is ChecklistGoal checklistGoal)
                    {
                        writer.WriteLine($"ChecklistGoal|{goal.GetName()}|{goal.GetPoints()}|{checklistGoal.GetRequiredCount()}|{checklistGoal.GetCurrentCount()}|{checklistGoal.GetBonus()}");
                    }
                    else
                    {
                        writer.WriteLine($"{goal.GetType().Name}|{goal.GetName()}|{goal.GetPoints()}");
                    }
                }
            }
            Console.WriteLine("Goals saved successfully!");
            Console.ReadLine();
        }

        public void LoadGoals()
        {
            if (!File.Exists("goals.txt")) return;

            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                _score = int.Parse(reader.ReadLine() ?? "0");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    Goal goal = parts[0] switch
                    {
                        "SimpleGoal" => CreateSimpleGoal(parts[1], int.Parse(parts[2])),
                        "EternalGoal" => CreateEternalGoal(parts[1], int.Parse(parts[2])),
                        "ChecklistGoal" => CreateChecklistGoalFromFile(parts),
                        _ => null
                    };
                    if (goal != null) _goals.Add(goal);
                }
            }
            Console.WriteLine("Goals loaded successfully!");
            Console.ReadLine();
        }

        private ChecklistGoal CreateChecklistGoalFromFile(string[] parts)
        {
            var goal = new ChecklistGoal();
            goal.SetName(parts[1]);
            goal.SetPoints(int.Parse(parts[2]));
            goal.SetRequiredCount(int.Parse(parts[3]));
            goal.IncrementCurrentCount(); // Simulate loading progress
            goal.SetBonus(int.Parse(parts[5]));
            return goal;
        }
    }
}
