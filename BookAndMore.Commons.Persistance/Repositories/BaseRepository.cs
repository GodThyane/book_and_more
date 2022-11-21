using BookAndMore.Commons.Application.Interfaces;
using BookAndMore.Commons.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAndMore.Commons.Persistance.Repositories;

public class BaseRepository<TEntity, TContext, TId> : IRepository<TEntity, TId> where TEntity : DatabaseObj<TId>
where TContext: DbContext
{
    
    private readonly DbSet<TEntity> _entities;
    private readonly TContext _context;
    public BaseRepository(TContext context)
    {
        _context = context;
        _entities = context.Set<TEntity>();
    }

    public Task<TEntity?> GetByIdAsync(TId id)
    => _entities.SingleOrDefaultAsync(e => e.Id!.Equals(id));

    public TEntity? GetById(TId id)
    => _entities.SingleOrDefault(e => e.Id!.Equals(id));

    public Task<IQueryable<TEntity>> GetAllAsync()
    => Task.FromResult(_entities.AsQueryable());

    public async Task AddAsync(TEntity entity)
    => await _entities.AddAsync(entity);

    public void Add(TEntity entity)
    => _entities.Add(entity);

    public void Update(TEntity entity)
    {
        _entities.Update(entity);
    }

    public void Delete(TEntity entity)
    => _entities.Remove(entity);

    public Task SaveChangesAsync()
    => _context.SaveChangesAsync();

    public void SaveChanges()
    => _context.SaveChanges();
}