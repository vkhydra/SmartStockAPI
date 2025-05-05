namespace SmartStockAPI.Data.DTOs.Product;

public class UpdateProductDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal CostPrice { get; set; }
    public decimal SalePrice { get; set; }
    public int QuantityInStock { get; set; }
    public bool IsActive { get; set; }
}