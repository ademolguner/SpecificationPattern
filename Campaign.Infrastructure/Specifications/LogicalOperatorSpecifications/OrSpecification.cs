using System.Linq.Expressions;
using Campaign.Infrastructure.Specifications.Interfaces;

namespace Campaign.Infrastructure.Specifications.Composites;

public class OrSpecification<T>(ISpecification<T> specification1, 
                                ISpecification<T> specification2) 
             : ISpecification<T>
{
    public bool IsSatisfiedBy(T candidate)
    {
        return specification1.IsSatisfiedBy(candidate) 
               || specification2.IsSatisfiedBy(candidate);
    }

    public Expression<Func<T, bool>> ConvertToExpression()
    {
        var expression1 = specification1.ConvertToExpression();
        var expression2 = specification2.ConvertToExpression();

        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.OrElse(
            Expression.Invoke(expression1, parameter),
            Expression.Invoke(expression2, parameter)
        );

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}