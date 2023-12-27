using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CreditApplications.Queries.GetLinkedCustomer;

public class GetLinkedCustomerQuery : IRequest<GetLinkedCustomerResponse>
{
    public Guid Id { get; set; }
}
