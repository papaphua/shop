namespace Shop.Server.DAL.Core;

public interface IRepository<TEntity, in TKey>
    where TEntity : Entity<TKey>
{
    Task<TEntity?> GetByIdAsync(TKey id);

    Task AddAsync(TEntity entity);

    Task AddRangeAsync(IEnumerable<TEntity> entities);

    void Remove(TEntity entity);

    void RemoveRange(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    void UpdateRange(IEnumerable<TEntity> entities);
}