namespace Application.Features.Customers.Queries.GetList;

public class GetCustomerListResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string IdNumber { get; set; }
    public int Salary { get; set; }
    public int Debt { get; set; }
    public int CreditScore { get; set; }
}
