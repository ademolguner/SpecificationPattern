using Campaign.Contract.Responses.Customers;
using MediatR;

namespace Campaign.Application.Features.Customers.Query.GetAll;

public class GetAllCustomersQuery : IRequest<List<CustomerResponse>>
{
}