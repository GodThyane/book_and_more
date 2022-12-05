using AutoMapper;
using BookAndMore.ShoppingCart.Application.DTO;
using BookAndMore.ShoppingCart.Application.Features.Commands;
using BookAndMore.ShoppingCart.Application.Features.Queries;
using BookAndMore.ShoppingCart.Application.Services;
using BookAndMore.ShoppingCart.Proxy.Book;
using MediatR;

namespace BookAndMore.ShoppingCart.Application.Features.Handlers.Commands;

public class CreateShoppingCartHandler : IRequestHandler<CreateShoppingCartCommand, ShoppingCartDto>
{

    private readonly IShoppingCartService _shoppingCartService;
    private readonly IMapper _mapper;
    private readonly IBookProxy _bookProxy;
    private readonly IMediator _mediator;

    public CreateShoppingCartHandler(IShoppingCartService shoppingCartService, IMapper mapper, IBookProxy bookProxy, IMediator mediator)
    {
        _shoppingCartService = shoppingCartService;
        _mapper = mapper;
        _bookProxy = bookProxy;
        _mediator = mediator;
    }

    public async Task<ShoppingCartDto> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
    {
        var shoppingCart = _mapper.Map<Domain.Models.ShoppingCart>(request);
        foreach (var item in shoppingCart.ShoppingCartDetails)
        {
            await _bookProxy.GetBookAsync(item.SelectedProductId);
        }
        var shoppingCartCreated = await _shoppingCartService.CreateShoppingCartAsync(shoppingCart);
        return await _mediator.Send(new GetShoppingCartQuery(shoppingCartCreated.Id), cancellationToken);
    }
}