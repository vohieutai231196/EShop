using CatalogAPI.Model;
using MediatR;

namespace CatalogAPI.Products.CreateProduct
{
    public record CreateProductCommand(string Name, decimal Price, decimal? DiscountPrice, int StockQuantity, string? ImageUrl, int CategoryId, bool IsActive = true, 
                bool IsFeatured = false, double? Weight = null, string? Brand = null): IRequest<CreateProductResult>;
    public record CreateProductResult(Guid Id); // the value return
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
