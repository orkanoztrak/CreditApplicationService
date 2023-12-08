using Domain.Core;
using MediatR;

namespace Application.Features.CreditApplications.Commands.Create;

public class CreateCreditApplicationCommand : IRequest<CreateCreditApplicationResponse>
{
    public int Amount { get; set; }
    public int InstallmentCount { get; set; }
    public DateTime StartDate { get; set; }
    public double Interest { get; set; }
    public CreditApplicationStatus Status { get; set; } = CreditApplicationStatus.Pending;
}
