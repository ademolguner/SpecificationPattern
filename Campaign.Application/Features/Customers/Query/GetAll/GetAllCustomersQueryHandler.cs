using Campaign.Contract.Responses.Customers;
using Campaign.Infrastructure.Context.Repositories;
using MediatR;

namespace Campaign.Application.Features.Customers.Query.GetAll;

public class GetAllCustomersQueryHandler(ICustomerRepository repository)
    : IRequestHandler<GetAllCustomersQuery, List<CustomerResponse>>
{
    public async Task<List<CustomerResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await repository.GetAllAsync(cancellationToken);
        return customers.Select(c => new CustomerResponse(c)).ToList();
    }
}