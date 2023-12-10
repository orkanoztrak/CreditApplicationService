using Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Persistence;
public abstract class RepositoryBase<TEntity, TContext>
    where TEntity : Entity
    where TContext : DbContext
{
    protected readonly TContext Context;
    protected IQueryable<TEntity> Query => Context.Set<TEntity>();

    protected RepositoryBase(TContext context)
    {
        Context = context;
    }
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async void Save()
    {
        await Context.SaveChangesAsync();
    }
    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Context.Set<TEntity>().Attach(entity);
        entity.UpdatedDate = DateTime.UtcNow;
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        Context.Remove(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async void DeleteAllAsync(IEnumerable<TEntity> entities)
    {
        foreach (TEntity entity in entities)
            Context.Remove(entity);
        await Context.SaveChangesAsync();
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Query.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Query.ToListAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Query.Where(predicate).ToListAsync(cancellationToken).ConfigureAwait(false);
    }
}
