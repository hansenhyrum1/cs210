using System.Runtime.CompilerServices;

public class Address
{
    private string _street {get; set;}
    private string _city {get; set;}
    private string _state {get; set;}
    private string _country {get; set;}

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