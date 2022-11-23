using BookAndMore.Commons.Domain.Models;

namespace BookAndMore.Commons.Application.Interfaces;

public interface IRepository<TEntity, TId> where TEntity : DatabaseObj<TId>
{
    Task<TEntity?> GetByIdAsync(TId id);
    TEntity? GetById(TId id);
    Task<IQueryable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task SaveChangesAsync();
    void SaveChanges();
}