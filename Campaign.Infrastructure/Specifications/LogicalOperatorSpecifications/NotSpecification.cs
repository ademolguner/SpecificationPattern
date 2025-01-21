using System.Linq.Expressions;
using Campaign.Infrastructure.Specifications.Interfaces;

namespace Campaign.Infrastructure.Specifications.Composites;

public class NotSpecification<T>(ISpecification<T> specification) 
             : ISpecification<T>
{
    public bool IsSatisfiedBy(T candidate)
    {
        return !specification.IsSatisfiedBy(candidate);
    }

    public Expression<Func<T, bool>> ConvertToExpression()
    {
        var expression = specification.ConvertToExpression();
        var parameter = expression.Parameters.Single();
        var body = Expression.Not(expression.Body);

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}