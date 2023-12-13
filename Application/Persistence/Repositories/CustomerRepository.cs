using Domain.Entities;

namespace Application.Persistence.Repositories;

public class CustomerRepository : RepositoryBase <Customer, BaseDbContext>
{
    public CustomerRepository(BaseDbContext context) : base(context)
    {
        
    }

    /*public void Retrieve(Customer entity)
    {
        Context.Entry(entity).Collection(b => b.CreditApplications).Load();
    }*/
}
