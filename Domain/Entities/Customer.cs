using Domain.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Customer : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string IdNumber { get; set; }
    public float Salary { get; set; }
    public float Debt { get; set; } = 0;
    public int CreditScore { get; set; } = 0;
    public virtual ICollection<CreditApplication> CreditApplications { get; } = new List<CreditApplication>();
    public Customer()
    {
        
    }
    public Customer(Guid id, string name, string surname, string email, string idNumber, float salary, int creditScore) : base(id)
    {
        Name = name;
        Surname = surname;
        Email = email;
        IdNumber = idNumber;
        Salary = salary;
        CreditScore = creditScore;
    }
}