using System.Linq.Expressions;
using Campaign.Domain;
using Campaign.Infrastructure.Specifications.Interfaces;

namespace Campaign.Infrastructure.Specifications.DomainModelSpecifications.Customers;

public class MinimumPurchaseAmountSpecification(decimal minAmount) : ISpecification<Customer>
{
    public bool IsSatisfiedBy(Customer candidate)
    {
        return candidate.TotalPurchaseAmount >= minAmount;
    }

    public Expression<Func<Customer, bool>> ConvertToExpression()
    {
        return candidate => candidate.TotalPurchaseAmount >= minAmount;
    }
}


 