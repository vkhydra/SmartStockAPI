public class ProductModel
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal CostPrice { get; set; }
    public decimal SalePrice { get; set; }
    public int QuantityInStock { get; set; }
    public DateTime RegistrationDate { get; private set; }
    public ProductModel(string name, string description, decimal costPrice, decimal salePrice, int quantityInStock)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        CostPrice = costPrice;
        SalePrice = salePrice;
        QuantityInStock = quantityInStock;
        RegistrationDate = DateTime.UtcNow;
    }
}