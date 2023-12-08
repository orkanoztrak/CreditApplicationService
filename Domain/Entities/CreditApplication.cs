using Domain.Core;

namespace Domain.Entities;

public class CreditApplication : Entity
{
    public int Amount { get; set; }
    public int InstallmentCount { get; set; }
    public DateTime StartDate { get; set; }
    public double Interest {  get; set; }
    public CreditApplicationStatus Status { get; set; } = CreditApplicationStatus.Pending;

    public CreditApplication(Guid id, int amount, int installmentCount, DateTime startDate, double interest) : base(id)
    {
        Amount = amount;
        InstallmentCount = installmentCount;
        StartDate = startDate;
        Interest = interest;
    }
}