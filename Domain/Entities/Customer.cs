using Domain.Core;

namespace Domain.Entities;

public class Customer : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string IdNumber { get; set; }
    public int Salary { get; set; }
    public int Debt { get; set; } = 0;
    public int CreditScore { get; set; } = 0;
    //list of CreditApplications
    public Customer()
    {
        
    }
    public Customer(Guid id, string name, string surname, string email, string idNumber, int salary) : base(id)
    {
        Name = name;
        Surname = surname;
        Email = email;
        IdNumber = idNumber;
        Salary = salary;
    }
}