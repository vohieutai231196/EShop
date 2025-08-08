
namespace CatalogAPI.Products.GetProduct
{
    public record GetProductQuery() : IQuery<GetProductResult>;

    public record GetProductResult(IEnumerable<Product> Products);

    public class GetProductCommandHandler(IDocumentSession session, ILogger<GetProductCommandHandler> logger)
        : IQueryHandler<GetProductQuery, GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductCommandHandler.Handler call with {@Query}", query);

            var products = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetProductResult(products);
        }
    }
}
