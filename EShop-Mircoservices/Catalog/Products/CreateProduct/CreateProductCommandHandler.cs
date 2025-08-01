using BuildingBlocks.CQRS;
using CatalogAPI.Model;
using MediatR;
using System.Windows.Input;

namespace CatalogAPI.Products.CreateProduct
{
    public record CreateProductCommand(string Name, decimal Price, decimal? DiscountPrice, int StockQuantity, string? ImageUrl, int CategoryId, bool IsActive = true, 
                bool IsFeatured = false, double? Weight = null, string? Brand = null): ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id); // the value return
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand Command, CancellationToken cancellationToken)
        {
            //create Product entity from command object

            var product = new Product
            {
                Name = Command.Name,
                Price = Command.Price,
                StockQuantity = Command.StockQuantity,
                CategoryId = Command.CategoryId,
                ImageUrl = Command.ImageUrl
            };
            // save to database

            //return CreateProductResult result
            return new CreateProductResult(Guid.NewGuid());

        }
    }
}
