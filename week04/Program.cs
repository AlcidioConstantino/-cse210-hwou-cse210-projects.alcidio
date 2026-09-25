using System;
using System.Collections.Generic;

// 1. CLASSE ADDRESS
public class Address
{
    private string _street;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string street, string city, string stateProvince, string country)
    {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa" || _country.ToLower() == "united states" || _country.ToLower() == "estados unidos";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateProvince}\n{_country}";
    }
}

// 2. CLASSE CUSTOMER
public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public bool IsInUSA()
    {
        // Usa a função do Address - requisito da tarefa
        return _address.IsInUSA();
    }

    public Address GetAddress()
    {
        return _address;
    }
}

// 3. CLASSE PRODUCT
public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }
}

// 4. CLASSE ORDER
public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        double shippingCost = _customer.IsInUSA() ? 5 : 35;
        total += shippingCost;

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Etiqueta de Embalagem:\n";
        foreach (Product product in _products)
        {
            label += $"- {product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "Etiqueta de Envio:\n";
        label += $"{_customer.GetName()}\n";
        label += $"{_customer.GetAddress().GetFullAddress()}";
        return label;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // PEDIDO 1 - Cliente nos EUA
        Address address1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop Gamer", "LAP-001", 1200.50, 1));
        order1.AddProduct(new Product("Mouse sem Fio", "MOU-102", 25.99, 2));
        order1.AddProduct(new Product("Teclado Mecânico", "TEC-305", 89.90, 1));

        // PEDIDO 2 - Cliente Internacional (Moçambique)
        Address address2 = new Address("Av. 25 de Setembro 123", "Maputo", "Maputo Cidade", "Mozambique");
        Customer customer2 = new Customer("Alcidio Massanganhe", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Livro de C#", "BOK-550", 45.00, 1));
        order2.AddProduct(new Product("Caderno BYU-I", "CAD-010", 12.50, 3));

        // Exibir resultados
        Console.WriteLine("=== PEDIDO 1 ===");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Preço Total: ${order1.GetTotalCost():0.00}\n");

        Console.WriteLine("=== PEDIDO 2 ===");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Preço Total: ${order2.GetTotalCost():0.00}\n");
    }
}