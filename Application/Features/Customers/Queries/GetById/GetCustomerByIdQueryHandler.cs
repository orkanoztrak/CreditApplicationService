using Application.Persistence.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Queries.GetById;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdResponse>
{
    private readonly IMapper mapper;
    private readonly CustomerRepository customerRepository;

    public GetCustomerByIdQueryHandler(IMapper mapper, CustomerRepository customerRepository)
    {
        this.mapper = mapper;
        this.customerRepository = customerRepository;
    }

    public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        Customer? result = await customerRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
        if (result is null)
        {
            throw new ArgumentNullException(nameof(result));
        }
        GetCustomerByIdResponse getCustomerByIdResponse = mapper.Map<GetCustomerByIdResponse>(result);
        return getCustomerByIdResponse;
    }

}
