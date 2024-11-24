public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) 
    { 
    }

    public override string Display()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} Simple Goal: {_name} ({_points} points)";
    }

    public override int RecordProgress()
    {
        _isComplete = true;
        return _points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }
}
