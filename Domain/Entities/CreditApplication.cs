using Domain.Core;

namespace Domain.Entities;

public class CreditApplication : Entity
{
    public float Amount { get; set; }
    public int InstallmentCount { get; set; }
    public DateTime PaidBackIn { get; set; }
    public float Interest {  get; set; }
    public CreditApplicationStatus Status { get; set; } = CreditApplicationStatus.Pending;
    public ApplicationStatusMessage StatusMessage { get; set; } = ApplicationStatusMessage.CreditApplicationResultPending;
    public virtual Customer LinkedCustomer { get; set; }
    public Guid? LinkedCustomerId { get; set; }

    public CreditApplication()
    {
        
    }
    public CreditApplication(Guid id, float amount, int installmentCount, DateTime paidBackIn, float interest, Guid linkedCustomerId) : base(id)
    {
        Amount = amount;
        InstallmentCount = installmentCount;
        PaidBackIn = paidBackIn;
        Interest = interest;
        LinkedCustomerId = linkedCustomerId;
    }
}