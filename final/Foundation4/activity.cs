abstract class Activity
{
    private string _date {get; set;}
    protected double _length {get; set;}

    public virtual string ActivityName()
    {
        return "Event";
    }
    public virtual double Distance()
    {
        return 0;
    }

    public virtual double Speed()
    {
        return 0;
    }

    public virtual double Pace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"{ActivityName()} \nDate: {_date} \nLength: {_length} minutes \nDistance: {Distance()} miles \nSpeed: {Speed()} mph \nPace: {Pace()} mpm";
    }

    public Activity(string date, double length)
    {
        _date = date;
        _length = length;
    }
}