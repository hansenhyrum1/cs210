class OutdoorGathering : Event
{
    private string _weather;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weather) : base(title, description, date, time, address)
    {
        _weather = weather;
    }

    public string EventType()
    {
        return "Outdoor Gathering";
    }

    public string GetShort()
    {
        return base.GetShort(EventType());
    }

    public string GetFull()
    {
        return base.GetFull(EventType(), $"Weather: {_weather}");
    }
}