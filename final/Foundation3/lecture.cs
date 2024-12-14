using System.Dynamic;

class Lecture : Event
{
    private string _speaker {get; set;}
    private string _capacity {get; set;}

    public Lecture(string title, string description, string date, string time, Address address, string speaker, string capacity) : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public string EventType()
    {
        return "Lecture";
    }

    public string GetShort()
    {
        return base.GetShort(EventType());
    }

    public string GetFull()
    {
        return base.GetFull(EventType(), $"Speaker: {_speaker}\nCapacity: {_capacity}");
    }
}