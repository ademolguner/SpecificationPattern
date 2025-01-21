using System.Linq.Expressions;
using Campaign.Infrastructure.Specifications.Interfaces;

namespace Campaign.Infrastructure.Specifications.Composites;

public class EqualsSpecification<T, TProperty>(Expression<Func<T, TProperty>> propertyExpression, TProperty value)
    : ISpecification<T>
{
    public bool IsSatisfiedBy(T candidate)
    {
        var compiledExpression = propertyExpression.Compile();
        return EqualityComparer<TProperty>.Default.Equals(compiledExpression(candidate), value);
    }
    

    public Expression<Func<T, bool>> ConvertToExpression()
    {
        var parameter = propertyExpression.Parameters.Single();
        var body = Expression.Equal(propertyExpression.Body, Expression.Constant(value, typeof(TProperty)));
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}