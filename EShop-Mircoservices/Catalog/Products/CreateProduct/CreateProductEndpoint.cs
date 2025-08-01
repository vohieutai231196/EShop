namespace CatalogAPI.Products.CreateProduct
{
    public record CreateProductRequest(string Name, decimal Price, decimal? DiscountPrice, int StockQuantity, string? ImageUrl, int CategoryId, bool IsActive = true,
                bool IsFeatured = false, double? Weight = null, string? Brand = null);
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint
    {
    }
}
