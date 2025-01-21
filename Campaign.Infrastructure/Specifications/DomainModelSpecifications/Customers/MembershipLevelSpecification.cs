using System.Linq.Expressions;
using Campaign.Domain;
using Campaign.Domain.Common.Enums;
using Campaign.Infrastructure.Specifications.Interfaces;

namespace Campaign.Infrastructure.Specifications.DomainModelSpecifications.Customers;

public class MembershipLevelSpecification(params MembershipLevel[] validMembershipLevels) : ISpecification<Customer>
{
     private readonly List<MembershipLevel> _validMembershipLevels = validMembershipLevels.ToList();

    public bool IsSatisfiedBy(Customer customer)    {
        return _validMembershipLevels.Contains(customer.MembershipLevel);
    }

    public Expression<Func<Customer, bool>> ConvertToExpression()
    {
        return customer=> _validMembershipLevels.Contains(customer.MembershipLevel);
    }
}
   