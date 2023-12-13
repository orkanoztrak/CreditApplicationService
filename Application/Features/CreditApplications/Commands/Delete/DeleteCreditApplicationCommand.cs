using MediatR;

namespace Application.Features.CreditApplications.Commands.Delete;

public class DeleteCreditApplicationCommand : IRequest<DeleteCreditApplicationResponse>
{
    public Guid Id { get; set; }
}
