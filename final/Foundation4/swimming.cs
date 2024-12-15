class Swimming : Activity
{
    private int _laps {get; set;}

    public Swimming(string date, double length, int laps) : base(date, length)
    {
        _laps = laps;
    }

    public override string ActivityName()
    {
        return "Swimming";
    }

    public override double Distance()
    {
        return (((_laps * 50) / 1000) * 0.62);
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