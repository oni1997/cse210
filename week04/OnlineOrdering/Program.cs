using System;

class Program
{
    static void Main()
    {
        //this creates the addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        //this creates the customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Alice Smith", address2);

        //this creates the orders
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "L123", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "M456", 25.50, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", "P789", 799.99, 1));
        order2.AddProduct(new Product("Headphones", "H321", 150.75, 1));

        // Display order details
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.GetTotalPrice());
        Console.WriteLine();
        
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.GetTotalPrice());
    }
}