using System.Linq.Expressions;
using Campaign.Domain;
using Campaign.Infrastructure.Context;
using Campaign.Infrastructure.Context.Repositories;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Campaign.Application.Repositories;

public class CustomerRepository(CampaignDbContext context) : ICustomerRepository
{
    private readonly IMongoCollection<Customer> _customerCollection = context.GetCollection<Customer>("Customers");
   

    public async Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _customerCollection.Find(c=>c.Id.Equals(id)).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _customerCollection.Find(_ => true).ToListAsync(cancellationToken);
    }

    public Task<List<Customer>> GetAllAsync(Expression<Func<Customer, bool>> query, CancellationToken cancellationToken)
    {
        var customers = _customerCollection
            .AsQueryable()
            .AsEnumerable()
            .Where(query.Compile())
            .ToList();
        
        return Task.FromResult(customers);
    }

    public Task<List<Customer>> GetAllAsync(Func<Customer, bool> query, CancellationToken cancellationToken)
    {
        var customers = _customerCollection
            .AsQueryable()
            .AsEnumerable()
            .Where(query)
            .ToList();
        
        return Task.FromResult(customers);
    }

    public async Task AddRangeAsync(List<Customer> customers, CancellationToken cancellationToken)
    {
        if (customers.Count == 1)
            await AddAsync(customers[0], cancellationToken);
        await _customerCollection.InsertManyAsync(customers, cancellationToken: cancellationToken);
    }
    
    
    public async Task AddAsync(Customer customer, CancellationToken cancellationToken)
    {
        await _customerCollection.InsertOneAsync(customer, cancellationToken: cancellationToken);
    }
    
    public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken)
    {
        var filter = Builders<Customer>.Filter.Eq(c => c.Id, customer.Id);
        await _customerCollection.ReplaceOneAsync(filter, customer, cancellationToken: cancellationToken);
    }
    
    public async Task DeleteAsync(Customer customer, CancellationToken cancellationToken)
    {
        var filter = Builders<Customer>.Filter.Eq(c => c.Id, customer.Id);
        var result = await _customerCollection.DeleteOneAsync(filter, cancellationToken);
        if (result.DeletedCount == 0)
        {
            throw new DbUpdateException("The customer could not be found or deleted.");
        }
    }

    
}
