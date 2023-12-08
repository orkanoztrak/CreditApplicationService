namespace Application.Features.Customers.Commands.Create;

public class CreateCustomerResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string IdNumber { get; set; }
    public int Salary { get; set; }
    public int Debt { get; set; }
    public int CreditScore { get; set; }
    public DateTime CreatedDate { get; set; }
}
