using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CreditApplications.Queries.GetLinkedCustomer;

public class GetLinkedCustomerResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string IdNumber { get; set; }
    public float Salary { get; set; }
    public float Debt { get; set; }
    public int CreditScore { get; set; }
    public DateTime CreatedDate { get; set; }

}
