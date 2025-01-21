using Campaign.Contract.Responses.Customers;
using Campaign.Infrastructure.Context.Repositories;
using MediatR;

namespace Campaign.Application.Features.Customers.Command.Update;

public class UpdateCustomerCommandHandler(ICustomerRepository repository)
    : IRequestHandler<UpdateCustomerCommand, CustomerResponse?>
{
    public async Task<CustomerResponse?> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerInfo = request.UpdateCustomerRequest;
        
        var customer = await repository.GetByIdAsync(customerInfo.Id,cancellationToken);
        if (customer == null) return null;

     customer.SetUpdateProperties(
         customerInfo.Name,
         customerInfo.TotalPurchaseAmount,
         customerInfo.MembershipLevel,
         customerInfo.City,
         customerInfo.Age,
         customerInfo.RegistrationDate
        );

        await repository.UpdateAsync(customer,cancellationToken);
        return new CustomerResponse(customer);
    }
}