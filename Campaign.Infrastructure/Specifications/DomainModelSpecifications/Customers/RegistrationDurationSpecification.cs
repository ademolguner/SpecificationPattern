using System.Linq.Expressions;
using Campaign.Domain;
using Campaign.Infrastructure.Specifications.Interfaces;

namespace Campaign.Infrastructure.Specifications.DomainModelSpecifications.Customers;

public class RegistrationDurationSpecification(int minYears) : ISpecification<Customer>
{
    private static readonly DateTime CurrentDate = DateTime.Now;

    public bool IsSatisfiedBy(Customer candidate)
    {
        return (CurrentDate - candidate.RegistrationDate).TotalDays / 365 >= minYears;
    }

    public Expression<Func<Customer, bool>> ConvertToExpression()
    {
        return customer => (CurrentDate - customer.RegistrationDate).TotalDays / 365 >= minYears;
    }
}