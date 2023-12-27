using Domain.Core;
using Domain.Entities;
using Microsoft.Extensions.DependencyModel.Resolution;
using System.Linq.Expressions;

namespace Application.Persistence.Repositories;

public class CreditApplicationRepository : RepositoryBase<CreditApplication, BaseDbContext>
{
    public CreditApplicationRepository(BaseDbContext context) : base(context)
    {
        
    }
    public async Task<CreditApplication> Attach(CreditApplication entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        await Context.AddAsync(entity);
        Context.Entry(entity).Reference(b => b.LinkedCustomer).Load();
        return entity;
    }
    public void Retrieve(CreditApplication entity)
    {
        Context.Entry(entity).Reference(b => b.LinkedCustomer).Load();
    }
}
