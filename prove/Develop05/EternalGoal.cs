public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override string Display()
    {
        return $"[ ] Eternal Goal: {_name} ({_points} points per completion)";
    }

    public override int RecordProgress()
    {
        _completionCount++;
        int bonus = GetBonusPoints();
        return _points + bonus;
    }

    public override bool IsComplete()
    {
        return false;
    }
}