public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _targetCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints)
        : base(name, points)
    {
        _timesCompleted = 0;
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
    }

    public override string Display()
    {
        string status = _timesCompleted >= _targetCount ? "[X]" : "[ ]";
        return $"{status} Checklist Goal: {_name} (Completed {_timesCompleted}/{_targetCount}, {_points} points per completion, {_bonusPoints} bonus)";
    }

    public override int RecordProgress()
    {
        _timesCompleted++;
        int bonus = 0;
        if (_timesCompleted >= _targetCount)
        {
            if (!_isComplete)
            {
                _isComplete = true;
                bonus = _bonusPoints;
            }
        }

        int pointsEarned = _points + bonus;
        pointsEarned += GetBonusPoints();
        return pointsEarned;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }
}