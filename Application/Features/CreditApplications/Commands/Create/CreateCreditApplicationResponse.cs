using Domain.Core;

namespace Application.Features.CreditApplications.Commands.Create;

public class CreateCreditApplicationResponse
{
    public Guid Id { get; set; }
    public float Amount { get; set; }
    public int InstallmentCount { get; set; }
    public DateTime? PaidBackIn { get; set; }
    public double Interest { get; set; }
    public CreditApplicationStatus Status { get; set; }
    public ApplicationStatusMessage StatusMessage { get; set; }
    public Guid LinkedCustomerId { get; set; }
    public DateTime CreatedDate { get; set; }
}
