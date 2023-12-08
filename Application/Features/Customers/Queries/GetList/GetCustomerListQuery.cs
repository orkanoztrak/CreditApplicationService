using MediatR;

namespace Application.Features.Customers.Queries.GetList;

public class GetCustomerListQuery : IRequest<List<GetCustomerListResponse>>
{
}
