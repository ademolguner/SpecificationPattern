using System.Linq.Expressions;

namespace Campaign.Infrastructure.Specifications.Interfaces;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T candidate);
    Expression<Func<T, bool>> ConvertToExpression();
}