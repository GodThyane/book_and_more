using AutoMapper;
using BookAndMore.ShoppingCart.Application.DTO;
using BookAndMore.ShoppingCart.Application.Features.Queries;
using BookAndMore.ShoppingCart.Application.Services;
using BookAndMore.ShoppingCart.Proxy.Book;
using BookAndMore.ShoppingCart.Proxy.Book.DTO;

namespace BookAndMore.ShoppingCart.Application.Features.Handlers.Queries;
using MediatR;

public class GetShoppingCartHandler : IRequestHandler<GetShoppingCartQuery, ShoppingCartDto>
{

    private readonly IShoppingCartService _shoppingCartService;
    private readonly IMapper _mapper;
    private readonly IBookProxy _bookProxy;

    public GetShoppingCartHandler(IShoppingCartService shoppingCartService, IMapper mapper, IBookProxy bookProxy)
    {
        _shoppingCartService = shoppingCartService;
        _mapper = mapper;
        _bookProxy = bookProxy;
    }

    public async Task<ShoppingCartDto> Handle(GetShoppingCartQuery request, CancellationToken cancellationToken)
    {
        var shoppingCart = await _shoppingCartService.GetShoppingCartAsync(request.Id);
        var items = new List<ShoppingCartDetailDto>();
        foreach (var item in shoppingCart.ShoppingCartDetails)
        {
            var book = await _bookProxy.GetBookAsync(item.SelectedProductId);
            var itemDetail = _mapper.Map<ShoppingCartDetailDto>(item);
            itemDetail.Book = book;
            items.Add(itemDetail);
        }
        var shoppingCartDto = _mapper.Map<ShoppingCartDto>(shoppingCart);
        shoppingCartDto.ShoppingCartDetails = items;
        return shoppingCartDto;
    }
}

public class GetShoppingCartsHandler : IRequestHandler<GetShoppingCartsQuery, List<ShoppingCartBaseDto>>
{
    
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IMapper _mapper;

    public GetShoppingCartsHandler(IShoppingCartService shoppingCartService, IMapper mapper)
    {
        _shoppingCartService = shoppingCartService;
        _mapper = mapper;
    }

    public async Task<List<ShoppingCartBaseDto>> Handle(GetShoppingCartsQuery request, CancellationToken cancellationToken)
    {
        var shoppingCarts = await _shoppingCartService.GetShoppingCartsAsync();
        
        return _mapper.Map<List<ShoppingCartBaseDto>>(shoppingCarts);
    }
}