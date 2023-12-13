using Application.Persistence.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Queries.GetList;

public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, IList<GetCustomerListResponse>>
{
    private readonly IMapper mapper;
    private readonly CustomerRepository customerRepository;

    public GetCustomerListQueryHandler(IMapper mapper, CustomerRepository customerRepository)
    {
        this.mapper = mapper;
        this.customerRepository = customerRepository;
    }

    public async Task<IList<GetCustomerListResponse>> Handle (GetCustomerListQuery request, CancellationToken cancellationToken)
    {
        IList<Customer>? result = await customerRepository.GetAllAsync(cancellationToken : cancellationToken);
        /*foreach (Customer customer in result)
        {
            customerRepository.Retrieve(customer);
        }*/
        if (result is null)
        {
            throw new ArgumentNullException(nameof(result));
        }
        IList<GetCustomerListResponse> response = mapper.Map<IList<GetCustomerListResponse>>(result);
        return response;
    }
}
