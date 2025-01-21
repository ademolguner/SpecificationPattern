using Campaign.Application;
using Campaign.Domain.Options;
using Campaign.Infrastructure.Context;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddServiceDependency(builder.Configuration);
builder.Services.AddMediatRDependency();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//database
BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
builder.Services.Configure<MongoDbOptions>(builder.Configuration.GetSection(nameof(MongoDbOptions)));
builder.Services.AddSingleton<CampaignDbContext>();
builder.Services.AddRepositoryDependency();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseHttpsRedirection();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Run();