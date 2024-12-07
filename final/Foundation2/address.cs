using System.Runtime.CompilerServices;

public class Address
{
    public string _street {get; set;}
    public string _city {get; set;}
    public string _state {get; set;}
    public string _country {get; set;}

    //Constructor
    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }
    public bool InUSA()
    {
        if (_country == "USA")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string GetAddress()
    {
        return $"{_street}\n{_city}, {_state}, {_country}";
    }
}