using AutoMapper;
using BookAndMore.Book.Application.DTO;
using BookAndMore.Book.Application.Features.Commands;

namespace BookAndMore.Book.Application.Mappings;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<CreateBookCommand, Domain.Models.Book>();

        CreateMap<Domain.Models.Book, BookDto>();
        CreateMap<Domain.Models.Book, BookBaseDto>();
        
        CreateMap<UpdateBookDto, Domain.Models.Book>();
        
        CreateMap<Domain.Models.Book, Domain.Models.Book>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}