namespace CatalogAPI.Products.CreateProduct
{
    public record CreateProductCommand(string Name, decimal Price, decimal? DiscountPrice, int StockQuantity, string? ImageUrl, int CategoryId, bool IsActive = true, 
                bool IsFeatured = false, double? Weight = null, string? Brand = null): ICommand<CreateProductResult>;
    public record CreateProductResult(int Id); // the value return
    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
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
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            //return CreateProductResult result
            return new CreateProductResult(product.Id);

        }
    }
}
