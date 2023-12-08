using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Core;
using Domain.Entities;

namespace Persistence.Repositories;

public class CustomerRepository : RepositoryBase <Customer, BaseDbContext>
{
    public CustomerRepository(BaseDbContext context) : base(context)
    {
        
    }
}
