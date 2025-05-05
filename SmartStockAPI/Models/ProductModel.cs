using System.ComponentModel.DataAnnotations;

public class ProductModel
{
    [Key]
    public Guid Id { get; private set; }
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
    [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Name can only contain letters, numbers, and spaces.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Description is required.")]
    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    [MinLength(10, ErrorMessage = "Description must be at least 10 characters long.")]
    [RegularExpression(@"^[a-zA-Z0-9\s.,]+$", ErrorMessage = "Description can only contain letters, numbers, spaces, periods, and commas.")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Cost price is required.")]
    public decimal CostPrice { get; set; }
    [Required(ErrorMessage = "Sale price is required.")]
    public decimal SalePrice { get; set; }
    [Required(ErrorMessage = "Quantity in stock is required.")] 
    public int QuantityInStock { get; set; }
    [Required(ErrorMessage = "Registration date is required.")]
    public DateTime RegistrationDate { get; private set; }
    [Required(ErrorMessage = "Last update date is required.")]
    public DateTime LastUpdateDate { get; set; }
    [Required(ErrorMessage = "Is active status is required.")]
    public bool IsActive { get; set; } = true;
    public ProductModel(string name, string description, decimal costPrice, decimal salePrice, int quantityInStock, bool isActive)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        CostPrice = costPrice;
        SalePrice = salePrice;
        QuantityInStock = quantityInStock;
        RegistrationDate = DateTime.UtcNow;
        LastUpdateDate = DateTime.UtcNow;
        IsActive = isActive;
    }
}