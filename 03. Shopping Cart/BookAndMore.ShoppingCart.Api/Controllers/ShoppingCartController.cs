using BookAndMore.ShoppingCart.Application.DTO;
using BookAndMore.ShoppingCart.Application.Features.Commands;
using BookAndMore.ShoppingCart.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookAndMore.ShoppingCart.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ShoppingCartController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShoppingCartController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public Task<ShoppingCartDto> AddItemToCart([FromBody] CreateShoppingCartCommand command)
    {
        return _mediator.Send(command);
    }
    
    [HttpGet]
    public Task<List<ShoppingCartBaseDto>> GetShoppingCart()
    {
        return _mediator.Send(new GetShoppingCartsQuery());
    }
    
    [HttpGet("{id:int}")]
    public Task<ShoppingCartDto> GetShoppingCartById(int id)
    {
        return _mediator.Send(new GetShoppingCartQuery(id));
    }
}