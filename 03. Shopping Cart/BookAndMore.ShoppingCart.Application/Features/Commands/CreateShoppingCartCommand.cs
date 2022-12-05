using BookAndMore.ShoppingCart.Application.DTO;
using MediatR;

namespace BookAndMore.ShoppingCart.Application.Features.Commands;

public class CreateShoppingCartCommand : IRequest<ShoppingCartDto>
{
    public DateTime? CreatedDate { get; set; }
    public List<CreateShoppingCartDetailDto> ShoppingCartDetails { get; set; } = new();
}