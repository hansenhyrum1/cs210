using System.Dynamic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

abstract class Event
{
    private string _title {get; set;}
    private string _description {get; set;}
    private string _date {get; set;}
    private string _time {get; set;}
    private Address _address {get; set;}

    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }
    public string GetStandard()
    {
        return $"Title: {_title}\nDate: {_date} Time: {_time}\nAddress: {_address.GetAddress()}\nDescription: {_description}";
    }
    public string GetShort(string _eventType)
    {
        return $"{_eventType}\nTitle: {_title}\nDate: {_date}";
    }

    public string GetFull(string _eventType, string _details)
    {
        return $"{_eventType}\nTitle: {_title}\nDate: {_date} Time: {_time}\nAddress: {_address.GetAddress()}\n{_details}\nDescription: {_description}";
    }


}