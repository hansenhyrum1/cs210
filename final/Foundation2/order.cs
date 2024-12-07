using System.Runtime.CompilerServices;

public class Order
{
    private Customer customer {get; set;}
    private List<Product> _products = new List<Product>();

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
            label += $"{product.Name} - {product.Id}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"{customer.Name}\n{customer.Address.GetAddress()}";
    }
}