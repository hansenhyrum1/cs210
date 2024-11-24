public abstract class Goal
{
    public string _name;
    public int _points;
    public bool _isComplete;
    protected int _completionCount;

    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
        _isComplete = false;
        _completionCount = 0;
    }

    public abstract string Display();
    public abstract int RecordProgress();
    public abstract bool IsComplete();

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public int GetPoints()
    {
        return _points;
    }

    public void SetPoints(int points)
    {
        _points = points;
    }

    protected int GetBonusPoints()
    {
        if (_completionCount % 5 == 0 && _completionCount > 0)
        {
            Console.WriteLine($"Bonus! You've completed '{_name}' 5 times! Bonus: +50 points!");
            return 50;
        }
        return 0;
    }
}
