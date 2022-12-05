using BookAndMore.Commons.Application.Interfaces;
using BookAndMore.Commons.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAndMore.Commons.Persistance.Repositories;

public class BaseRepository<TEntity, TContext, TId> : IRepository<TEntity, TId> where TEntity : DatabaseObj<TId>
where TContext: DbContext
{
    
    protected readonly DbSet<TEntity> Entities;
    private readonly TContext _context;
    public BaseRepository(TContext context)
    {
        _context = context;
        Entities = context.Set<TEntity>();
    }

    public Task<TEntity?> GetByIdAsync(TId id)
    => Entities.SingleOrDefaultAsync(e => e.Id!.Equals(id));

    public TEntity? GetById(TId id)
    => Entities.SingleOrDefault(e => e.Id!.Equals(id));

    public Task<IQueryable<TEntity>> GetAllAsync()
    => Task.FromResult(Entities.AsQueryable());

    public async Task AddAsync(TEntity entity)
    => await Entities.AddAsync(entity);

    public void Add(TEntity entity)
    => Entities.Add(entity);

    public void Update(TEntity entity)
    {
        Entities.Update(entity);
    }

    public void Delete(TEntity entity)
    => Entities.Remove(entity);

    public Task SaveChangesAsync()
    => _context.SaveChangesAsync();

    public void SaveChanges()
    => _context.SaveChanges();
}