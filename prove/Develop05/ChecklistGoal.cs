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
        string _status;
        if (_timesCompleted >= _targetCount)
        {
            _status = "[X]";
        }
        else
        {
            _status = "[ ]";
        }

        return $"{_status} Checklist Goal: {_name} (Completed {_timesCompleted}/{_targetCount}, {_points} points per completion, {_bonusPoints} bonus)";
    }

    public override int RecordProgress()
    {
        _timesCompleted = _timesCompleted + 1;

        if (_timesCompleted >= _targetCount)
        {
            if (!_isComplete)
            {
                _isComplete = true;
                int totalPoints = _points + _bonusPoints;
                return totalPoints;
            }
        }

        return _points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }
}