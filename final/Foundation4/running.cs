class Running : Activity
{
    private double _distance {get; set;}

    public Running(string date, double length, double distance) : base(date, length)
    {
        _distance = distance;
    }

    public override string ActivityName()
    {
        return "Running";
    }
    public override double Distance()
    {
        return _distance;
    }

    public override double Speed()
    {
        return (Distance() / _length) * 60;
    }

    public override double Pace()
    {
        return (_length / Distance());
    }
}