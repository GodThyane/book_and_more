using AutoMapper;
using BookAndMore.Author.Application.DTO;
using BookAndMore.Author.Application.Features.Commands;

namespace BookAndMore.Author.Application.Mappings;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<CreateAuthorCommand, Domain.Models.Author>();

        CreateMap<Domain.Models.Author, AuthorBaseDto>();
        CreateMap<Domain.Models.Author, AuthorDto>();
        
        CreateMap<UpdateAuthorDto, Domain.Models.Author>();
        
        CreateMap<Domain.Models.Author, Domain.Models.Author>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}