using Application.Persistence.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Queries.GetList;

public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<GetCustomerListResponse>>
{
    private readonly IMapper mapper;
    private readonly CustomerRepository customerRepository;

    public GetCustomerListQueryHandler(IMapper mapper, CustomerRepository customerRepository)
    {
        this.mapper = mapper;
        this.customerRepository = customerRepository;
    }

    public async Task<List<GetCustomerListResponse>> Handle (GetCustomerListQuery request, CancellationToken cancellationToken)
    {
        List<Customer>? result = await customerRepository.GetAllAsync(cancellationToken : cancellationToken);
        if (result is null)
        {
            throw new ArgumentNullException(nameof(result));
        }
        List<GetCustomerListResponse> response = mapper.Map<List<GetCustomerListResponse>>(result);
        return response;
    }
}
