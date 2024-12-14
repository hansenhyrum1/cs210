class Reception : Event
{
    private string _email;

    public Reception(string title, string description, string date, string time, Address address, string email) : base(title, description, date, time, address)
    {
        _email = email;
    }

    public string EventType()
    {
        return "Reception";
    }

    public string GetShort()
    {
        return base.GetShort(EventType());
    }

    public string GetFull()
    {
        return base.GetFull(EventType(), $"RSVP: {_email}");
    }
}