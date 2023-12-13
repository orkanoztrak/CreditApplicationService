using Application.Features.CreditApplications.Commands.Delete;
using Application.Persistence.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Commands.Delete;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResponse>
{
    private readonly CustomerRepository customerRepository;

    public DeleteCustomerCommandHandler(CustomerRepository customerRepository)
    {
        this.customerRepository = customerRepository;
    }

    public async Task<DeleteCustomerResponse> Handle (DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer? result = await customerRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
        if (result == null)
        {
            throw new ArgumentNullException(nameof(result));
        }
        await customerRepository.DeleteAsync(result);
        return new DeleteCustomerResponse
        {
            Id = request.Id
        };

    }
}
