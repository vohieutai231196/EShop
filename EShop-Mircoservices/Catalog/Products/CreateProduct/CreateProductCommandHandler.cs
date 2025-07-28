using CatalogAPI.Model;

namespace CatalogAPI.Products.CreateProduct
{
    public record CreateProductCommand(string Name, decimal Price, decimal? DiscountPrice, int StockQuantity, string? ImageUrl, int CategoryId, bool IsActive = true, bool IsFeatured = false, double? Weight = null, string? Brand = null);
    public class CreateProductCommandHandler
    {
    }
}
