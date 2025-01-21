using Campaign.Contract.Requests.Campaigns;
using Campaign.Contract.Responses.Customers;
using Campaign.Domain;
using Campaign.Domain.Common.Enums;
using MediatR;

namespace Campaign.Application.Features.Customers.Command.Create;

public class CreateCustomerCommand : IRequest<CustomerResponse?>
{
public CreateCustomerRequest CreateCustomerRequest { get; set; }
}