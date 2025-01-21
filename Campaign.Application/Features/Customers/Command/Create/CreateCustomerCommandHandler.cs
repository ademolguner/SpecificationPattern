using Campaign.Contract.Responses.Customers;
using Campaign.Domain;
using Campaign.Infrastructure.Context.Repositories;
using MediatR;

namespace Campaign.Application.Features.Customers.Command.Create;

public class CreateCustomerCommandHandler(ICustomerRepository repository) : IRequestHandler<CreateCustomerCommand, CustomerResponse?>
{
    public async Task<CustomerResponse?> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(
            request.CreateCustomerRequest.Name,
            request.CreateCustomerRequest.TotalPurchaseAmount,
            request.CreateCustomerRequest.MembershipLevel,
            request.CreateCustomerRequest.RegistrationDate,
            request.CreateCustomerRequest.City,
            request.CreateCustomerRequest.Age
        );

        await repository.AddAsync(customer,cancellationToken);
        return new CustomerResponse(customer);
    }
}