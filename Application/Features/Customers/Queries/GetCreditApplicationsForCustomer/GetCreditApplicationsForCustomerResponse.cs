using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetCreditApplicationsForCustomer;

public class GetCreditApplicationsForCustomerResponse
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
