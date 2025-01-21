using Campaign.Domain.Common.Enums;
using Campaign.Domain.Generic;

namespace Campaign.Domain;

public class Customer:IAggreegateRoot, IEntity
{
    public Guid Id { get; protected set; }
    public  string Name { get; protected set ; }
    public decimal TotalPurchaseAmount { get; protected set; }
    public MembershipLevel MembershipLevel { get; protected set; }
    public DateTime RegistrationDate { get; protected set; }
    public int Age { get; protected set; }
    public  string City { get; protected set; }


    protected Customer(string name, string city)
    {
        Name = name;
        City = city;
        Id = Guid.NewGuid();
    }
    public Customer( string name, decimal totalPurchaseAmount, MembershipLevel membershipLevel, DateTime registrationDate, string city, int age):this(name,city)
    {
        Id = Guid.NewGuid();
        Name = name;
        TotalPurchaseAmount = totalPurchaseAmount;
        MembershipLevel = membershipLevel;
        RegistrationDate = registrationDate;
        City = city;
        Age = age;
    }

    public Guid GetId()
    {
        return Id;
    }

    public void SetUpdateProperties(string name, decimal totalPurchaseAmount, MembershipLevel membershipLevel, string city, int age, DateTime registrationDate)
    {
        Name = name;
        TotalPurchaseAmount = totalPurchaseAmount;
        MembershipLevel = membershipLevel;
        City = city;
        Age = age;
        RegistrationDate = registrationDate;
    }
}


