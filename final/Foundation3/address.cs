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

    public string GetAddress()
    {
        return $"{_street} {_city}, {_state}, {_country}";
    }
}