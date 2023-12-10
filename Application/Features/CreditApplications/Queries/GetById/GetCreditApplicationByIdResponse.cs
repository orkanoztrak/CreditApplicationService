using Domain.Core;

namespace Application.Features.CreditApplications.Queries.GetById;

public class GetCreditApplicationByIdResponse
{
    public Guid Id { get; set; }
    public float Amount { get; set; }
    public int InstallmentCount { get; set; }
    public DateTime? PaidBackIn { get; set; }
    public double Interest { get; set; }
    public CreditApplicationStatus Status { get; set; } = CreditApplicationStatus.Pending;
    public ApplicationStatusMessage StatusMessage { get; set; } = ApplicationStatusMessage.CreditApplicationResultPending;
    public Guid LinkedCustomerId { get; init; }

}
