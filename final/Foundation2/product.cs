using System.Numerics;

public class Product
{
    public string _name {get; set;}
    public string _id {get; set;}
    public double _unitPrice {get; set;}
    public int _quantity {get; set;}

    public double _totalPrice;

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


}