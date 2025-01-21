using Campaign.Contract.Responses.Customers;
using Campaign.Infrastructure.Context.Repositories;
using MediatR;

namespace Campaign.Application.Features.Customers.Query.GetById;

public class GetByIdQueryHandler(ICustomerRepository repository)
    : IRequestHandler<GetByIdQuery, CustomerResponse?>
{
    public async Task<CustomerResponse?> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await repository.GetByIdAsync(request.Id,cancellationToken);
        return customer == null ? null : new CustomerResponse(customer);
    }
}