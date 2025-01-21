using Campaign.Domain.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Campaign.Infrastructure.Context;

public class CampaignDbContext
{
    private readonly IMongoDatabase _database;
    public CampaignDbContext(IOptions<MongoDbOptions> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        _database = client.GetDatabase(options.Value.Database);
    }
    
    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}