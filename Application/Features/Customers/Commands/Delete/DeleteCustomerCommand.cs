using MediatR;

namespace Application.Features.Customers.Commands.Delete;

public class DeleteCustomerCommand : IRequest<DeleteCustomerResponse>
{
    public Guid Id { get; set; }
}
