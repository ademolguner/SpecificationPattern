using Campaign.Application.Features.Customers.Command.Create;
using Campaign.Contract.Responses.Customers;
using Campaign.Domain;
using Campaign.Infrastructure.Context.Repositories;
using MediatR;

namespace Campaign.Application.Features.Customers.Command.BulkCreate;

public class BulkCreateCustomerCommandHandler(ICustomerRepository repository) : IRequestHandler<BulkCreateCustomerCommand, List<CustomerResponse>>
{
    public async Task<List<CustomerResponse>> Handle(BulkCreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customers = new List<Customer>();
        request.CreateCustomers.ForEach(customer =>
        {
            customers.Add(new Customer(
                customer.Name,
                customer.TotalPurchaseAmount,
                customer.MembershipLevel,
                customer.RegistrationDate,
                customer.City,
                customer.Age
            ));
        });
        

        await repository.AddRangeAsync(customers,cancellationToken);
        var response = new List<CustomerResponse>();
        response.AddRange(customers.Select(c => new CustomerResponse(c)));
        return [..response];
    }
}