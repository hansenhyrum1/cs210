public abstract class MindfulnessActivity
{
    protected int _duration;
    protected string _description;

    public MindfulnessActivity(string description)
    {
        this._description = description;
    }

    public virtual void StartActivity()
    {
        Console.WriteLine("Starting activity: " + _description);
    }

    public virtual void EndActivity()
    {
        Console.WriteLine("You finished!");
    }
}