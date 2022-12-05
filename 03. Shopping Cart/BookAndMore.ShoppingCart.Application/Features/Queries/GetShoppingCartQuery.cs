using BookAndMore.ShoppingCart.Application.DTO;
using MediatR;

namespace BookAndMore.ShoppingCart.Application.Features.Queries;

public class GetShoppingCartQuery : IRequest<ShoppingCartDto>
{
    public int Id { get; set; }
    
    public GetShoppingCartQuery(int id)
    {
        Id = id;
    }
}

public class GetShoppingCartsQuery : IRequest<List<ShoppingCartBaseDto>>
{
    
}