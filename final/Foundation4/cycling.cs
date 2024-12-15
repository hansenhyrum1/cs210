class Cycling : Activity
{
    private double _speed {get; set;}

    public Cycling(string date, double length, double speed) : base(date, length)
    {
        _speed = speed;
    }

    public override string ActivityName()
    {
        return "Cycling";
    }

    public override double Distance()
    {
        return (_speed * _length) / 60;
    }

    public override double Speed()
    {
        return _speed;
    }

    public override double Pace()
    {
        return 60 / Speed();
    }
}