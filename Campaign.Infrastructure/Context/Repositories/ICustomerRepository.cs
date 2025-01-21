using System.Linq.Expressions;
using Campaign.Domain;

namespace Campaign.Infrastructure.Context.Repositories;

public interface ICustomerRepository
{
    //query
    Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken);
    Task<List<Customer>> GetAllAsync(Expression<Func<Customer, bool>> query, CancellationToken cancellationToken);
    Task<List<Customer>> GetAllAsync(Func<Customer, bool> query, CancellationToken cancellationToken);
    
    //command
    Task AddAsync(Customer customer, CancellationToken cancellationToken);
    Task UpdateAsync(Customer customer, CancellationToken cancellationToken);
    Task DeleteAsync(Customer customer, CancellationToken cancellationToken);
    
    
    
    //range
    Task AddRangeAsync(List<Customer> customers, CancellationToken cancellationToken);
}