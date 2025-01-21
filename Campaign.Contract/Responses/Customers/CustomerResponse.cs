using Campaign.Domain;
using Campaign.Domain.Common.Enums;

namespace Campaign.Contract.Responses.Customers;

public class CustomerResponse
{
    public Guid Id { get; set; }
    public  string Name { get; set; }
    public decimal TotalPurchaseAmount { get; set; }
    public MembershipLevel MembershipLevel { get; set; }
    public DateTime RegistrationDate { get; set; }
    public  string City { get; set; }
    public int Age { get; set; }

    public CustomerResponse(Customer customer)
    {
        Id = customer.Id;
        Name = customer.Name;
        TotalPurchaseAmount = customer.TotalPurchaseAmount;
        MembershipLevel = customer.MembershipLevel;
        RegistrationDate = customer.RegistrationDate;
        City = customer.City;
        Age = customer.Age;
    }
}