using Campaign.Contract.Requests.Campaigns;
using Campaign.Contract.Responses.Customers;
using Campaign.Domain.Common.Enums;
using MediatR;

namespace Campaign.Application.Features.Customers.Command.Update;

public class UpdateCustomerCommand : IRequest<CustomerResponse?>
{
    public UpdateCustomerRequest UpdateCustomerRequest { get; set; }
}