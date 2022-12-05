using AutoMapper;
using BookAndMore.ShoppingCart.Application.DTO;
using BookAndMore.ShoppingCart.Application.Features.Commands;
using BookAndMore.ShoppingCart.Domain.Models;

namespace BookAndMore.ShoppingCart.Application.Mappings;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<CreateShoppingCartCommand, Domain.Models.ShoppingCart>();
        CreateMap<CreateShoppingCartDetailDto, ShoppingCartDetail>();

        CreateMap<Domain.Models.ShoppingCart, ShoppingCartDto>();
        CreateMap<Domain.Models.ShoppingCart, ShoppingCartBaseDto>();
        CreateMap<ShoppingCartDetail, ShoppingCartDetailDto>();
        CreateMap<ShoppingCartDetail, ShoppingCartDetailBaseDto>();
        

        CreateMap<Domain.Models.ShoppingCart, Domain.Models.ShoppingCart>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}