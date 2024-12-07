using System.Net.Sockets;

public class Customer
{
    public string _name {get; set;}
    public Address _address {get; set;}

    //Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool InUSA()
    {
        return _address.InUSA();
    }
}