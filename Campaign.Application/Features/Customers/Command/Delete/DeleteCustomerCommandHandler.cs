using Campaign.Infrastructure.Context.Repositories;
using MediatR;

namespace Campaign.Application.Features.Customers.Command.Delete;

public class DeleteCustomerCommandHandler(ICustomerRepository repository) : IRequestHandler<DeleteCustomerCommand, bool>
{
    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await repository.GetByIdAsync(request.Id,cancellationToken);
        if (customer == null) return false;

        await repository.DeleteAsync(customer,cancellationToken);
        return true;
    }
}