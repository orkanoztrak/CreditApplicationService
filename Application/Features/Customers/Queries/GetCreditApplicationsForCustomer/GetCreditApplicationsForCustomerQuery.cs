using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetCreditApplicationsForCustomer;

public class GetCreditApplicationsForCustomerQuery : IRequest<ICollection<GetCreditApplicationsForCustomerResponse>>
{
    public Guid Id { get; set; }

}
