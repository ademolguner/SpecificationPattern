using System.Linq.Expressions;
using Campaign.Domain;
using Campaign.Infrastructure.Specifications.Interfaces;

namespace Campaign.Infrastructure.Specifications.DomainModelSpecifications.Customers;

public class AgeSpecification(int minAge) : ISpecification<Customer>
{
    public bool IsSatisfiedBy(Customer candidate)
    {
        return candidate.Age >= minAge;
    }

    public Expression<Func<Customer, bool>> ConvertToExpression()
    {
        return candidate => candidate.Age >= minAge;
    }
}