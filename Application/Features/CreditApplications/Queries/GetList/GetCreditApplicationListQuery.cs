using MediatR;

namespace Application.Features.CreditApplications.Queries.GetList;

public class GetCreditApplicationListQuery : IRequest<IList<GetCreditApplicationListResponse>>
{
}
