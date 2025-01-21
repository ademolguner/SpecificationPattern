using System.Linq.Expressions;
using Campaign.Infrastructure.Specifications.Interfaces;

namespace Campaign.Infrastructure.Specifications.Composites;

public class AndSpecification<T>(ISpecification<T> specificationLeft, 
                                 ISpecification<T> specificationRight) 
             : ISpecification<T>
{
    public bool IsSatisfiedBy(T candidate)
    {
           return specificationLeft.IsSatisfiedBy(candidate) 
               && specificationRight.IsSatisfiedBy(candidate);
    }

    public Expression<Func<T, bool>> ConvertToExpression()
    {
        var expr1 = specificationLeft.ConvertToExpression();
        var expr2 = specificationRight.ConvertToExpression();

        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.AndAlso(
            Expression.Invoke(expr1, parameter),
            Expression.Invoke(expr2, parameter)
        );

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}