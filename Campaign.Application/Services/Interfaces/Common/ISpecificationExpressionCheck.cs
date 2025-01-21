using System.Linq.Expressions;

namespace Campaign.Application.Services.Interfaces.Common;

public interface ISpecificationExpressionCheck<T>
{
    Expression<Func<T, bool>> ConvertToExpression();
}