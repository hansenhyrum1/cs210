public class SimpleGoal : Goal
{
    public string _goalType = "Simple Goal"
    public SimpleGoal(string name, int points) : base(name, points)
    {
        isCompleted = false;
    }


    public override int RecordProgress()
    {
        if (isCompleted = true)
        {
            return 100;
        }
        else
        {
            return 0;
        }
    }

}