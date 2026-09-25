using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main Street", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Jordan Lee", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LAP-100", 899.99, 1));
        order1.AddProduct(new Product("Wireless Mouse", "MOU-205", 24.50, 2));

        Address address2 = new Address("Av. 25 de Setembro, 123", "Maputo", "Maputo", "Mozambique");
        Customer customer2 = new Customer("Alcidio Massanganhe", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("C# Programming Book", "BOK-310", 45.00, 1));
        order2.AddProduct(new Product("Notebook", "NOT-042", 7.50, 3));

        DisplayOrder(1, order1);
        DisplayOrder(2, order2);
    }

    private static void DisplayOrder(int orderNumber, Order order)
    {
        Console.WriteLine($"=== Order {orderNumber} ===");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total cost: ${order.GetTotalCost():0.00}\n");
    }
}
