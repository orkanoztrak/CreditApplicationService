using Application.Persistence.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetCreditApplicationsForCustomer;

public class GetCreditApplicationsForCustomerQueryHandler : IRequestHandler<GetCreditApplicationsForCustomerQuery, ICollection<GetCreditApplicationsForCustomerResponse>>
{
    private readonly IMapper mapper;
    private readonly CustomerRepository customerRepository;

    public GetCreditApplicationsForCustomerQueryHandler(IMapper mapper, CustomerRepository customerRepository)
    {
        this.mapper = mapper;
        this.customerRepository = customerRepository;
    }

    public async Task<ICollection<GetCreditApplicationsForCustomerResponse>> Handle (GetCreditApplicationsForCustomerQuery request, CancellationToken cancellationToken)
    {
        Customer? result = await customerRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
        if (result is null)
        {
            throw new ArgumentNullException(nameof(result));
        }
        if (result.CreditApplications.Count == 0)
        {
            throw new ArgumentNullException("This customer has made no credit applications yet!");
        }
        ICollection<GetCreditApplicationsForCustomerResponse> response = mapper.Map<ICollection<GetCreditApplicationsForCustomerResponse>>(result.CreditApplications);
        return response;
    }
}
