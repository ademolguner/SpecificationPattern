using Campaign.Contract.Responses.Customers;
using MediatR;

namespace Campaign.Application.Features.Customers.Query.GetById;

public class GetByIdQuery(Guid id) : IRequest<CustomerResponse?>
{
    public Guid Id { get; } = id;
}