using MediatR;

namespace Application.Features.CreditApplications.Commands.Create;

public class CreateCreditApplicationCommand : IRequest<CreateCreditApplicationResponse>
{
    public float Amount { get; set; }
    public int InstallmentCount { get; set; }
    public DateTime? PaidBackIn { get; set; }
    public double Interest { get; set; }
    public Guid LinkedCustomerId { get; init; }
}
