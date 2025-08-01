using Carter;
using Mapster;
using MediatR;

namespace CatalogAPI.Products.CreateProduct
{
    public record CreateProductRequest(string Name, decimal Price, decimal? DiscountPrice, int StockQuantity, string? ImageUrl, int CategoryId, bool IsActive = true,
                bool IsFeatured = false, double? Weight = null, string? Brand = null);

    public record CreateProductResponse(Guid Id);

    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/Product", async (CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/product/{response.Id}", response);
            }).WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Create Product");
        }
    }
}
