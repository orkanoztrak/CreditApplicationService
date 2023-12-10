using MediatR;

namespace Application.Features.Customers.Commands.Create;

public class CreateCustomerCommand : IRequest<CreateCustomerResponse>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string IdNumber { get; set; }
    public float Salary { get; set; }
    public int CreditScore { get; set; }
}
