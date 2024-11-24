public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    private bool _isComplete;
    private string _goalCheck;
    public string _goalType

    public bool IsComplete()
    {

    }

    public string Display(string _goaltype)
    {
        if (_isComplete = true)
        {
            _goalCheck = "[X]"
        }
        else if (_isComplete = false)
        {
            _goalCheck = "[ ]"
        }

        return $"{_goalCheck} {_goalType}: {GetName()}"
    }

    public abstract int RecordProgress()
    {

    }
    public abstract int CalculatePoints()
    {

    }

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

    public string GetPoints()
    {
        return _points;
    }
}