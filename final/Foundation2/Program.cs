    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Product Router = new Product("Unifi Express", "Ux", 149.00, 1);
            Product AP = new Product("U6 Pro", "U6-Pro", 159.00, 1);
            Product Switch = new Product("Lite 8 POE", "USW-Lite-8-POE", 109.00, 2);
            Product Cable = new Product("Unifi Indoor Cable CMR", "U-Cable-C6-CMR", 179.00, 305);
            Product OutdoorAP = new Product("AC Mesh", "UAP-AC-M", 99.00, 2);
            


            Address address1 = new Address("8519 Salmonberry Lp", "Hayden", "Idaho", "USA");
            Customer customer1 = new Customer("Hyrum", address1);
            
            Order order1 = new Order(customer1);
            order1.AddProduct(Router);
            order1.AddProduct(AP);
            order1.AddProduct(Switch);
            order1.AddProduct(Cable);

            Console.WriteLine("Order 1:");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order1.GetPackingSlip());
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order1.TotalPrice()}");
            Console.WriteLine();



            Address address2 = new Address("12551 N Government Way", "Hayden", "Idaho", "USA");
            Customer customer2 = new Customer("New Leaf Nursery", address2);
            
            Order order2 = new Order(customer2);
            order2.AddProduct(Router);
            order2.AddProduct(OutdoorAP);

            Console.WriteLine("Order 2:");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order2.GetPackingSlip());
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order2.TotalPrice()}");
        }
    }