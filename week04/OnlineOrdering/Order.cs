using System.Globalization;

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(List<Product> products, Customer customer)
    {
        _products = new List<Product>(products);
        _customer = customer;
    }

    public List<Product> GetProducts()
    {
        return new List<Product>(_products);
    }

    public void SetProducts(List<Product> products)
    {
        _products = new List<Product>(products);
    }

    public Customer GetCustomer()
    {
        return _customer;
    }

    public void SetCustomer(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalCost()
    {
        decimal productTotal = 0;

        foreach (Product product in _products)
        {
            productTotal += product.GetTotalCost();
        }

        decimal shippingCost = _customer.IsInUSA() ? 5m : 35m;
        return productTotal + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label";

        foreach (Product product in _products)
        {
            label += $"\n{product.GetName()} (Product ID: {product.GetProductId()})";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label\n{_customer.GetName()}\n{_customer.GetAddress().GetAddressString()}";
    }

    public string GetTotalCostString()
    {
        return GetTotalCost().ToString("C2", CultureInfo.GetCultureInfo("en-US"));
    }
}
