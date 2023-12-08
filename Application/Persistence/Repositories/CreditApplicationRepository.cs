using Domain.Entities;

namespace Application.Persistence.Repositories;

public class CreditApplicationRepository : RepositoryBase<CreditApplication, BaseDbContext>
{
    public CreditApplicationRepository(BaseDbContext context) : base(context)
    {
        
    }
}
