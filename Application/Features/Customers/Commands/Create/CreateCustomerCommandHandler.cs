using Application.Persistence.Repositories;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
namespace Application.Features.Customers.Commands.Create;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
{
    private readonly IMapper mapper;
    private readonly CustomerRepository customerRepository;

    public CreateCustomerCommandHandler(IMapper mapper, CustomerRepository customerRepository)
    {
        this.mapper = mapper;
        this.customerRepository = customerRepository;
    }

    public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = mapper.Map<Customer>(request);
        customer.Id = Guid.NewGuid();

        var result = await customerRepository.AddAsync(customer);

        CreateCustomerResponse createCustomerResponse = mapper.Map<CreateCustomerResponse>(result);
        return createCustomerResponse;
    }
}
