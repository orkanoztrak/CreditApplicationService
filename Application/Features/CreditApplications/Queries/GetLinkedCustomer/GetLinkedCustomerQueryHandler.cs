using Application.Persistence.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CreditApplications.Queries.GetLinkedCustomer;

public class GetLinkedCustomerQueryHandler : IRequestHandler<GetLinkedCustomerQuery, GetLinkedCustomerResponse>
{
    protected readonly IMapper mapper;
    protected readonly CreditApplicationRepository creditApplicationRepository;

    public GetLinkedCustomerQueryHandler(IMapper mapper, CreditApplicationRepository creditApplicationRepository)
    {
        this.mapper = mapper;
        this.creditApplicationRepository = creditApplicationRepository;
    }

    public async Task<GetLinkedCustomerResponse> Handle(GetLinkedCustomerQuery request, CancellationToken cancellationToken)
    {
        CreditApplication? result = await creditApplicationRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
        if (result is null)
        {
            throw new ArgumentNullException(nameof(result));
        }
        GetLinkedCustomerResponse response = mapper.Map<GetLinkedCustomerResponse>(result.LinkedCustomer);
        return response;
    }
}
