using Catalog.API.Models;

namespace Catalog.API.Products.GetProductsById;

public record GetProductByIdQuery(int Id) : IQuery<GetProductByIdResponse>;
public record GetProductByIdResponse(Product Product);

internal class GetProductByIdHandler(IDocumentSession session, ILogger<GetProductByIdHandler> logger) : 
    IQueryHandler<GetProductByIdQuery, GetProductByIdResponse>
{
    public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByIdHandler.Handle called with {@Query}", query);
        
        var product = await session.LoadAsync<Product>(query.Id,  cancellationToken);
        
        return new GetProductByIdResponse(product ?? new Product());
    }
}