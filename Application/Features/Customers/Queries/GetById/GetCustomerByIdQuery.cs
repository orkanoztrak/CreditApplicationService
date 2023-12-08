using MediatR;

namespace Application.Features.Customers.Queries.GetById;

public class GetCustomerByIdQuery : IRequest<GetCustomerByIdResponse>
{
    public Guid Id { get; set; }
}
