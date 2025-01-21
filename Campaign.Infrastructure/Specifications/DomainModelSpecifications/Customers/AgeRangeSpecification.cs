using System.Linq.Expressions;
using Campaign.Domain;
using Campaign.Infrastructure.Specifications.Interfaces;

namespace Campaign.Infrastructure.Specifications.DomainModelSpecifications.Customers;

public class AgeRangeSpecification(int minAge, int maxAge) : ISpecification<Customer>
{
    public bool IsSatisfiedBy(Customer candidate)
    {
        return candidate.Age >= minAge && candidate.Age <= maxAge;
    }

    public Expression<Func<Customer, bool>> ConvertToExpression()
    {
        return customer => customer.Age >= minAge && customer.Age <= maxAge;
    }
}