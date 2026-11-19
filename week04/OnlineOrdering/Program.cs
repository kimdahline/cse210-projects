class Program
{
    static void Main(string[] args)
    {
        Address usaAddress = new Address(
            "123 Maple Street",
            "Springfield",
            "Illinois",
            "USA");
        Customer usaCustomer = new Customer("Jordan Lee", usaAddress);

        List<Product> usaProducts = new List<Product>
        {
            new Product("Wireless Mouse", "WM-204", 24.99m, 2),
            new Product("USB-C Cable", "UC-110", 8.50m, 3)
        };
        Order usaOrder = new Order(usaProducts, usaCustomer);

        Address internationalAddress = new Address(
            "45 Acacia Avenue",
            "Kampala",
            "Central Region",
            "Uganda");
        Customer internationalCustomer = new Customer("Amina Nansubuga", internationalAddress);

        List<Product> internationalProducts = new List<Product>
        {
            new Product("Notebook", "NB-015", 4.25m, 4),
            new Product("Ballpoint Pens", "BP-032", 1.75m, 6),
            new Product("Desk Lamp", "DL-208", 18.00m, 1)
        };
        Order internationalOrder = new Order(internationalProducts, internationalCustomer);

        DisplayOrder("USA Order", usaOrder);
        DisplayOrder("International Order", internationalOrder);
    }

    static void DisplayOrder(string heading, Order order)
    {
        Console.WriteLine($"--- {heading} ---");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order.GetTotalCostString()}");
        Console.WriteLine();
    }
}
