using System.Numerics;

public class Product
{
    private string _name {get; set;}
    private string _id {get; set;}
    private double _unitPrice {get; set;}
    private int _quantity {get; set;}

    private double _totalPrice;

    public Product(string name, string id, double unitPrice, int quantity)
    {
        _name = name;
        _id = id;
        _unitPrice = unitPrice;
        _quantity = quantity;
    }
    public double SubTotalPrice()
    {
        return _unitPrice * _quantity;
    }

    public string Name
    {
        get { return _name; }
    }

    public string Id
    {
        get { return _id; }
    }

}