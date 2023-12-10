using MediatR;

namespace Application.Features.CreditApplications.Queries.GetById;

public class GetCreditApplicationByIdQuery : IRequest<GetCreditApplicationByIdResponse>
{
    public Guid Id { get; set; }
}
