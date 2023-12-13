using Domain.Entities;

namespace Application.Features.Customers.Queries.GetList;

public class GetCustomerListResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string IdNumber { get; set; }
    public float Salary { get; set; }
    public float Debt { get; set; }
    public int CreditScore { get; set; }
    //public ICollection<CreditApplication> CreditApplications { get; set; }
    public DateTime CreatedDate { get; set; }
}