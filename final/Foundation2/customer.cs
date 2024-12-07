using System.Net.Sockets;

public class Customer
{
    private string _name {get; set;}
    private Address _address {get; set;}

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

     public string Name
    {
        get { return _name; }
    }

    public Address Address
    {
        get { return _address; }
    }
}