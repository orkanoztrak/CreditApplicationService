using Domain.Entities;

namespace Application.Persistence.Repositories;

public class CustomerRepository : RepositoryBase <Customer, BaseDbContext>
{
    public CustomerRepository(BaseDbContext context) : base(context)
    {
        
    }
}
