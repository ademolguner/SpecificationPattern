using Campaign.Contract.Requests.Campaigns;
using Campaign.Contract.Responses.Customers;
using Campaign.Domain.Common.Enums;
using MediatR;

namespace Campaign.Application.Features.Customers.Command.BulkCreate;

public class BulkCreateCustomerCommand : IRequest<List<CustomerResponse>>
{
    public List<CreateCustomerRequest> CreateCustomers { get; set; }
}