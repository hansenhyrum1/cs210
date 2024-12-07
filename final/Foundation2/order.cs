using System.Runtime.CompilerServices;

public class Order
{
    public Customer customer {get; set;}
    public List<Product> _products = new List<Product>();

    //constructor
    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    public double TotalPrice()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.SubTotalPrice();
        }
        if(customer.InUSA() == true)
        {
            total += 5;
        }
        if(customer.InUSA() == false)
        {
            total += 35;
        }
        return total;
    }

    public string GetPackingSlip()
    {
        string label = "";
        foreach (var product in _products)
        {
            label += $"{product._name} - {product._id}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"{customer._name}\n{customer._address.GetAddress()}";
    }
}