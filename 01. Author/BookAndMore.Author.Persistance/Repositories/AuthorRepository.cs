using BookAndMore.Author.Application.Repositories;
using BookAndMore.Commons.Persistance.Repositories;

namespace BookAndMore.Author.Persistance.Repositories;

public class AuthorRepository: BaseRepository<Domain.Models.Author,AuthorContext,int>, IAuthorRepository
{
    public AuthorRepository(AuthorContext context) : base(context)
    {
    }
}