using MediatR;

namespace Campaign.Application.Features.Customers.Command.Delete;

public class DeleteCustomerCommand(Guid id) : IRequest<bool>
{
    public Guid Id { get; } = id;
}