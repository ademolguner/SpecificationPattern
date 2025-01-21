using System.Linq.Expressions;
using Campaign.Domain;
using Campaign.Infrastructure.Specifications.Interfaces;

namespace Campaign.Infrastructure.Specifications.DomainModelSpecifications.Customers;

public class CitySpecification(params string[] validCities) : ISpecification<Customer>
{
    private readonly List<string> _validCities = validCities.ToList();

    public bool IsSatisfiedBy(Customer candidate)
    {
        return _validCities.Contains(candidate.City);
    }

    public Expression<Func<Customer, bool>> ConvertToExpression()
    {
        return customer => _validCities.Contains(customer.City);
    }
}
